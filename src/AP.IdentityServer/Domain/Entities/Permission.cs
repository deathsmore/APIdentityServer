using AP.IdentityServer.Domain.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AP.IdentityServer.Domain.Entities
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Ordinal { get; set; }
        public bool WithCategory { get; set; }
        public Status Status { get; set; }
        //Navigation properties
        public IEnumerable<UserPermission>? UserPermissions { get; set; }
    }
}
