using System;
using System.Globalization;

namespace holonsoft.FluentDateTime.DateTime
{
    /// <summary>
    /// Static class containing Fluent <see cref="DateTime"/> extension methods.
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the value of the specified <see cref="FluentTimeSpan"/> to the value of this instance.
        /// </summary>
        public static System.DateTime AddFluentTimeSpan(this System.DateTime dateTime, FluentTimeSpan timeSpan)
        {
            return dateTime.AddMonths(timeSpan.Months)
                .AddYears(timeSpan.Years)
                .Add(timeSpan.TimeSpan);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that subtracts the value of the specified <see cref="FluentTimeSpan"/> to the value of this instance.
        /// </summary>
        public static System.DateTime SubtractFluentTimeSpan(this System.DateTime dateTime, FluentTimeSpan timeSpan)
        {
            return dateTime.AddMonths(-timeSpan.Months)
                .AddYears(-timeSpan.Years)
                .Subtract(timeSpan.TimeSpan);
        }

        /// <summary>
        /// Returns the very end of the given day (the last millisecond of the last hour for the given <see cref="DateTime"/>).
        /// </summary>
        public static System.DateTime EndOfDay(this System.DateTime date)
        {
            return new System.DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999, date.Kind);
        }

        /// <summary>
        /// Returns the timezone-adjusted very end of the given day (the last millisecond of the last hour for the given <see cref="DateTime"/>).
        /// </summary>
        public static System.DateTime EndOfDay(this System.DateTime date, int timeZoneOffset)
        {
            return new System.DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999, date.Kind)
                .AddHours(timeZoneOffset);
        }
        
        /// <summary>
        /// Returns the last day of the week changing the time to the very end of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-25T23:59:59.999
        /// </summary>
        public static System.DateTime EndOfWeek(this System.DateTime date)
        {
            return date.LastDayOfWeek().EndOfDay();
        }
        
        /// <summary>
        /// Returns the last day of the week changing the time to the very end of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-25T23:59:59.999
        /// </summary>
        public static System.DateTime EndOfWeek(this System.DateTime date, int timeZoneOffset)
        {
            return date.LastDayOfWeek().EndOfDay(timeZoneOffset);
        }
        
        /// <summary>
        /// Returns the last day of the month changing the time to the very end of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
        /// </summary>
        public static System.DateTime EndOfMonth(this System.DateTime date)
        {
            return date.LastDayOfMonth().EndOfDay();
        }
        
        /// <summary>
        /// Returns the last day of the month changing the time to the very end of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
        /// </summary>
        public static System.DateTime EndOfMonth(this System.DateTime date, int timeZoneOffset)
        {
            return date.LastDayOfMonth().EndOfDay(timeZoneOffset);
        }
        
        /// <summary>
        /// Returns the last day of the quarter changing the time to the very end of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
        /// </summary>
        public static System.DateTime EndOfQuarter(this System.DateTime date)
        {
            return date.LastDayOfQuarter().EndOfDay();
        }
        
        /// <summary>
        /// Returns the last day of the quarter changing the time to the very end of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
        /// </summary>
        public static System.DateTime EndOfQuarter(this System.DateTime date, int timeZoneOffset)
        {
            return date.LastDayOfQuarter().EndOfDay(timeZoneOffset);
        }
        
        /// <summary>
        /// Returns the last day of the year changing the time to the very end of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
        /// </summary>
        public static System.DateTime EndOfYear(this System.DateTime date)
        {
            return date.LastDayOfYear().EndOfDay();
        }
        
        /// <summary>
        /// Returns the last day of the year changing the time to the very end of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T23:59:59.999
        /// </summary>
        public static System.DateTime EndOfYear(this System.DateTime date, int timeZoneOffset)
        {
            return date.LastDayOfYear().EndOfDay(timeZoneOffset);
        }

        /// <summary>
        /// Returns the Start of the given day (the first millisecond of the given <see cref="DateTime"/>).
        /// </summary>
        public static System.DateTime BeginningOfDay(this System.DateTime date)
        {
            return new System.DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, date.Kind);
        }

        /// <summary>
        /// Returns the timezone-adjusted Start of the given day (the first millisecond of the given <see cref="DateTime"/>).
        /// </summary>
        public static System.DateTime BeginningOfDay(this System.DateTime date, int timezoneOffset)
        {
            return new System.DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, date.Kind)
                .AddHours(timezoneOffset);
        }
        
        /// <summary>
        /// Returns the Start day of the week changing the time to the very start of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-19T00:00:00.000. <see cref="DateTime"/>
        /// </summary>
        public static System.DateTime BeginningOfWeek(this System.DateTime date)
        {
            return date.FirstDayOfWeek().BeginningOfDay();
        }

        /// <summary>
        /// Returns the Start day of the week changing the time to the very start of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-19T00:00:00.000. <see cref="DateTime"/>
        /// </summary>
        public static System.DateTime BeginningOfWeek(this System.DateTime date, int timezoneOffset)
        {
            return date.FirstDayOfWeek().BeginningOfDay(timezoneOffset);
        }
        
        /// <summary>
        /// Returns the Start day of the month changing the time to the very start of the day. Eg, 2011-12-24T06:40:20.005 => 2011-12-01T00:00:00.000. <see cref="DateTime"/>
        /// </summary>
        public static System.DateTime BeginningOfMonth(this System.DateTime date)
        {
            return date.FirstDayOfMonth().BeginningOfDay();
        }

        /// <summary>
        /// Returns the Start day of the month changing the time to the very start of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-12-01T00:00:00.000. <see cref="DateTime"/>
        /// </summary>
        public static System.DateTime BeginningOfMonth(this System.DateTime date, int timezoneOffset)
        {
            return date.FirstDayOfMonth().BeginningOfDay(timezoneOffset);
        }
        
        /// <summary>
        /// Returns the Start day of the quarter changing the time to the very start of the day. Eg, 2011-12-24T06:40:20.005 => 2011-10-01T00:00:00.000. <see cref="DateTime"/>
        /// </summary>
        public static System.DateTime BeginningOfQuarter(this System.DateTime date)
        {
            return date.FirstDayOfQuarter().BeginningOfDay();
        }

        /// <summary>
        /// Returns the Start day of the quarter changing the time to the very start of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-10-01T00:00:00.000. <see cref="DateTime"/>
        /// </summary>
        public static System.DateTime BeginningOfQuarter(this System.DateTime date, int timezoneOffset)
        {
            return date.FirstDayOfQuarter().BeginningOfDay(timezoneOffset);
        }
        
        /// <summary>
        /// Returns the Start day of the year changing the time to the very start of the day. Eg, 2011-12-24T06:40:20.005 => 2011-01-01T00:00:00.000. <see cref="DateTime"/>
        /// </summary>
        public static System.DateTime BeginningOfYear(this System.DateTime date)
        {
            return date.FirstDayOfYear().BeginningOfDay();
        }

        /// <summary>
        /// Returns the Start day of the year changing the time to the very start of the day with timezone-adjusted. Eg, 2011-12-24T06:40:20.005 => 2011-01-01T00:00:00.000. <see cref="DateTime"/>
        /// </summary>
        public static System.DateTime BeginningOfYear(this System.DateTime date, int timezoneOffset)
        {
            return date.FirstDayOfYear().BeginningOfDay(timezoneOffset);
        }

        /// <summary>
        /// Returns the same date (same Day, Month, Hour, Minute, Second etc) in the next calendar year.
        /// If that day does not exist in next year in same month, number of missing days is added to the last day in same month next year.
        /// </summary>
        public static System.DateTime NextYear(this System.DateTime start)
        {
            var nextYear = start.Year + 1;
            var numberOfDaysInSameMonthNextYear = System.DateTime.DaysInMonth(nextYear, start.Month);

            if (numberOfDaysInSameMonthNextYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthNextYear;
                var dateTime = new System.DateTime(nextYear, start.Month, numberOfDaysInSameMonthNextYear, start.Hour, start.Minute, start.Second, start.Millisecond, start.Kind);
                return dateTime + differenceInDays.Days();
            }
            return new System.DateTime(nextYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Kind);
        }

        /// <summary>
        /// Returns the same date (same Day, Month, Hour, Minute, Second etc) in the previous calendar year.
        /// If that day does not exist in previous year in same month, number of missing days is added to the last day in same month previous year.
        /// </summary>
        public static System.DateTime PreviousYear(this System.DateTime start)
        {
            var previousYear = start.Year - 1;
            var numberOfDaysInSameMonthPreviousYear = System.DateTime.DaysInMonth(previousYear, start.Month);

            if (numberOfDaysInSameMonthPreviousYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthPreviousYear;
                var dateTime = new System.DateTime(previousYear, start.Month, numberOfDaysInSameMonthPreviousYear, start.Hour, start.Minute, start.Second, start.Millisecond, start.Kind);
                return dateTime + differenceInDays.Days();
            }
            return new System.DateTime(previousYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> increased by 24 hours ie Next Day.
        /// </summary>
        public static System.DateTime NextDay(this System.DateTime start)
        {
            return start + 1.Days();
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> decreased by 24h period ie Previous Day.
        /// </summary>
        public static System.DateTime PreviousDay(this System.DateTime start)
        {
            return start - 1.Days();
        }

        /// <summary>
        /// Returns first next occurrence of specified <see cref="DayOfWeek"/>.
        /// </summary>
        public static System.DateTime Next(this System.DateTime start, DayOfWeek day)
        {
            do
            {
                start = start.NextDay();
            } while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// Returns first next occurrence of specified <see cref="DayOfWeek"/>.
        /// </summary>
        public static System.DateTime Previous(this System.DateTime start, DayOfWeek day)
        {
            do
            {
                start = start.PreviousDay();
            } while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// Increases supplied <see cref="DateTime"/> for 7 days ie returns the Next Week.
        /// </summary>
        public static System.DateTime WeekAfter(this System.DateTime start)
        {
            return start + 1.Weeks();
        }

        /// <summary>
        /// Decreases supplied <see cref="DateTime"/> for 7 days ie returns the Previous Week.
        /// </summary>
        public static System.DateTime WeekEarlier(this System.DateTime start)
        {
            return start - 1.Weeks();
        }

        /// <summary>
        /// Increases the <see cref="DateTime"/> object with given <see cref="TimeSpan"/> value.
        /// </summary>
        public static System.DateTime IncreaseTime(this System.DateTime startDate, TimeSpan toAdd)
        {
            return startDate + toAdd;
        }

        /// <summary>
        /// Decreases the <see cref="DateTime"/> object with given <see cref="TimeSpan"/> value.
        /// </summary>
        public static System.DateTime DecreaseTime(this System.DateTime startDate, TimeSpan toSubtract)
        {
            return startDate - toSubtract;
        }

        /// <summary>
        /// Returns the original <see cref="DateTime"/> with Hour part changed to supplied hour parameter.
        /// </summary>
        public static System.DateTime SetTime(this System.DateTime originalDate, int hour)
        {
            return new System.DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Kind);
        }

        /// <summary>
        /// Returns the original <see cref="DateTime"/> with Hour and Minute parts changed to supplied hour and minute parameters.
        /// </summary>
        public static System.DateTime SetTime(this System.DateTime originalDate, int hour, int minute)
        {
            return new System.DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Kind);
        }

        /// <summary>
        /// Returns the original <see cref="DateTime"/> with Hour, Minute and Second parts changed to supplied hour, minute and second parameters.
        /// </summary>
        public static System.DateTime SetTime(this System.DateTime originalDate, int hour, int minute, int second)
        {
            return new System.DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond, originalDate.Kind);
        }

        /// <summary>
        /// Returns the original <see cref="DateTime"/> with Hour, Minute, Second and Millisecond parts changed to supplied hour, minute, second and millisecond parameters.
        /// </summary>
        public static System.DateTime SetTime(this System.DateTime originalDate, int hour, int minute, int second, int millisecond)
        {
            return new System.DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, millisecond, originalDate.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Hour part.
        /// </summary>
        public static System.DateTime SetHour(this System.DateTime originalDate, int hour)
        {
            return new System.DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Minute part.
        /// </summary>
        public static System.DateTime SetMinute(this System.DateTime originalDate, int minute)
        {
            return new System.DateTime(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Second part.
        /// </summary>
        public static System.DateTime SetSecond(this System.DateTime originalDate, int second)
        {
            return new System.DateTime(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond, originalDate.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Millisecond part.
        /// </summary>
        public static System.DateTime SetMillisecond(this System.DateTime originalDate, int millisecond)
        {
            return new System.DateTime(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second, millisecond, originalDate.Kind);
        }

        /// <summary>
        /// Returns original <see cref="DateTime"/> value with time part set to midnight (alias for <see cref="BeginningOfDay(DateTime)"/> method).
        /// </summary>
        public static System.DateTime Midnight(this System.DateTime value)
        {
            return value.BeginningOfDay();
        }

        /// <summary>
        /// Returns original <see cref="DateTime"/> value with time part set to Noon (12:00:00h).
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> find Noon for.</param>
        /// <returns>A <see cref="DateTime"/> value with time part set to Noon (12:00:00h).</returns>
        public static System.DateTime Noon(this System.DateTime value)
        {
            return value.SetTime(12, 0, 0, 0);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Year part.
        /// </summary>
        public static System.DateTime SetDate(this System.DateTime value, int year)
        {
            return new System.DateTime(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Year and Month part.
        /// </summary>
        public static System.DateTime SetDate(this System.DateTime value, int year, int month)
        {
            return new System.DateTime(year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Year, Month and Day part.
        /// </summary>
        public static System.DateTime SetDate(this System.DateTime value, int year, int month, int day)
        {
            return new System.DateTime(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Year part.
        /// </summary>
        public static System.DateTime SetYear(this System.DateTime value, int year)
        {
            return new System.DateTime(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Month part.
        /// </summary>
        public static System.DateTime SetMonth(this System.DateTime value, int month)
        {
            return new System.DateTime(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);
        }

        /// <summary>
        /// Returns <see cref="DateTime"/> with changed Day part.
        /// </summary>
        public static System.DateTime SetDay(this System.DateTime value, int day)
        {
            return new System.DateTime(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTime"/> is before then current value.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="toCompareWith">Value to compare with.</param>
        /// <returns>
        /// 	<c>true</c> if the specified current is before; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBefore(this System.DateTime current, System.DateTime toCompareWith)
        {
            return current < toCompareWith;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTime"/> value is After then current value.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="toCompareWith">Value to compare with.</param>
        /// <returns>
        /// 	<c>true</c> if the specified current is after; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAfter(this System.DateTime current, System.DateTime toCompareWith)
        {
            return current > toCompareWith;
        }

        /// <summary>
        /// Returns the given <see cref="DateTime"/> with hour and minutes set At given values.
        /// </summary>
        /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
        /// <param name="hour">The hour to set time to.</param>
        /// <param name="minute">The minute to set time to.</param>
        /// <returns><see cref="DateTime"/> with hour and minute set to given values.</returns>
        public static System.DateTime At(this System.DateTime current, int hour, int minute)
        {
            return current.SetTime(hour, minute);
        }

        /// <summary>
        /// Returns the given <see cref="DateTime"/> with hour and minutes and seconds set At given values.
        /// </summary>
        /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
        /// <param name="hour">The hour to set time to.</param>
        /// <param name="minute">The minute to set time to.</param>
        /// <param name="second">The second to set time to.</param>
        /// <returns><see cref="DateTime"/> with hour and minutes and seconds set to given values.</returns>
        public static System.DateTime At(this System.DateTime current, int hour, int minute, int second)
        {
            return current.SetTime(hour, minute, second);
        }

        /// <summary>
        /// Returns the given <see cref="DateTime"/> with hour and minutes and seconds and milliseconds set At given values.
        /// </summary>
        /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
        /// <param name="hour">The hour to set time to.</param>
        /// <param name="minute">The minute to set time to.</param>
        /// <param name="second">The second to set time to.</param>
        /// <param name="milliseconds">The milliseconds to set time to.</param>
        /// <returns><see cref="DateTime"/> with hour and minutes and seconds set to given values.</returns>
        public static System.DateTime At(this System.DateTime current, int hour, int minute, int second, int milliseconds)
        {
            return current.SetTime(hour, minute, second, milliseconds);
        }

        /// <summary>
        /// Sets the day of the <see cref="DateTime"/> to the first day in that calendar quarter.
        /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html
        /// </summary>
        /// <param name="current"></param>
        /// <returns>given <see cref="DateTime"/> with the day part set to the first day in the quarter.</returns>
        public static System.DateTime FirstDayOfQuarter(this System.DateTime current)
        {
            var currentQuarter = (current.Month - 1) / 3 + 1;
            var firstDay = new System.DateTime(current.Year, 3 * currentQuarter - 2, 1);

            return current.SetDate(firstDay.Year, firstDay.Month, firstDay.Day);
        }

        /// <summary>
        /// Sets the day of the <see cref="DateTime"/> to the first day in that month.
        /// </summary>
        /// <param name="current">The current <see cref="DateTime"/> to be changed.</param>
        /// <returns>given <see cref="DateTime"/> with the day part set to the first day in that month.</returns>
        public static System.DateTime FirstDayOfMonth(this System.DateTime current)
        {
            return current.SetDay(1);
        }

        /// <summary>
        /// Sets the day of the <see cref="DateTime"/> to the last day in that calendar quarter.
        /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html
        /// </summary>
        /// <param name="current"></param>
        /// <returns>given <see cref="DateTime"/> with the day part set to the last day in the quarter.</returns>
        public static System.DateTime LastDayOfQuarter(this System.DateTime current)
        {
            var currentQuarter = (current.Month - 1) / 3 + 1;
            var firstDay = current.SetDate(current.Year, 3 * currentQuarter - 2, 1);
            return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
        }

        /// <summary>
        /// Sets the day of the <see cref="DateTime"/> to the last day in that month.
        /// </summary>
        /// <param name="current">The current DateTime to be changed.</param>
        /// <returns>given <see cref="DateTime"/> with the day part set to the last day in that month.</returns>
        public static System.DateTime LastDayOfMonth(this System.DateTime current)
        {
            return current.SetDay(System.DateTime.DaysInMonth(current.Year, current.Month));
        }

        /// <summary>
        /// Adds the given number of business days to the <see cref="DateTime"/>.
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static System.DateTime AddBusinessDays(this System.DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                } while (current.DayOfWeek == DayOfWeek.Saturday ||
                         current.DayOfWeek == DayOfWeek.Sunday);
            }
            return current;
        }

        /// <summary>
        /// Subtracts the given number of business days to the <see cref="DateTime"/>.
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be subtracted.</param>
        /// <returns>A <see cref="DateTime"/> increased by a given number of business days.</returns>
        public static System.DateTime SubtractBusinessDays(this System.DateTime current, int days)
        {
            return AddBusinessDays(current, -days);
        }

        /// <summary>
        /// Determine if a <see cref="DateTime"/> is in the future.
        /// </summary>
        /// <param name="dateTime">The date to be checked.</param>
        /// <returns><c>true</c> if <paramref name="dateTime"/> is in the future; otherwise <c>false</c>.</returns>
        public static bool IsInFuture(this System.DateTime dateTime)
        {
            return dateTime > System.DateTime.Now;
        }

        /// <summary>
        /// Determine if a <see cref="DateTime"/> is in the past.
        /// </summary>
        /// <param name="dateTime">The date to be checked.</param>
        /// <returns><c>true</c> if <paramref name="dateTime"/> is in the past; otherwise <c>false</c>.</returns>
        public static bool IsInPast(this System.DateTime dateTime)
        {
            return dateTime < System.DateTime.Now;
        }

        /// <summary>
        /// Rounds <paramref name="dateTime"/> to the nearest <see cref="RoundTo"/>.
        /// </summary>
        /// <returns>The rounded <see cref="DateTime"/>.</returns>
        public static System.DateTime Round(this System.DateTime dateTime, RoundTo rt)
        {
            System.DateTime rounded;

            switch (rt)
            {
                case RoundTo.Second:
                    {
                        rounded = new System.DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Kind);
                        if (dateTime.Millisecond >= 500)
                        {
                            rounded = rounded.AddSeconds(1);
                        }
                        break;
                    }
                case RoundTo.Minute:
                    {
                        rounded = new System.DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Kind);
                        if (dateTime.Second >= 30)
                        {
                            rounded = rounded.AddMinutes(1);
                        }
                        break;
                    }
                case RoundTo.Hour:
                    {
                        rounded = new System.DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Kind);
                        if (dateTime.Minute >= 30)
                        {
                            rounded = rounded.AddHours(1);
                        }
                        break;
                    }
                case RoundTo.Day:
                    {
                        rounded = new System.DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
                        if (dateTime.Hour >= 12)
                        {
                            rounded = rounded.AddDays(1);
                        }
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("rt");
                    }
            }

            return rounded;
        }

        /// <summary>
        /// Returns a DateTime adjusted to the beginning of the week.
        /// </summary>
        /// <param name="dateTime">The DateTime to adjust</param>
        /// <returns>A DateTime instance adjusted to the beginning of the current week</returns>
        /// <remarks>the beginning of the week is controlled by the current Culture</remarks>
        public static System.DateTime FirstDayOfWeek(this System.DateTime dateTime)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var firstDayOfWeek = currentCulture.DateTimeFormat.FirstDayOfWeek;
            var offset = dateTime.DayOfWeek - firstDayOfWeek < 0 ? 7 : 0;
            var numberOfDaysSinceBeginningOfTheWeek = dateTime.DayOfWeek + offset - firstDayOfWeek;

            return dateTime.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
        }

        /// <summary>
        /// Obsolete. This method has been renamed to FirstDayOfWeek to be more consistent with existing conventions.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        [Obsolete("This method has been renamed to FirstDayOfWeek to be more consistent with existing conventions.")]
        public static System.DateTime StartOfWeek(this System.DateTime dateTime)
        {
            return FirstDayOfWeek(dateTime);
        }

        /// <summary>
        /// Returns the first day of the year keeping the time component intact. Eg, 2011-02-04T06:40:20.005 => 2011-01-01T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTime to adjust</param>
        /// <returns></returns>
        public static System.DateTime FirstDayOfYear(this System.DateTime current)
        {
            return current.SetDate(current.Year, 1, 1);
        }

        /// <summary>
        /// Returns the last day of the week keeping the time component intact. Eg, 2011-12-24T06:40:20.005 => 2011-12-25T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTime to adjust</param>
        /// <returns></returns>
        public static System.DateTime LastDayOfWeek(this System.DateTime current)
        {
            return current.FirstDayOfWeek().AddDays(6);
        }

        /// <summary>
        /// Returns the last day of the year keeping the time component intact. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTime to adjust</param>
        /// <returns></returns>
        public static System.DateTime LastDayOfYear(this System.DateTime current)
        {
            return current.SetDate(current.Year, 12, 31);
        }

        /// <summary>
        /// Returns the previous month keeping the time component intact. Eg, 2010-01-20T06:40:20.005 => 2009-12-20T06:40:20.005
        /// If the previous month doesn't have that many days the last day of the previous month is used. Eg, 2009-03-31T06:40:20.005 => 2009-02-28T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTime to adjust</param>
        /// <returns></returns>
        public static System.DateTime PreviousMonth(this System.DateTime current)
        {
            var year = current.Month == 1 ? current.Year - 1 : current.Year;

            var month = current.Month == 1 ? 12 : current.Month - 1;

            var firstDayOfPreviousMonth = current.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfPreviousMonth.LastDayOfMonth().Day;

            var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

            return firstDayOfPreviousMonth.SetDay(day);
        }

        /// <summary>
        /// Returns the next month keeping the time component intact. Eg, 2012-12-05T06:40:20.005 => 2013-01-05T06:40:20.005
        /// If the next month doesn't have that many days the last day of the next month is used. Eg, 2013-01-31T06:40:20.005 => 2013-02-28T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTime to adjust</param>
        /// <returns></returns>
        public static System.DateTime NextMonth(this System.DateTime current)
        {

            var year = current.Month == 12 ? current.Year + 1 : current.Year;

            var month = current.Month == 12 ? 1 : current.Month + 1;

            var firstDayOfNextMonth = current.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

            var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

            return firstDayOfNextMonth.SetDay(day);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTime"/> value is exactly the same day (day + month + year) then current
        /// </summary>
        /// <param name="current">The current value</param>
        /// <param name="date">Value to compare with</param>
        /// <returns>
        /// 	<c>true</c> if the specified date is exactly the same year then current; otherwise, <c>false</c>.
        /// </returns>
        public static bool SameDay(this System.DateTime current, System.DateTime date)
        {
            return current.Date == date.Date;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTime"/> value is exactly the same month (month + year) then current. Eg, 2015-12-01 and 2014-12-01 => False
        /// </summary>
        /// <param name="current">The current value</param>
        /// <param name="date">Value to compare with</param>
        /// <returns>
        /// 	<c>true</c> if the specified date is exactly the same month and year then current; otherwise, <c>false</c>.
        /// </returns>
        public static bool SameMonth(this System.DateTime current, System.DateTime date)
        {
            return current.Month == date.Month && current.Year == date.Year;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTime"/> value is exactly the same year then current. Eg, 2015-12-01 and 2015-01-01 => True
        /// </summary>
        /// <param name="current">The current value</param>
        /// <param name="date">Value to compare with</param>
        /// <returns>
        /// 	<c>true</c> if the specified date is exactly the same date then current; otherwise, <c>false</c>.
        /// </returns>
        public static bool SameYear(this System.DateTime current, System.DateTime date)
        {
            return current.Year == date.Year;
        }


        /// <summary>
        /// Create a random date in future of a given date
        /// </summary>
        /// <param name="self"></param>
        /// <param name="max">Maximum date</param>
        /// <returns>A date in the future</returns>
        public static System.DateTime RandomDateInFuture(this System.DateTime self, System.DateTime max)
        {
	        var gen = new Random(System.DateTime.Now.Millisecond);
	        var range = (max - self).Days;

	        return self.AddDays(gen.Next(range));
        }


				/// <summary>
				/// Create a random date in past of a given date
				/// </summary>
				/// <param name="self"></param>
				/// <param name="min">Miminum date</param>
				/// <returns>A date in the past</returns>
        public static System.DateTime RandomDateInPast(this System.DateTime self, System.DateTime min)
        {
	        var gen = new Random(System.DateTime.Now.Millisecond);
	        var range = (self - min).Days;

	        return min.AddDays(gen.Next(range));
        }


        /// <summary>
        /// Get UTC offset in minutes of a given local date
        /// </summary>
        /// <param name="self"></param>
        /// <returns>UTC offset in minutes</returns>
        public static int UtcOffsetInMinutes(this System.DateTime self)
        {
	        return (int) TimeZoneInfo.Local.GetUtcOffset(System.DateTime.Now).TotalMinutes;
        }
	}
}