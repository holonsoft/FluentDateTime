// unset

using holonsoft.FluentDateTime.Dto;
using System;
using System.Globalization;
using Xunit;

namespace Tests
{
	public class TestCalendarWeek
	{
		[Fact]
		public void TestCalendarWeekSubtraction()
		{
			var result = new CalendarWeek(2015, 1) - new CalendarWeek(2015, 1);
			Assert.Equal(0, result);

			result = new CalendarWeek(2015, 2) - new CalendarWeek(2015, 1);
			Assert.Equal(1, result);

			result = new CalendarWeek(2013, 2) - new CalendarWeek(2015, 1);
			Assert.Equal(-103, result);

			result = new CalendarWeek(2015, 1) - new CalendarWeek(2014, 1);
			Assert.Equal(52, result);
		}


		[Fact]
		public void TestCalendarWeekWithConcreteDate()
		{
			var result1 = new CalendarWeek(new DateTime(2018, 1, 1), true);
			var result2 = new CalendarWeek(new DateTime(2018, 1, 1), false);
			Assert.Equal(result1, result2);
			Assert.True(result1 == result2);

			result1 = new CalendarWeek(2017, 1);
			Assert.NotEqual(result1, result2);

			Assert.True(result1 < result2);
			Assert.False(result1 > result2);

			Assert.True(result1 != null);
		}


		[Fact]
		public void TestCalendarWeekAddition()
		{
			var result1 = new CalendarWeek(new DateTime(2018, 1, 1), true);

			var result2 = result1.Add(CultureInfo.CurrentCulture, 3);
			var result3 = new CalendarWeek(2018, 4);
			Assert.Equal(result3, result2);

			result2 = result1.Add(CultureInfo.CurrentCulture, -1);
			result3 = new CalendarWeek(2017, 52);
			Assert.Equal(result3, result2);

			result2 = result1.Add(CultureInfo.CurrentCulture, -53);
			result3 = new CalendarWeek(2016, 52);
			Assert.Equal(result3, result2);

			result1 = new CalendarWeek(new DateTime(2021, 1, 1), true);
			result2 = result1.Add(CultureInfo.CurrentCulture, 0);
			result3 = new CalendarWeek(2020, 53);
			Assert.Equal(result3, result2);

			result1 = new CalendarWeek(new DateTime(2021, 1, 1), true);
			result2 = new CalendarWeek(CultureInfo.CurrentCulture, new DateTime(2021, 1, 1));
			Assert.Equal(result1, result2);
		}


		[Fact]
		public void TestCalenderWeekOperators()
		{
			var result1 = new CalendarWeek(new DateTime(2018, 1, 1), true);
			var result2 = new CalendarWeek(new DateTime(2018, 1, 1), true);

			Assert.True(result1 >= result2);
			Assert.True(result1 <= result2);
			Assert.True(result1 == result2);
			Assert.False(result1 > result2);
			Assert.False(result1 < result2);


			result2 = new CalendarWeek(new DateTime(2017, 12, 1), true);

			Assert.True(result1 >= result2);
			Assert.True(result1 > result2);
			Assert.False(result1 <= result2);
		}


		[Fact]
		public void TestCalendarWeekToString()
		{
			var result1 = new CalendarWeek(new DateTime(2018, 1, 1), true);

			Assert.Equal("2018/01", result1.ToString());
		}


		[Fact]
		public void TestStringToCalendarWeek1()
		{
			var result = new CalendarWeek("2018/01");
			Assert.True(result.Year == 2018 && result.Week == 1);

			result = new CalendarWeek("01/2018");
			Assert.True(result.Year == 2018 && result.Week == 1);
		}


		[Fact]
		public void TestStringToCalendarWeek2()
		{
			Assert.Throws<ArgumentException>(() => new CalendarWeek("2018/1"));
		}


		[Fact]
		public void TestStringToCalendarWeek3()
		{
			Assert.Throws<ArgumentException>(() => new CalendarWeek("20a8/1"));
		}

		[Fact]
		public void TestCalendarWeekNullComparison()
		{
			CalendarWeek cw = null;

			Assert.True(cw == null);


			cw = new CalendarWeek(2018, 1);
			Assert.False(cw == null);
			Assert.True(cw != null);
		}


		[Fact]
		public void TestGetMonday()
		{
			Assert.Equal(new DateTime(2012, 10, 8), new CalendarWeek(2012, 41).GetMonday());
			Assert.Equal(new DateTime(2016, 5, 16), new CalendarWeek(2016, 20).GetMonday());
			Assert.Equal(new DateTime(2015, 1, 12), new CalendarWeek(2015, 3).GetMonday());
			Assert.Equal(new DateTime(1992, 12, 21), new CalendarWeek(1992, 52).GetMonday());
			Assert.Equal(new DateTime(2016, 1, 4), new CalendarWeek(2016, 1).GetMonday());
			Assert.Equal(new DateTime(2016, 12, 26), new CalendarWeek(2016, 52).GetMonday());
			Assert.Equal(new DateTime(2013, 12, 30), new CalendarWeek(2014, 1).GetMonday());
		}
	}
}