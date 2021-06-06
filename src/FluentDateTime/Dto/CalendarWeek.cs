using holonsoft.FluentDateTime.DateTime;
using System;
using System.Globalization;

namespace holonsoft.FluentDateTime.Dto
{
	/// <summary>
	/// sub class for calendar week data
	/// </summary>
	[Serializable]
	public class CalendarWeek
	{
		public int Year { get; }
		public int Week { get; }

		/// <summary>
		/// Just needed for XML serialization
		/// </summary>
		private CalendarWeek()
		{

		}

		public CalendarWeek(int year, int week)
		{
			Year = year;
			Week = week;
		}


		public CalendarWeek(CalendarWeek calendarWeek)
		{
			Year = calendarWeek.Year;
			Week = calendarWeek.Week;
		}


		public CalendarWeek(System.DateTime referenceDate, bool useGermanWeekCalculation)
		{
			var calculatedDate = useGermanWeekCalculation
					? referenceDate.GetGermanCalendarWeek()
					: referenceDate.GetInternationalCalendarWeek();

			Year = calculatedDate.Year;
			Week = calculatedDate.Week;
		}


		public CalendarWeek(CultureInfo cultureInfo, System.DateTime referenceDate)
		{
			Year = referenceDate.Year;

			Week = cultureInfo.Calendar.GetWeekOfYear(referenceDate,
																								cultureInfo.DateTimeFormat.CalendarWeekRule,
																								cultureInfo.DateTimeFormat.FirstDayOfWeek);

			var tempWeek = cultureInfo.Calendar.GetWeekOfYear(System.DateTime.Now,
																									cultureInfo.DateTimeFormat.CalendarWeekRule,
																									cultureInfo.DateTimeFormat.FirstDayOfWeek);

			if (tempWeek < Week)
			{
				Year -= 1;
			}
		}


		public CalendarWeek(string calendarWeek)
		{
			if (string.IsNullOrWhiteSpace(calendarWeek))
			{
				throw new ArgumentException("calendarWeek must not be empty or null");
			}

			// format is either WW/YYYY or YYYY/WW

			var splitted = calendarWeek.Split('/');
			if ((splitted.Length != 2) || (calendarWeek.Length != 7))
			{
				throw new ArgumentException("format is either WW/YYYY or YYYY/WW");
			}

			int h1;
			int h2;

			if (!int.TryParse(splitted[0], out h1))
			{
				throw new ArgumentException("format is either WW/YYYY or YYYY/WW");
			}

			if (!int.TryParse(splitted[1], out h2))
			{
				throw new ArgumentException("format is either WW/YYYY or YYYY/WW");
			}

			if (h1 < h2)
			{
				Week = h1;
				Year = h2;
			}
			else
			{
				Week = h2;
				Year = h1;
			}
		}


		public CalendarWeek Add(CultureInfo cultureInfo, int weeks)
		{
			var intermediateDate = GetMonday();
			intermediateDate = intermediateDate.AddDays(weeks * 7);

			var intermediateWeek = cultureInfo.Calendar.GetWeekOfYear(intermediateDate,
																									cultureInfo.DateTimeFormat.CalendarWeekRule,
																									cultureInfo.DateTimeFormat.FirstDayOfWeek);

			return new CalendarWeek(intermediateDate.Year, intermediateWeek);
		}


		public static int operator -(CalendarWeek cw1, CalendarWeek cw2)
		{
			var date1 = cw1.GetMonday();
			var date2 = cw2.GetMonday();

			var diff = date1 - date2;

			return diff.Days / 7;
		}


		public static bool operator ==(CalendarWeek cw1, CalendarWeek cw2)
		{
			if (ReferenceEquals(cw1, cw2)) return true;

			if (ReferenceEquals(null, cw1)) return false;
			if (ReferenceEquals(null, cw2)) return false;

			return cw1.Equals(cw2);
		}


		public static bool operator !=(CalendarWeek cw1, CalendarWeek cw2)
		{
			return !(cw1 == cw2);
		}


		public static bool operator >(CalendarWeek cw1, CalendarWeek cw2)
		{
			if (cw1.Year > cw2.Year) return true;
			if (cw1.Year < cw2.Year) return false;

			if (cw1.Week > cw2.Week) return true;

			return false;
		}


		public static bool operator <(CalendarWeek cw1, CalendarWeek cw2)
		{
			if (cw1.Year < cw2.Year) return true;
			if (cw1.Year > cw2.Year) return false;

			if (cw1.Week < cw2.Week) return true;

			return false;
		}


		public static bool operator >=(CalendarWeek cw1, CalendarWeek cw2)
		{
			if (cw1 == cw2) return true;

			return cw1 > cw2;
		}


		public static bool operator <=(CalendarWeek cw1, CalendarWeek cw2)
		{
			if (cw1 == cw2) return true;

			return cw1 < cw2;
		}


		public override bool Equals(object obj)
		{
			var other = obj as CalendarWeek;

			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return (Year.Equals(other.Year) && Week.Equals(other.Week));
		}


		public override int GetHashCode()
		{
			var hashCode = -1210491879;
			hashCode = hashCode * -1521134295 + Year.GetHashCode();
			hashCode = hashCode * -1521134295 + Week.GetHashCode();
			return hashCode;
		}


		public override string ToString()
		{
			return Year.ToString("D4") + "/" + Week.ToString("D2");
		}


		public System.DateTime GetMonday()
		{
			var result = new System.DateTime(Year, 1, 4);
			result = result.AddDays(-(int) ((result.DayOfWeek != DayOfWeek.Sunday) ? result.DayOfWeek - 1 : DayOfWeek.Saturday));

			var w = Week;

			return result.AddDays(--w * 7);
		}


	}
}