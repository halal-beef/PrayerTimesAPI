using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class PrayerTimeIdentification
    {
        public string Day;
        public string FajrTime;
        public string SunriseTime;
        public string ZuhrTime;
        public string AsrTime;
        public string MaghribTime;
        public string IshaTime;

        public PrayerTimeIdentification(string day, string fajrtime, string sunrisetime, string zuhrtime, string asrtime, string maghribtime, string ishatime) => (Day, FajrTime, SunriseTime, ZuhrTime, AsrTime, MaghribTime, IshaTime) = (day, fajrtime, sunrisetime, zuhrtime, asrtime, maghribtime, ishatime);
    }
}
