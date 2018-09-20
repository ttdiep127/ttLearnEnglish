using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLE.Entities.Models.EntityModels;
using TLE.Entities.Repositories;

namespace TLE.Repository.Repositories
{
    public static class UserRepository
    {
        public static async Task<User> Get(this IRepository<User> repository, int userId)
        {
            return await repository.Entities.Where(_ => _.Id == userId).FirstOrDefaultAsync();
        }

        public static async Task<User> Get(this IRepository<User> repository, string email)
        {
            return await repository.Entities.Where(_ => _.EmailAddress == email).FirstOrDefaultAsync();
        }
    }
}
