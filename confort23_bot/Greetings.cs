using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confort23_bot
{
    public class Greetings
    {
        public string Greetingstext { get; set; }

        public Greetings()
        {
            using (StreamReader reader = new StreamReader("dataFiles/greetings.html"))
            {
                Greetingstext = reader.ReadToEnd();
            }
        }
    }
}
