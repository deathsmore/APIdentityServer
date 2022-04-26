using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP.IdentityServer.Domain.Entities
{
    [Table("UserPermissions")]
    public class UserPermission
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        //Navigation properties
        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
