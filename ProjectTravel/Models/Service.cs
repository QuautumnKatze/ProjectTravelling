using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Models
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public string? Introduce { get; set; }
        public string? Link { get; set; }
        public string? Icon { get; set; }
        public bool? IsActive { get; set; }

    }
}
