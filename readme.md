# <img src="/src/icon.png" height="30px"> FluentDateTime

Allows cleaner DateTime expressions and operations.

Inspired by Ruby DateTime Extensions

 * [Extensions To Datetime](http://edgeguides.rubyonrails.org/active_support_core_extensions.html#extensions-to-datetime)
 * [Extensions To Time](http://edgeguides.rubyonrails.org/active_support_core_extensions.html#extensions-to-time)


## Usage

Here is some examples of use cases

```csharp
// DateTime operations
DateTime.Now  - 1.Weeks() - 3.Days() + 14.Minutes()
DateTime.Now  + 5.Years()

// Relative DateTime evaluations
3.Days().Ago()
2.Days().Since(DateTime.Now)

// Fluent DateTime estimations
DateTime.Now.NextDay()
DateTime.Now.NextYear()
DateTime.Now.PreviousYear()
DateTime.Now.WeekAfter()
DateTime.Now.Midnight()
DateTime.Now.Noon()

// Current DateTime manipulation
DateTime.Now.SetTime(11, 55, 0)
```

_See [Unit Tests](https://github.com/FluentDateTime/FluentDateTime/tree/master/src/Tests) in the project for more details._


## Icon

[Calendar](http://thenounproject.com/noun/calendar/#icon-No404) from The Noun Project
