using System.ComponentModel.DataAnnotations;
namespace Morrowmere.Domain.Models
{
    public class SimulationClock
    {
        public int Day { get; private set; } = 1;
        [Range(0, 23)]
        public int Hour { get; private set; } = 1;

        public SimulationClock(int day, int hour)
        {

            if (day < 1)
                throw new ArgumentOutOfRangeException(nameof(day));

            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour));

            Day = day;
            Hour = hour;

            Day = day;
            Hour = hour;
        }

        public void AdvanceTime()
        {
            Hour++;

            if (Hour > 23)
            {
                Hour = 0;
                Day++;
            }
        }
    }
}
