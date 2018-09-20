using AutoMapper;
using System.Threading.Tasks;
using TLE.Entities.Models.AppModule;
using TLE.Entities.Models.EntityModels;
using TLE.Entities.Repositories;
using TLE.Entities.Resource;
using TLE.Entities.UnitOfWork;
using TLE.Repository.Repositories;

namespace TLE.Service
{
    public class UserService: BaseService<User>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<User> Add(User userInput)
        {
            var user = await _repository.Get(userInput.Id);

            if(user != null)
            {
                if (user.Disable)
                {
                    user.Disable = false;
                    _repository.Update(user);
                    await UnitOfWork.SaveChangesAsync();
                }
            } else
            {
                user = _mapper.Map<User>(userInput);
                user.Id = 0;
                await _repository.InsertAsync(user);
            }

            return _mapper.Map<User>(user);
        }

        public async Task<LoginResponse> Login(AuthenticationInput authenticationInput)
        {
            // Login with email and password
            var user = await _repository.Get(authenticationInput.EmailAddress);
            if (user == null)
            {
                return new LoginResponse {
                    Success = false,
                    Message = ErrorMessages.InvalidUserName,
                    User = null,
                };
            }

            //// Verify user active or not
            //if (!user.EmailVerified && !user.SmsVerified)
            //{
            //    throw new AppException(ErrorMessages.UserHasntVerifyAccount);
            //}

            //
            // Check password
            var hashedPassword = authenticationInput.Password;

            if (hashedPassword != user.Password)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = ErrorMessages.IncorrectPassword,
                    User = null
                };
            }

            return new LoginResponse
            {
                Success = true,
                Message = null,
                User = user
            };
        }
    }
}
