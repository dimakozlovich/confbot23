using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confort23_bot
{
    public class User
    {
        private long Id { get; }
        public Seminar? RegisteredDay1;
        public Seminar? RegisteredDay2;

        public User(long id)
        {
            Id = id;
        }
        public User(long id, Seminar registeredDay1) : this(id)
        {
            RegisteredDay1 = registeredDay1;
        }
        public User(long id, Seminar registeredDay1, Seminar registeredDay2) : this(id, registeredDay2)
        {
            RegisteredDay2 = registeredDay2;
        }
    }
}
