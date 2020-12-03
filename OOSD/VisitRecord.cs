using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSD
{
    class VisitRecord : Record
    {
        private Location location;

        public VisitRecord(Person person, Location location, DateTime date) : base(person, date)
        {
            this.location = location;
        }

        public VisitRecord()
        {

        }

        public Location Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
