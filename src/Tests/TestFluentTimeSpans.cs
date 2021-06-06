using System;
using Xunit;
using holonsoft.FluentDateTime;
using holonsoft.FluentDateTime.DateTime;


namespace Tests
{
	public class TestFluentTimeSpans
	{
		[Theory]
		[InlineData(1)]
		[InlineData(32)]
		[InlineData(100)]
		[InlineData(1000)]
		[InlineData(-1)]
		[InlineData(-100)]
		[InlineData(0)]
		public void Years_Months_Weeks_Days_Hours_Minutes_Seconds_Milliseconds_SimpleTests(int value)
		{
			Assert.Equal(value.Years(), new FluentTimeSpan
			{
				Years = value
			});
			Assert.Equal(value.Months(), new FluentTimeSpan
			{
				Months = value
			});
			Assert.Equal(value.Weeks(), new FluentTimeSpan
			{
				TimeSpan = TimeSpan.FromDays(value*7)
			});
			Assert.Equal(value.Days(), new FluentTimeSpan
			{
				TimeSpan = TimeSpan.FromDays(value)
			});

			Assert.Equal(value.Hours(), new FluentTimeSpan
			{
				TimeSpan = TimeSpan.FromHours(value)
			});
			Assert.Equal(value.Minutes(), new FluentTimeSpan
			{
				TimeSpan = TimeSpan.FromMinutes(value)
			});
			Assert.Equal(value.Seconds(), new FluentTimeSpan
			{
				TimeSpan = TimeSpan.FromSeconds(value)
			});
			Assert.Equal(value.Milliseconds(), new FluentTimeSpan
			{
				TimeSpan = TimeSpan.FromMilliseconds(value)
			});
			Assert.Equal(value.Ticks(), new FluentTimeSpan
			{
				TimeSpan = TimeSpan.FromTicks(value)
			});
		}

		[Fact]
		public void Subtract()
		{
			var halfDay = .5.Days();
			Assert.Equal(3, 3.5.Days().Subtract(halfDay).Days);
			var timeSpan = new TimeSpan(3, 12, 0, 0);
			Assert.Equal(3, timeSpan.SubtractFluentTimeSpan(halfDay).Days);
			Assert.Equal(3, (timeSpan - halfDay).Days);
			Assert.Equal(-3, (halfDay - timeSpan).Days);
		}

		[Fact]
		public void GetHashCodeTest()
		{
			Assert.Equal(343024320, 3.5.Days().GetHashCode());
		}

		[Fact]
		public void CompareToFluentTimeSpan()
		{
			Assert.Equal(0, 3.Days().CompareTo(3.Days()));
			Assert.Equal(-1, 3.Days().CompareTo(4.Days()));
			Assert.Equal(1, 4.Days().CompareTo(3.Days()));
		}

		[Fact]
		public void CompareToTimeSpan()
		{
			Assert.Equal(0, 3.Days().CompareTo(TimeSpan.FromDays(3)));
			Assert.Equal(-1, 3.Days().CompareTo(TimeSpan.FromDays(4)));
			Assert.Equal(1, 4.Days().CompareTo(TimeSpan.FromDays(3)));
		}

		[Fact]
		public void CompareToObject()
		{
			Assert.Equal(0, 3.Days().CompareTo((object) TimeSpan.FromDays(3)));
			Assert.Equal(-1, 3.Days().CompareTo((object) TimeSpan.FromDays(4)));
			Assert.Equal(1, 4.Days().CompareTo((object) TimeSpan.FromDays(3)));
		}

		[Fact]
		public void EqualsFluentTimeSpan()
		{
			Assert.True((bool) 3.Days().Equals(3.Days()));
			Assert.False((bool) 4.Days().Equals(3.Days()));
		}

		[Fact]
		public void EqualsTimeSpan()
		{
			Assert.True((bool) 3.Days().Equals(TimeSpan.FromDays(3)));
			Assert.False((bool) 4.Days().Equals(TimeSpan.FromDays(3)));
		}

		[Fact]
		public void AreEquals()
		{
			// Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625
			Assert.False((bool) 3.Days().Equals(null));
#pragma warning restore CS8625
		}

