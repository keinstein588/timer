using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp
{
    public class customer
    {
        public string name;
        public TimeSpan time;

        public customer(string name, long ticks)
        {
            this.name = name;
            time = new TimeSpan(ticks);
        }
    }
}
