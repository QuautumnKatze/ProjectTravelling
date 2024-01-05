using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Models
{
	[Table("Location")]
	public class Location
	{
		[Key]
		public int LocationID { get; set; }
		public string? LocationName { get; set; }
		public string? Description { get; set; }
	}
}
