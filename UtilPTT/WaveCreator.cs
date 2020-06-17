using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilPTT
{
    public class WaveCreator
    {
        private bool upper;

        private readonly double max;
        private readonly double min;
        private double now;

        public WaveCreator(double now, double max, double min)
        {
            this.max = max;
            this.now = now;
            this.min = min;
        }

        public double Get(double db, bool def)
        {
            if (def)
                return now;

            if (upper)
                now += db;
            else
                now -= db;

            if (now + db > max)
            {
                if (upper)
                    upper = false;
                return max;
            }
            else if (now - db < min)
            {
                if (!upper)
                    upper = true;
                return min;
            }

            return now;
        }

        public double GetStatic()
        {
            return now;
        }
    }
}
