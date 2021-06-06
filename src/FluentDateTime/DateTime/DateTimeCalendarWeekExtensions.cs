// unset

using holonsoft.FluentDateTime.Dto;
using System;
using System.Globalization;

namespace holonsoft.FluentDateTime.DateTime
{
	public static partial class DateTimeExtensions
	{
		/// <summary>
		/// Calculates week of an international date, does not count for Germany!
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static CalendarWeek GetInternationalCalendarWeek(this System.DateTime self)
		{
			var currentCulture = CultureInfo.CurrentCulture;
			var calendar = currentCulture.Calendar;

			var calendarWeek = calendar.GetWeekOfYear(self, currentCulture.DateTimeFormat.CalendarWeekRule, currentCulture.DateTimeFormat.FirstDayOfWeek);

			var date = self;

			// check, whether calendar week is greater than 52 and whether 
			// calendar week of date is calculated as 2
			// In this case GetWeekOfYear has calculated the calendar week not to ISO 8601
			// (Monday, 31.12.2007 will be calculated as 53 - that's wrong
			// The calendar week is set to 1

			if (calendarWeek > 52)
			{
				date = date.AddDays(7);
				var testCalendarWeek = calendar.GetWeekOfYear(date, currentCulture.DateTimeFormat.CalendarWeekRule, currentCulture.DateTimeFormat.FirstDayOfWeek);

				if (testCalendarWeek == 2)
				{
					calendarWeek = 1;
				}
			}

			var year = date.Year;
			if (calendarWeek == 1 && date.Month == 12) year++;

			if (calendarWeek >= 52 && date.Month == 1) year--;

			return new CalendarWeek(year, calendarWeek);
		}


		/// <summary>
		/// Calculates week of a date
		/// Method counts for German Culture only
		/// The calculation is based on the C + + algorithm by Ekkehard Hess from a post in the newsgroup, 
		/// borland.public.cppbuilder.language on 29.7.1999 (released for general use)
		/// </summary>
		/// <param name="self"></param>
		/// <returns>calendar week </returns>
		public static CalendarWeek GetGermanCalendarWeek(this System.DateTime self)
		{
			var date = self;
			var a = Math.Floor((14 - (date.Month)) / 12D);
			var y = date.Year + 4800 - a;
			var m = (date.Month) + (12 * a) - 3;

			var jd = date.Day + Math.Floor(((153 * m) + 2) / 5) +
							 (365 * y) + Math.Floor(y / 4) - Math.Floor(y / 100) +
							 Math.Floor(y / 400) - 32045;

			var d4 = (jd + 31741 - (jd % 7)) % 146097 % 36524 % 1461;
			var L = Math.Floor(d4 / 1460);
			var d1 = ((d4 - L) % 365) + L;

			// get week
			var calendarWeek = (int) Math.Floor(d1 / 7) + 1;

			// get year of week
			var year = date.Year;
			if (calendarWeek == 1 && date.Month == 12) year++;
			if (calendarWeek >= 52 && date.Month == 1) year--;

			return new CalendarWeek(year, calendarWeek);
		}



		/// <summary>
		/// Based on https://stackoverflow.com/questions/662379/calculate-date-from-week-number
		/// </summary>
		/// <param name="year"></param>
		/// <param name="week"></param>
		/// <returns></returns>
		public static System.DateTime FirstDayOfCalenderWeekISO8601(this System.DateTime self, int year, int week)
		{
			var january1 = new System.DateTime(year, 1, 1);
			var daysOffset = DayOfWeek.Thursday - january1.DayOfWeek;

			var firstThursday = january1.AddDays(daysOffset);
			var cal = CultureInfo.CurrentCulture.Calendar;
			var firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

			var weekNum = week;
			if (firstWeek <= 1)
			{
				weekNum -= 1;
			}
			var result = firstThursday.AddDays(weekNum * 7);
			return result.AddDays(-3);
		}


		public static System.DateTime LastDayOfCalenderWeekISO8601(this System.DateTime self, int year, int week)
		{
			return FirstDayOfCalenderWeekISO8601(self, year, week).AddDays(6);
		}
	}
}