using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSD
{
    class ContactRecord : Record
    {
        private Person personTwo;

        public ContactRecord(Person person, Person personTwo, DateTime date) : base(person, date)
        {
            this.personTwo = personTwo;
        }

        public ContactRecord()
        {

        }

        public Person PersonTwo
        {
            get { return personTwo; }
            set { personTwo = value; }
        }
    }
}
