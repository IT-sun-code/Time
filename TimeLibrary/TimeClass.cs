using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public class TimeClass
    {
        const int dayInSeconds = 60 * 60 * 24;
        const int hourInSeconds = 60 * 60;

        private int hours;
        public int Hours
        {
            get { return hours; }
            set
            {
                if (value < 0 || value > 23)
                    throw new ArgumentOutOfRangeException("Hours must be >= 0 or < 24");
                else hours = value;
            }
        }

        private int minutes;
        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0 || value >= 60)
                    throw new ArgumentOutOfRangeException("Minutes must be >= 0 or < 60");
                else minutes = value;
            }
        }

        private int seconds;
        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value < 0 || value >= 60)
                    throw new ArgumentOutOfRangeException("Seconds must be >= 0 or < 60");
                else seconds = value;
            }
        }

        public TimeClass()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }

        public TimeClass(TimeClass time)
        {
            Hours = time.Hours;
            Minutes = time.Minutes;
            Seconds = time.Seconds;
        }

        public TimeClass(int Hours, int Minutes, int Seconds)
        {
            this.Hours = Hours;
            this.Minutes = Minutes;
            this.Seconds = Seconds;
        }

        public void Input()
        {
            Hours = Convert.ToInt32(Console.ReadLine());
            Minutes = Convert.ToInt32(Console.ReadLine());
            Seconds = Convert.ToInt32(Console.ReadLine());
        }

        public override string ToString() =>
            $"{Hours}:{Minutes}:{Seconds}";

        public int GetTimeDifference(TimeClass time)
        {
            return Math.Abs((Hours * hourInSeconds + Minutes * 60 + Seconds) - (time.Hours * 60 * 60 + time.Minutes * 60 + time.Seconds));
        }

        public static TimeClass operator-(TimeClass a, TimeClass b)
        {
            var diff = (a.Hours * 60 * 60 + a.Minutes * 60 + a.Seconds) - (b.Hours * 60 * 60 + b.Minutes * 60 + b.Seconds);
            int timeInSec = dayInSeconds + diff;
            int time = timeInSec % dayInSeconds;

            int hours = time / hourInSeconds;
            int minutes = time % hourInSeconds / 60;
            int seconds = time % hourInSeconds % 60;

            TimeClass res = new TimeClass(hours, minutes, seconds);
            return res;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static TimeClass operator ++(TimeClass time)
        {
            if (time.Seconds == 59 && time.Minutes == 59 && time.Hours == 23)
            {
                time.Seconds = 0;
                time.Minutes = 0;
                time.Hours = 0;
            }
            else if (time.Seconds == 59 && time.Minutes == 59)
            {
                time.Seconds = 0;
                time.Minutes = 0;
                time.Hours++;
            }
            else if (time.Seconds == 59)
            {
                time.Seconds = 0;
                time.Minutes++;
            }
            else
            {
                time.Seconds++;
            }
            return time;
        }

        public static TimeClass operator --(TimeClass time)
        {
            if (time.Seconds == 0 && time.Minutes == 0 && time.Hours == 0)
            {
                time.Seconds = 59;
                time.Minutes = 59;
                time.Hours = 23;
            }
            else if (time.Seconds == 0 && time.Minutes == 0)
            {
                time.Seconds = 59;
                time.Minutes = 59;
                time.Hours--;
            }
            else if (time.Seconds == 0)
            {
                time.Seconds = 59;
                time.Minutes--;
            }
            else
            {
                time.Seconds--;
            }
            return time;
        }

        public static bool operator ==(TimeClass time1, TimeClass time2)
        {
            if ((time1.Hours * 60 * 60 + time1.Minutes * 60 + time1.Seconds) == (time2.Hours * 60 * 60 + time2.Minutes * 60 + time2.Seconds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(TimeClass time1, TimeClass time2)
        {
            if ((time1.Hours * 60 * 60 + time1.Minutes * 60 + time1.Seconds) != (time2.Hours * 60 * 60 + time2.Minutes * 60 + time2.Seconds))
            {
                return true;
            }

            return false;
        }

        public static bool operator >(TimeClass time1, TimeClass time2)
        {
            return ((time1.Hours * 60 * 60 + time1.Minutes * 60 + time1.Seconds) > (time2.Hours * 60 * 60 + time2.Minutes * 60 + time2.Seconds));
        }

        public static bool operator <(TimeClass time1, TimeClass time2)
        {
            return ((time1.Hours * 60 * 60 + time1.Minutes * 60 + time1.Seconds) < (time2.Hours * 60 * 60 + time2.Minutes * 60 + time2.Seconds));
        }

        public static bool operator >=(TimeClass time1, TimeClass time2)
        {
            return ((time1.Hours * 60 * 60 + time1.Minutes * 60 + time1.Seconds) >= (time2.Hours * 60 * 60 + time2.Minutes * 60 + time2.Seconds));
        }

        public static bool operator <=(TimeClass time1, TimeClass time2)
        {
            return ((time1.Hours * 60 * 60 + time1.Minutes * 60 + time1.Seconds) <= (time2.Hours * 60 * 60 + time2.Minutes * 60 + time2.Seconds));
        }

        public static bool operator true(TimeClass time)
        {
            return time.Hours == 0 && time.Minutes == 0 && time.Seconds == 0;
        }

        public static bool operator false(TimeClass time)
        {
            return time.Hours != 0 || time.Minutes != 0 || time.Seconds != 0;
        }

        // Явная перегрузка: int<=TimeClass; time1 = (int)time2
        public static explicit operator int(TimeClass time)
        {
            // Вернуть миллисекунды
            return (time.Hours * 60 * 60 + time.Minutes * 60 + time.Seconds) * 1000;
        }
        // Неявная перегрузка: Circle<=int; time1 = time2
        public static implicit operator TimeClass(int value)
        {
            return new TimeClass(value, value, value);
        }
    }
}