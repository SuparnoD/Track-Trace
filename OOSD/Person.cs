using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSD
{
    class Person
    {
        private int id;
        private string name;
        private string phoneNumber;

        public Person(int id, string name, string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public Person()
        {

        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
