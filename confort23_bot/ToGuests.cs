using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confort23_bot
{
    public class ToGuests
    {
        public string toGuestsText { get; set; }

        public ToGuests()
        {
            using (StreamReader reader = new StreamReader("dataFiles/toguests.html"))
            {
                toGuestsText = reader.ReadToEnd();
            }
        }
    }
}
