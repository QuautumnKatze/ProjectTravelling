using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Models
{
    [Table("Testimonial")]
    public class Testimonial
    {
        [Key]

        public int TestimonialID { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public string? Contents { get; set; }
        public string? Images { get; set; }
    }
}
