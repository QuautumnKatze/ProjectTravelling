using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Models
{
    [Table("PostComment")]
    public class PostComment
    {
        [Key]
        public long CommentID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Contents { get; set; }
        public long? PostID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? AccountID { get; set; }
    }
}
