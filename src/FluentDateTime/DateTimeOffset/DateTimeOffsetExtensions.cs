using System;
using System.Globalization;

namespace holonsoft.FluentDateTime.DateTimeOffset
{
    /// <summary>
    /// Static class containing Fluent <see cref="DateTimeOffset"/> extension methods.
    /// </summary>
    public static class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the value of the specified <see cref="FluentTimeSpan"/> to the value of this instance.
        /// </summary>
        public static System.DateTimeOffset AddFluentTimeSpan(this System.DateTimeOffset dateTimeOffset, FluentTimeSpan timeSpan)
        {
            return dateTimeOffset.AddMonths(timeSpan.Months)
                .AddYears(timeSpan.Years)
                .Add(timeSpan.TimeSpan);
        }

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that subtracts the value of the specified <see cref="FluentTimeSpan"/> to the value of this instance.
        /// </summary>
        public static System.DateTimeOffset SubtractFluentTimeSpan(this System.DateTimeOffset dateTimeOffset, FluentTimeSpan timeSpan)
        {
            return dateTimeOffset.AddMonths(-timeSpan.Months)
                .AddYears(-timeSpan.Years)
                .Subtract(timeSpan.TimeSpan);
        }

        /// <summary>
        /// Returns the very end of the given day (the last millisecond of the last hour for the given <see cref="DateTimeOffset"/>).
        /// </summary>
        public static System.DateTimeOffset EndOfDay(this System.DateTimeOffset date)
        {
            return new System.DateTimeOffset(date.Year, date.Month, date.Day, 23, 59, 59, 999, date.Offset);
        }

