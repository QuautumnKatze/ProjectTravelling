﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Models
{
	[Table("view_Featured_Post")]
	public class view_Featured_Post
	{
		[Key]
		public long FeaturedPostID { get; set; }
		public long PostID { get; set; }
		public string? Title { get; set; }
		public string? Abstract { get; set; }
		public string? Contents { get; set; }
		public string? Images { get; set; }
		public string? Link { get; set; }
		public string? Author { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool? IsActive { get; set; }
		public int PostOrder { get; set; }
		public int MenuID { get; set; }
		public int CategoryID { get; set; }
		public int Status { get; set; }

	}
}
