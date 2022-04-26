using AP.IdentityServer.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP.IdentityServer.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key] 
        [Column("UserId")] 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string Facebook { get; set; } = string.Empty;
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastLoginTime { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public string Subject { get; set; } = "TEST SUBJECT";//T-TEMP
    }
}
