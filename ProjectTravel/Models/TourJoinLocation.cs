using Microsoft.EntityFrameworkCore;

namespace ProjectTravel.Models
{
	public class TourJoinLocation
	{
		public Tour tour { get; set; }
		public Location locate { get; set; }
	}
}
