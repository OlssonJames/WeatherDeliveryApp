# WeatherDeliveryApp

So, what does the weather have to do with your package showing up on time? Turns out, quite a bit. This little project checks the current weather for any location and tells you how much it might mess with delivery times.

Built while learning .NET Cloud Development, mostly out of curiosity (and a decent excuse to finally use Azure and Open-Meteo for something real).

What it actually does

You give it a latitude and longitude, it:

Asks Open-Meteo what's going on outside right now
Runs the weather through a very opinionated little rulebook
Hands you back a delay estimate, a risk level, and some friendly warnings

Ice on the roads? Expect delays. Gale-force winds? Also delays. Nice sunny day? Off you go, no excuses.

Tech stack
ASP.NET Core Web API (.NET, C#)
A sprinkle of HTML/CSS/JS on top so it's not just raw JSON staring back at you
Open-Meteo for the actual weather data
Dependency injection, async/await, and the usual .NET suspects

Fun facts from building this
Spent way too long debugging why the API kept returning weather for two completely different places at once. Turns out Swedish computers use commas for decimals, and the weather API very much did not appreciate that.
The frontend's HTML/CSS got a bit of AI help so I could spend my energy on the actual C# logic, which is 100% hand-written.
