using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Models
{
	[Table("Tour")]
	public class Tour
	{
		[Key]
		public int TourID { get; set; }
		public string? TourName {  get; set; }
		public string? Description { get; set; }
		public string? Images { get; set; }
		public DateTime StartDate { get; set; }
		public string? Duration { get; set; }
		public int LocationID { get; set; }
		public decimal Price { get; set; }
		public decimal PriceSale { get; set; }
		public string? Promotion { get; set; }
		public int Slot {  get; set; }
		public string? TravelBy { get; set; }
		public bool? IsFull { get; set; }
		public bool? IsActive { get; set; }
	}
}
