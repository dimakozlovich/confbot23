﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confort23_bot
{
    class Contacts : Start
    {
        public string ContactsText { get; set; }
        public Contacts()
        {
            using (StreamReader reader = new StreamReader("dataFiles/contacts.html"))
            {
              ContactsText = reader.ReadToEnd();
            }
        }
    }
}