        /// <summary>
        /// Returns the Start of the given day (the first millisecond of the given <see cref="DateTimeOffset"/>).
        /// </summary>
        public static System.DateTimeOffset BeginningOfDay(this System.DateTimeOffset date)
        {
            return new System.DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);
        }

        /// <summary>
        /// Returns the same date (same Day, Month, Hour, Minute, Second etc) in the next calendar year.
        /// If that day does not exist in next year in same month, number of missing days is added to the last day in same month next year.
        /// </summary>
        public static System.DateTimeOffset NextYear(this System.DateTimeOffset start)
        {
            var nextYear = start.Year + 1;
            var numberOfDaysInSameMonthNextYear = System.DateTime.DaysInMonth(nextYear, start.Month);

            if (numberOfDaysInSameMonthNextYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthNextYear;
                var dateTimeOffset = new System.DateTimeOffset(nextYear, start.Month, numberOfDaysInSameMonthNextYear, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
                return dateTimeOffset + differenceInDays.Days();
            }
            return new System.DateTimeOffset(nextYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
        }

        /// <summary>
        /// Returns the same date (same Day, Month, Hour, Minute, Second etc) in the previous calendar year.
        /// If that day does not exist in previous year in same month, number of missing days is added to the last day in same month previous year.
        /// </summary>
        public static System.DateTimeOffset PreviousYear(this System.DateTimeOffset start)
        {
            var previousYear = start.Year - 1;
            var numberOfDaysInSameMonthPreviousYear = System.DateTime.DaysInMonth(previousYear, start.Month);

            if (numberOfDaysInSameMonthPreviousYear < start.Day)
            {
                var differenceInDays = start.Day - numberOfDaysInSameMonthPreviousYear;
                var dateTime = new System.DateTimeOffset(previousYear, start.Month, numberOfDaysInSameMonthPreviousYear, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
                return dateTime + differenceInDays.Days();
            }
            return new System.DateTimeOffset(previousYear, start.Month, start.Day, start.Hour, start.Minute, start.Second, start.Millisecond, start.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> increased by 24 hours ie Next Day.
        /// </summary>
        public static System.DateTimeOffset NextDay(this System.DateTimeOffset start)
        {
            return start + 1.Days();
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> decreased by 24h period ie Previous Day.
        /// </summary>
        public static System.DateTimeOffset PreviousDay(this System.DateTimeOffset start)
        {
            return start - 1.Days();
        }

        /// <summary>
        /// Returns first next occurrence of specified <see cref="DayOfWeek"/>.
        /// </summary>
        public static System.DateTimeOffset Next(this System.DateTimeOffset start, DayOfWeek day)
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
        public static System.DateTimeOffset Previous(this System.DateTimeOffset start, DayOfWeek day)
        {
            do
            {
                start = start.PreviousDay();
            } while (start.DayOfWeek != day);

            return start;
        }

        /// <summary>
        /// Increases supplied <see cref="DateTimeOffset"/> for 7 days ie returns the Next Week.
        /// </summary>
        public static System.DateTimeOffset WeekAfter(this System.DateTimeOffset start)
        {
            return start + 1.Weeks();
        }

        /// <summary>
        /// Decreases supplied <see cref="DateTimeOffset"/> for 7 days ie returns the Previous Week.
        /// </summary>
        public static System.DateTimeOffset WeekEarlier(this System.DateTimeOffset start)
        {
            return start - 1.Weeks();
        }

        /// <summary>
        /// Increases the <see cref="DateTimeOffset"/> object with given <see cref="TimeSpan"/> value.
        /// </summary>
        public static System.DateTimeOffset IncreaseTime(this System.DateTimeOffset startDate, TimeSpan toAdd)
        {
            return startDate + toAdd;
        }

        /// <summary>
        /// Decreases the <see cref="DateTimeOffset"/> object with given <see cref="TimeSpan"/> value.
        /// </summary>
        public static System.DateTimeOffset DecreaseTime(this System.DateTimeOffset startDate, TimeSpan toSubtract)
        {
            return startDate - toSubtract;
        }

        /// <summary>
        /// Returns the original <see cref="DateTimeOffset"/> with Hour part changed to supplied hour parameter.
        /// </summary>
        public static System.DateTimeOffset SetTime(this System.DateTimeOffset originalDate, int hour)
        {
            return new System.DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Returns the original <see cref="DateTimeOffset"/> with Hour and Minute parts changed to supplied hour and minute parameters.
        /// </summary>
        public static System.DateTimeOffset SetTime(this System.DateTimeOffset originalDate, int hour, int minute)
        {
            return new System.DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Returns the original <see cref="DateTimeOffset"/> with Hour, Minute and Second parts changed to supplied hour, minute and second parameters.
        /// </summary>
        public static System.DateTimeOffset SetTime(this System.DateTimeOffset originalDate, int hour, int minute, int second)
        {
            return new System.DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Returns the original <see cref="DateTimeOffset"/> with Hour, Minute, Second and Millisecond parts changed to supplied hour, minute, second and millisecond parameters.
        /// </summary>
        public static System.DateTimeOffset SetTime(this System.DateTimeOffset originalDate, int hour, int minute, int second, int millisecond)
        {
            return new System.DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Hour part.
        /// </summary>
        public static System.DateTimeOffset SetHour(this System.DateTimeOffset originalDate, int hour)
        {
            return new System.DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Minute part.
        /// </summary>
        public static System.DateTimeOffset SetMinute(this System.DateTimeOffset originalDate, int minute)
        {
            return new System.DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Second part.
        /// </summary>
        public static System.DateTimeOffset SetSecond(this System.DateTimeOffset originalDate, int second)
        {
            return new System.DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Millisecond part.
        /// </summary>
        public static System.DateTimeOffset SetMillisecond(this System.DateTimeOffset originalDate, int millisecond)
        {
            return new System.DateTimeOffset(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, originalDate.Second, millisecond, originalDate.Offset);
        }

        /// <summary>
        /// Returns original <see cref="DateTimeOffset"/> value with time part set to midnight (alias for <see cref="BeginningOfDay"/> method).
        /// </summary>
        public static System.DateTimeOffset Midnight(this System.DateTimeOffset value)
        {
            return value.BeginningOfDay();
        }

        /// <summary>
        /// Returns original <see cref="DateTimeOffset"/> value with time part set to Noon (12:00:00h).
        /// </summary>
        /// <param name="value">The <see cref="DateTimeOffset"/> find Noon for.</param>
        /// <returns>A <see cref="DateTimeOffset"/> value with time part set to Noon (12:00:00h).</returns>
        public static System.DateTimeOffset Noon(this System.DateTimeOffset value)
        {
            return value.SetTime(12, 0, 0, 0);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Year part.
        /// </summary>
        public static System.DateTimeOffset SetDate(this System.DateTimeOffset value, int year)
        {
            return new System.DateTimeOffset(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Year and Month part.
        /// </summary>
        public static System.DateTimeOffset SetDate(this System.DateTimeOffset value, int year, int month)
        {
            return new System.DateTimeOffset(year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Year, Month and Day part.
        /// </summary>
        public static System.DateTimeOffset SetDate(this System.DateTimeOffset value, int year, int month, int day)
        {
            return new System.DateTimeOffset(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Year part.
        /// </summary>
        public static System.DateTimeOffset SetYear(this System.DateTimeOffset value, int year)
        {
            return new System.DateTimeOffset(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Month part.
        /// </summary>
        public static System.DateTimeOffset SetMonth(this System.DateTimeOffset value, int month)
        {
            return new System.DateTimeOffset(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Returns <see cref="DateTimeOffset"/> with changed Day part.
        /// </summary>
        public static System.DateTimeOffset SetDay(this System.DateTimeOffset value, int day)
        {
            return new System.DateTimeOffset(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Offset);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTimeOffset"/> is before then current value.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="toCompareWith">Value to compare with.</param>
        /// <returns>
        /// 	<c>true</c> if the specified current is before; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBefore(this System.DateTimeOffset current, System.DateTimeOffset toCompareWith)
        {
            return current < toCompareWith;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTimeOffset"/> value is After then current value.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="toCompareWith">Value to compare with.</param>
        /// <returns>
        /// 	<c>true</c> if the specified current is after; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAfter(this System.DateTimeOffset current, System.DateTimeOffset toCompareWith)
        {
            return current > toCompareWith;
        }

        /// <summary>
        /// Returns the given <see cref="DateTimeOffset"/> with hour and minutes set At given values.
        /// </summary>
        /// <param name="current">The current <see cref="DateTimeOffset"/> to be changed.</param>
        /// <param name="hour">The hour to set time to.</param>
        /// <param name="minute">The minute to set time to.</param>
        /// <returns><see cref="DateTimeOffset"/> with hour and minute set to given values.</returns>
        public static System.DateTimeOffset At(this System.DateTimeOffset current, int hour, int minute)
        {
            return current.SetTime(hour, minute);
        }

        /// <summary>
        /// Returns the given <see cref="DateTimeOffset"/> with hour and minutes and seconds set At given values.
        /// </summary>
        /// <param name="current">The current <see cref="DateTimeOffset"/> to be changed.</param>
        /// <param name="hour">The hour to set time to.</param>
        /// <param name="minute">The minute to set time to.</param>
        /// <param name="second">The second to set time to.</param>
        /// <returns><see cref="DateTimeOffset"/> with hour and minutes and seconds set to given values.</returns>
        public static System.DateTimeOffset At(this System.DateTimeOffset current, int hour, int minute, int second)
        {
            return current.SetTime(hour, minute, second);
        }

        /// <summary>
        /// Returns the given <see cref="DateTimeOffset"/> with hour and minutes and seconds and milliseconds set At given values.
        /// </summary>
        /// <param name="current">The current <see cref="DateTimeOffset"/> to be changed.</param>
        /// <param name="hour">The hour to set time to.</param>
        /// <param name="minute">The minute to set time to.</param>
        /// <param name="second">The second to set time to.</param>
        /// <param name="milliseconds">The milliseconds to set time to.</param>
        /// <returns><see cref="DateTimeOffset"/> with hour and minutes and seconds set to given values.</returns>
        public static System.DateTimeOffset At(this System.DateTimeOffset current, int hour, int minute, int second, int milliseconds)
        {
            return current.SetTime(hour, minute, second, milliseconds);
        }

        /// <summary>
        /// Sets the day of the <see cref="DateTimeOffset"/> to the first day in that calendar quarter.
        /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html
        /// </summary>
        /// <param name="current"></param>
        /// <returns>given <see cref="DateTimeOffset"/> with the day part set to the first day in the quarter.</returns>
        public static System.DateTimeOffset FirstDayOfQuarter(this System.DateTimeOffset current)
        {
            var currentQuarter = (current.Month - 1) / 3 + 1;
            return current.SetDate(current.Year, 3 * currentQuarter - 2, 1);
        }

        /// <summary>
        /// Sets the day of the <see cref="DateTimeOffset"/> to the first day in that month.
        /// </summary>
        /// <param name="current">The current <see cref="DateTimeOffset"/> to be changed.</param>
        /// <returns>given <see cref="DateTimeOffset"/> with the day part set to the first day in that month.</returns>
        public static System.DateTimeOffset FirstDayOfMonth(this System.DateTimeOffset current)
        {
            return current.SetDay(1);
        }

        /// <summary>
        /// Sets the day of the <see cref="DateTimeOffset"/> to the last day in that calendar quarter.
        /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html
        /// </summary>
        /// <param name="current"></param>
        /// <returns>given <see cref="DateTimeOffset"/> with the day part set to the last day in the quarter.</returns>
        public static System.DateTimeOffset LastDayOfQuarter(this System.DateTimeOffset current)
        {
            var currentQuarter = (current.Month - 1) / 3 + 1;
            var firstDay = current.SetDate(current.Year, 3 * currentQuarter - 2, 1);
            return firstDay.SetMonth(firstDay.Month + 2).LastDayOfMonth();
        }

        /// <summary>
        /// Sets the day of the <see cref="DateTimeOffset"/> to the last day in that month.
        /// </summary>
        /// <param name="current">The current DateTimeOffset to be changed.</param>
        /// <returns>given <see cref="DateTimeOffset"/> with the day part set to the last day in that month.</returns>
        public static System.DateTimeOffset LastDayOfMonth(this System.DateTimeOffset current)
        {
            return current.SetDay(System.DateTime.DaysInMonth(current.Year, current.Month));
        }

        /// <summary>
        /// Adds the given number of business days to the <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be added.</param>
        /// <returns>A <see cref="DateTimeOffset"/> increased by a given number of business days.</returns>
        public static System.DateTimeOffset AddBusinessDays(this System.DateTimeOffset current, int days)
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
        /// Subtracts the given number of business days to the <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="current">The date to be changed.</param>
        /// <param name="days">Number of business days to be subtracted.</param>
        /// <returns>A <see cref="DateTimeOffset"/> increased by a given number of business days.</returns>
        public static System.DateTimeOffset SubtractBusinessDays(this System.DateTimeOffset current, int days)
        {
            return AddBusinessDays(current, -days);
        }

        /// <summary>
        /// Determine if a <see cref="DateTimeOffset"/> is in the future.
        /// </summary>
        /// <param name="dateTime">The date to be checked.</param>
        /// <returns><c>true</c> if <paramref name="dateTime"/> is in the future; otherwise <c>false</c>.</returns>
        public static bool IsInFuture(this System.DateTimeOffset dateTime)
        {
            return dateTime > System.DateTimeOffset.Now;
        }

        /// <summary>
        /// Determine if a <see cref="DateTimeOffset"/> is in the past.
        /// </summary>
        /// <param name="dateTime">The date to be checked.</param>
        /// <returns><c>true</c> if <paramref name="dateTime"/> is in the past; otherwise <c>false</c>.</returns>
        public static bool IsInPast(this System.DateTimeOffset dateTime)
        {
            return dateTime < System.DateTimeOffset.Now;
        }

        /// <summary>
        /// Rounds <paramref name="dateTime"/> to the nearest <see cref="RoundTo"/>.
        /// </summary>
        /// <returns>The rounded <see cref="DateTimeOffset"/>.</returns>
        public static System.DateTimeOffset Round(this System.DateTimeOffset dateTime, RoundTo rt)
        {
            System.DateTimeOffset rounded;

            switch (rt)
            {
                case RoundTo.Second:
                    {
                        rounded = new System.DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Offset);
                        if (dateTime.Millisecond >= 500)
                        {
                            rounded = rounded.AddSeconds(1);
                        }
                        break;
                    }
                case RoundTo.Minute:
                    {
                        rounded = new System.DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Offset);
                        if (dateTime.Second >= 30)
                        {
                            rounded = rounded.AddMinutes(1);
                        }
                        break;
                    }
                case RoundTo.Hour:
                    {
                        rounded = new System.DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Offset);
                        if (dateTime.Minute >= 30)
                        {
                            rounded = rounded.AddHours(1);
                        }
                        break;
                    }
                case RoundTo.Day:
                    {
                        rounded = new System.DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Offset);
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
        /// Returns a DateTimeOffset adjusted to the beginning of the week.
        /// </summary>
        /// <param name="dateTime">The DateTimeOffset to adjust</param>
        /// <returns>A DateTimeOffset instance adjusted to the beginning of the current week</returns>
        /// <remarks>the beginning of the week is controlled by the current Culture</remarks>
        public static System.DateTimeOffset FirstDayOfWeek(this System.DateTimeOffset dateTime)
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
        public static System.DateTimeOffset StartOfWeek(this System.DateTimeOffset dateTime)
        {
            return FirstDayOfWeek(dateTime);
        }

        /// <summary>
        /// Returns the first day of the year keeping the time component intact. Eg, 2011-02-04T06:40:20.005 => 2011-01-01T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTimeOffset to adjust</param>
        /// <returns></returns>
        public static System.DateTimeOffset FirstDayOfYear(this System.DateTimeOffset current)
        {
            return current.SetDate(current.Year, 1, 1);
        }

        /// <summary>
        /// Returns the last day of the week keeping the time component intact. Eg, 2011-12-24T06:40:20.005 => 2011-12-25T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTimeOffset to adjust</param>
        /// <returns></returns>
        public static System.DateTimeOffset LastDayOfWeek(this System.DateTimeOffset current)
        {
            return current.FirstDayOfWeek().AddDays(6);
        }

        /// <summary>
        /// Returns the last day of the year keeping the time component intact. Eg, 2011-12-24T06:40:20.005 => 2011-12-31T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTimeOffset to adjust</param>
        /// <returns></returns>
        public static System.DateTimeOffset LastDayOfYear(this System.DateTimeOffset current)
        {
            return current.SetDate(current.Year, 12, 31);
        }

        /// <summary>
        /// Returns the previous month keeping the time component intact. Eg, 2010-01-20T06:40:20.005 => 2009-12-20T06:40:20.005
        /// If the previous month doesn't have that many days the last day of the previous month is used. Eg, 2009-03-31T06:40:20.005 => 2009-02-28T06:40:20.005
        /// </summary>
        /// <param name="current">The DateTimeOffset to adjust</param>
        /// <returns></returns>
        public static System.DateTimeOffset PreviousMonth(this System.DateTimeOffset current)
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
        /// <param name="current">The DateTimeOffset to adjust</param>
        /// <returns></returns>
        public static System.DateTimeOffset NextMonth(this System.DateTimeOffset current)
        {

            var year = current.Month == 12 ? current.Year + 1 : current.Year;

            var month = current.Month == 12 ? 1 : current.Month + 1;

            var firstDayOfNextMonth = current.SetDate(year, month, 1);

            var lastDayOfPreviousMonth = firstDayOfNextMonth.LastDayOfMonth().Day;

            var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

            return firstDayOfNextMonth.SetDay(day);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTimeOffset"/> value is exactly the same day (day + month + year) then current
        /// </summary>
        /// <param name="current">The current value</param>
        /// <param name="date">Value to compare with</param>
        /// <returns>
        /// 	<c>true</c> if the specified date is exactly the same year then current; otherwise, <c>false</c>.
        /// </returns>
        public static bool SameDay(this System.DateTimeOffset current, System.DateTimeOffset date)
        {
            return current.Date == date.Date;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTimeOffset"/> value is exactly the same month (month + year) then current. Eg, 2015-12-01 and 2014-12-01 => False
        /// </summary>
        /// <param name="current">The current value</param>
        /// <param name="date">Value to compare with</param>
        /// <returns>
        /// 	<c>true</c> if the specified date is exactly the same month and year then current; otherwise, <c>false</c>.
        /// </returns>
        public static bool SameMonth(this System.DateTimeOffset current, System.DateTimeOffset date)
        {
            return current.Month == date.Month && current.Year == date.Year;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DateTimeOffset"/> value is exactly the same year then current. Eg, 2015-12-01 and 2015-01-01 => True
        /// </summary>
        /// <param name="current">The current value</param>
        /// <param name="date">Value to compare with</param>
        /// <returns>
        /// 	<c>true</c> if the specified date is exactly the same date then current; otherwise, <c>false</c>.
        /// </returns>
        public static bool SameYear(this System.DateTimeOffset current, System.DateTimeOffset date)
        {
            return current.Year == date.Year;
        }
    }
}