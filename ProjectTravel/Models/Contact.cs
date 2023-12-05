﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Models
{
	[Table("Contact")]
	public class Contact
	{
		public int ContactID { get; set; }
		public string? Name { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
		public string? Message { get; set; }
		public bool? IsRead { get; set; }
		public DateTime? CreatedDate { get; set; }
	}
}
