using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTravel.Areas.Admin.Models
{
	[Table("Account")]
	public class Account
	{
		[Key]
		public int AccountID { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public int RoleID { get; set; }
		public bool IsActive { get; set; }
		public string? Avatar {  get; set; }
		public string? Address { get; set; }
		public DateTime Birthday { get; set; }

	}
}
