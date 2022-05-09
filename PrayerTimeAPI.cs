namespace API
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Windows.Devices.Geolocation;
    public class PrayerTimeAPI
    {
        public List<PrayerTimeIdentification> GetPrayerTimes()
        {
            List<PrayerTimeIdentification> prayerTimes = new();

            Geolocator locator = new();
            GeolocationAccessStatus status = Geolocator.RequestAccessAsync().GetAwaiter().GetResult();
            if (status == GeolocationAccessStatus.Allowed)
            {
                Geoposition pos = locator.GetGeopositionAsync().GetAwaiter().GetResult();
                Uri allprayertimes = new Uri($@"https://www.moonsighting.com/time_json.php?year={DateTime.Now.Year}&tz=Europe/London&lat={pos.Coordinate.Latitude}&lon={pos.Coordinate.Longitude}&method=0&both=false&time=0");
                var responseJSON = new HttpClient().GetStringAsync(allprayertimes).Result;
                using (var sr = new StringReader(responseJSON))
                using (var jr = new JsonTextReader(sr))
                {
                    var serial = new JsonSerializer { Formatting = Formatting.Indented };
                    var obj = serial.Deserialize<Response>(jr);
                    foreach (var i in obj.times)
                    {
                        prayerTimes.Add(new PrayerTimeIdentification(i["day"].ToString().Trim(), i["times"]["fajr"].ToString().Trim(), i["times"]["sunrise"].ToString().Trim(), i["times"]["dhuhr"].ToString().Trim(), i["times"]["asr"].ToString().Trim(), i["times"]["maghrib"].ToString().Trim(), i["times"]["isha"].ToString().Trim()));
                    }
                    return prayerTimes;
                }
            }
            return null;
        }
    }
}