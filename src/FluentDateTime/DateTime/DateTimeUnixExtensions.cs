using System;

namespace holonsoft.FluentDateTime.DateTime
{
	public static partial class DateTimeExtensions
	{
		public static readonly System.DateTime UnixEpoch = new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static long ToUnixTimeSeconds(this System.DateTime self)
		{
			var dto = new System.DateTimeOffset(self);
			return dto.ToUnixTimeSeconds();
		}


		public static System.DateTime FromUnixTimeSecondsToDateTime(this ulong self)
		{
			return UnixEpoch.AddSeconds(self);
		}


		public static System.DateTime FromUnixTimeSecondsToDateTime(this long self)
		{
			return UnixEpoch.AddSeconds(self);
		}
	}
}