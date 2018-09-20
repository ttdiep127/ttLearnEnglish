using System;

namespace TLE.Entities.Models.EntityModels
{
    public partial class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int? Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool Disable { get; set; }
        public DateTime TokenCreatedDate { get; set; }
        public string Token { get; set; }
        public DateTime JoinedDate { get; set; }
        public string AvtSrc { get; set; }
    }
}
