// unset

namespace holonsoft.FluentDateTime.DateTime
{
	public static partial class DateTimeExtensions
	{
		/// <summary>
		/// transform to a sql date string without time infos
		/// </summary>
		/// <param name="self">DateTime value to cast</param>
		/// <returns>sql date string</returns>
		public static string ToSqlDate(this System.DateTime self)
		{
			return self.ToString("yyyy-MM-dd");
		}


		/// <summary>
		/// transform to a sql date string with time infos
		/// </summary>
		/// <param name="self">DateTime value to cast</param>
		/// <returns>sql datetime string</returns>
		public static string ToSqlDateTime(this System.DateTime self)
		{
			return self.ToString("yyyy-MM-ddTHH:mm:ss");
		}
	}
}