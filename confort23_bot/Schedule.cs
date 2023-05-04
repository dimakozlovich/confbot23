using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confort23_bot
{
     class Schedule
    {
        public string ScheduleText { get; set; }
        public Schedule()
        {
            using (StreamReader reader = new StreamReader("dataFiles/schedule.html"))
            {
                ScheduleText = reader.ReadToEnd();
            }
        }
    }
}
