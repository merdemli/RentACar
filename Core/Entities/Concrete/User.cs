using Core.Entities.Abstract;
using System;

namespace Core.Entities.Concrete
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; } 

        public string Firstname { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        //?: null bırakılabilir
    } 
}