		[Fact]
		public void EqualsTimeSpanAsObject()
		{
			Assert.True((bool) 3.Days().Equals((object) TimeSpan.FromDays(3)));
		}

		[Fact]
		public void EqualsObject()
		{
			Assert.False((bool) 3.Days().Equals(1));
		}

		[Fact]
		public void Add()
		{
			var halfDay = .5.Days();
			Assert.Equal(4, 3.5.Days().Add(halfDay).Days);
			var timeSpan = new TimeSpan(3,12,0,0);
			Assert.Equal(4, timeSpan.AddFluentTimeSpan(halfDay).Days);
			Assert.Equal(4, (timeSpan + halfDay).Days);
			Assert.Equal(4, (halfDay + timeSpan).Days);
		}

		[Fact]
		public void ToStringTest()
		{
			Assert.Equal((string) "3.12:00:00", (string) 3.5.Days().ToString());
		}

		[Fact]
		public void Clone()
		{
			var timeSpan = 3.Milliseconds();
			var clone = timeSpan.Clone();
			Assert.Equal(timeSpan, clone);
		}

		[Fact]
		public void Ticks()
		{
			Assert.Equal<long>(30000, 3.Milliseconds().Ticks);
		}

		[Fact]
		public void Milliseconds()
		{
			Assert.Equal(100, 1100.Milliseconds().Milliseconds);
		}

		[Fact]
		public void TotalMilliseconds()
		{
			Assert.Equal<double>(1100, 1100.Milliseconds().TotalMilliseconds);
		}

		[Fact]
		public void Seconds()
		{
			Assert.Equal(1, 61.Seconds().Seconds);
		}

		[Fact]
		public void TotalSeconds()
		{
			Assert.Equal<double>(61, 61.Seconds().TotalSeconds);
		}

		[Fact]
		public void Minutes()
		{
			Assert.Equal(1, 61.Minutes().Minutes);
		}

		[Fact]
		public void TotalMinutes()
		{
			Assert.Equal<double>(61, 61.Minutes().TotalMinutes);
		}

		[Fact]
		public void Hours()
		{
			Assert.Equal(1, 25.Hours().Hours);
		}

		[Fact]
		public void TotalHours()
		{
			Assert.Equal<double>(25, 25.Hours().TotalHours);
		}

		[Fact]
		public void Days()
		{
			Assert.Equal(366, 366.Days().Days);
		}

		[Fact]
		public void TotalDays()
		{
			Assert.Equal<double>(366, 366.Days().TotalDays);
		}

		[Fact]
		public void Years()
		{
			var fluentTimeSpan = 3.Years();
			Assert.Equal(3, fluentTimeSpan.Years);
		}

		[Fact]
		public void EnsureWhenConvertedIsCorrect()
		{
			TimeSpan timeSpan = 10.Years();
			Assert.Equal(3650d, timeSpan.TotalDays);
		}

		public class OperatorOverloads
		{
			[Fact]
			public void LessThan()
			{
				Assert.True((bool) (1.Seconds() < 2.Seconds()));
				Assert.True(1.Seconds() < TimeSpan.FromSeconds(2));
				Assert.True(TimeSpan.FromSeconds(1) < 2.Seconds());
			}

			[Fact]
			public void LessThanOrEqualTo()
			{
				Assert.True((bool) (1.Seconds() <= 2.Seconds()));
				Assert.True(1.Seconds() <= TimeSpan.FromSeconds(2));
				Assert.True(TimeSpan.FromSeconds(1) <= 2.Seconds());
			}

			[Fact]
			public void GreaterThan()
			{
				Assert.True((bool) (2.Seconds() > 1.Seconds()));
				Assert.True(2.Seconds() > TimeSpan.FromSeconds(1));
				Assert.True(TimeSpan.FromSeconds(2) > 1.Seconds());
			}

			[Fact]
			public void GreaterThanOrEqualTo()
			{
				Assert.True((bool) (2.Seconds() >= 1.Seconds()));
				Assert.True(2.Seconds() >= TimeSpan.FromSeconds(1));
				Assert.True(TimeSpan.FromSeconds(2) >= 1.Seconds());
			}

