using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Models
{
    [Table("Featured_Post")]
    public class Featured_Post
    {
        [Key]
        public long FeaturedPostID { get; set; }
        public long PostID { get; set; }
    }
}
