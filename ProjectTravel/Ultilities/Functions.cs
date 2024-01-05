using System.Security.Cryptography;
using System.Text;

namespace ProjectTravel.Ultilities
{
	public class Functions
	{
		public static int _AccountID = 0;
		public static string _UserName = String.Empty;
		public static string _Password = String.Empty;
		public static string _FullName = String.Empty;
		public static string _Email = String.Empty;
		public static string _Phone = String.Empty;
		public static string _Message = string.Empty;
		public static string _MessageEmail = string.Empty;
		public static string _Avatar = string.Empty;
		public static string _Address = String.Empty;
		public static DateTime _Birthday = DateTime.MinValue;
		public static int _RoleID = 0;


		public static string TitleSlugGeneration(string type, string title, long id)
		{
			string sTitle = type + "/" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
			return sTitle;
		}

		public static string getCurrentDate()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public static string MD5Hash(string text)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
			byte[] result = md5.Hash;
			StringBuilder strBuilder = new StringBuilder();
			for (int i = 0; i < result.Length; i++)
			{
				strBuilder.Append(result[i].ToString("x2"));
			}
			return strBuilder.ToString();
		}
		public static string MD5Password(string? text)
		{
			string str = MD5Hash(text);
			for (int i = 0; i <= 5; i++)
				str = MD5Hash(str + "_" + str);
			return str;
		}
		public static bool IsLogin()
		{
			if (string.IsNullOrEmpty(Functions._UserName) || string.IsNullOrEmpty(Functions._Email) || (Functions._AccountID <= 0))
				return false;
			return true;
		}

		public static string FormatDateWithSuffix(DateTime date)
		{
			int day = date.Day;

			// Xử lý thêm "th", "st", "nd", "rd" cho ngày
			string suffix = "th";
			if (day == 1 || day == 21 || day == 31)
			{
				suffix = "st";
			}
			else if (day == 2 || day == 22)
			{
				suffix = "nd";
			}
			else if (day == 3 || day == 23)
			{
				suffix = "rd";
			}

			return date.ToString($"d'{suffix}' MMMM yyyy");
		}

		public static string ConvertToVietnameseDayOfWeek(DayOfWeek dayOfWeek)
		{
			switch (dayOfWeek)
			{
				case DayOfWeek.Sunday:
					return "Chủ nhật";
				case DayOfWeek.Monday:
					return "Thứ hai";
				case DayOfWeek.Tuesday:
					return "Thứ ba";
				case DayOfWeek.Wednesday:
					return "Thứ tư";
				case DayOfWeek.Thursday:
					return "Thứ năm";
				case DayOfWeek.Friday:
					return "Thứ sáu";
				case DayOfWeek.Saturday:
					return "Thứ bảy";
				default:
					throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null);
			}
		}

		public static string ConvertToVietnameseMonth(int month)
		{
			switch (month)
			{
				case 1:
					return "Tháng Một";
				case 2:
					return "Tháng Hai";
				case 3:
					return "Tháng Ba";
				case 4:
					return "Tháng Tư";
				case 5:
					return "Tháng Năm";
				case 6:
					return "Tháng Sáu";
				case 7:
					return "Tháng Bảy";
				case 8:
					return "Tháng Tám";
				case 9:
					return "Tháng Chín";
				case 10:
					return "Tháng Mười";
				case 11:
					return "Tháng Mười Một";
				case 12:
					return "Tháng Mười Hai";
				default:
					throw new ArgumentOutOfRangeException(nameof(month), month, null);
			}
		}

	}
}
