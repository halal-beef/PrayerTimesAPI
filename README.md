# PrayerTimesAPI

This is based off the work of [these people](https://github.com/prayertimeresearch) so jazakallahu khaiyran to them

Right now it only supprts the london time zone if anyone can help me put it to other timezones it'll be appreciated

# Support Status

Windows 10 **Strictly** This is because of the location API I used from Microsoft

# Requirements

Your computer to have location services turned on
Have internet access
Be on the latest build of windows 10

# Usage

```csharp
using API;

Console.WriteLine("hello");
PrayerTimeAPI api = new();

foreach(PrayerTimeIdentification i in api.GetPrayerTimes())
{
    Console.WriteLine($"Day: {i.Day}    Fajr: {i.FajrTime}    Sunrise: {i.SunriseTime}    Zuhr: {i.ZuhrTime}    Asr: {i.AsrTime}    Maghrib: {i.MaghribTime}    Isha: {i.IshaTime}");
}

Thread.Sleep(-1);
```