			[Fact]
			public void AreEquals()
			{
				Assert.True((bool) (2.Seconds() == 2.Seconds()));
				Assert.True(2.Seconds() == TimeSpan.FromSeconds(2));
				Assert.True(TimeSpan.FromSeconds(2) == 2.Seconds());
			}

			[Fact]
			public void NotEquals()
			{
				Assert.True((bool) (2.Seconds() != 1.Seconds()));
				Assert.True(2.Seconds() != TimeSpan.FromSeconds(1));
				Assert.True(TimeSpan.FromSeconds(2) != 1.Seconds());
			}

			[Fact]
			public void Add()
			{
				Assert.Equal(1.Seconds() + 2.Seconds(), 3.Seconds());
				Assert.Equal(1.Seconds() + TimeSpan.FromSeconds(2), 3.Seconds());
				Assert.Equal(TimeSpan.FromSeconds(1) + 2.Seconds(), 3.Seconds());
			}

			[Fact]
			public void Subtract()
			{
				Assert.Equal(1.Seconds() - 2.Seconds(), -1.Seconds());
				Assert.Equal(1.Seconds() - TimeSpan.FromSeconds(2), -1.Seconds());
				Assert.Equal(TimeSpan.FromSeconds(1) - 2.Seconds(), -1.Seconds());
			}
		}

		public class ToDisplayStringTests
		{
			[Fact]
			public void DaysHours()
			{
				var timeSpan = 2.Days() + 3.Hours();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "2 days and 3 hours", (string) displayString);
			}

			[Fact]
			public void DaysHoursRoundUp()
			{
				var timeSpan = 2.Days() + 3.Hours() + 30.Minutes();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "2 days and 4 hours", (string) displayString);
			}

			[Fact]
			public void DaysHoursRoundDown()
			{
				var timeSpan = 2.Days() + 3.Hours() + 9.Minutes();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "2 days and 3 hours", (string) displayString);
			}

			[Fact]
			public void HoursMinutes()
			{
				var timeSpan = 2.Hours() + 9.Minutes();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "2 hours and 9 minutes", (string) displayString);
			}

			[Fact]
			public void HoursMinutesRoundUp()
			{
				var timeSpan = 2.Hours() + 9.Minutes() + 30.Seconds();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "2 hours and 10 minutes", (string) displayString);
			}

			[Fact]
			public void HoursMinutesRoundDown()
			{
				var timeSpan = 2.Hours() + 9.Minutes() + 10.Seconds();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "2 hours and 9 minutes", (string) displayString);
			}

			[Fact]
			public void MinutesSeconds()
			{
				var timeSpan = 9.Minutes();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "9 minutes and 0 seconds", (string) displayString);
			}

			[Fact]
			public void MinutesSecondsRoundUp()
			{
				var timeSpan = 9.Minutes() + 30.5.Seconds();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "9 minutes and 31 seconds", (string) displayString);
			}

			[Fact]
			public void MinutesSecondsRoundDown()
			{
				var timeSpan = 9.Minutes() + 30.4.Seconds();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "9 minutes and 30 seconds", (string) displayString);
			}

			[Fact]
			public void SecondsMilliseconds()
			{
				var timeSpan = 9.Seconds();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "9 seconds", (string) displayString);
			}

			[Fact]
			public void SecondsMillisecondsRoundUp()
			{
				var timeSpan = 9.Seconds() + 500.Milliseconds();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal(9.5 + " seconds", (string) displayString);
			}

			[Fact]
			public void SecondsMillisecondsRoundDown()
			{
				var timeSpan = 9.Seconds() + 300.Milliseconds();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal(9.3 + " seconds", (string) displayString);
			}

			[Fact]
			public void Milliseconds()
			{
				var timeSpan = 9.Milliseconds();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "9 milliseconds", (string) displayString);
			}

			[Fact]
			public void ABitOverADay()
			{
				var timeSpan = 46.2.Hours();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "1 days and 22 hours", (string) displayString);
			}

			[Fact]
			public void ABitOverADay2()
			{
				var timeSpan = 46.9.Hours();
				var displayString = timeSpan.ToDisplayString();
				Assert.Equal((string) "1 days and 23 hours", (string) displayString);
			}
		}
	}
}