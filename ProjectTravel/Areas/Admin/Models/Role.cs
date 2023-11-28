using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;

namespace ProjectTravel.Areas.Admin.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
    }
}
