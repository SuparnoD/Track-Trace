using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSD
{
    class Record
    {
        private Person person;
        private DateTime date;

        public Record(Person person, DateTime date)
        {
            this.person = person;
            this.date = date;
        }

        public Record()
        {

        }

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
