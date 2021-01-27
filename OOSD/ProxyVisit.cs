/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 10/12/2020
 * FILE NAME: ProxyVisit.cs
 * PURPOSE: Due to being a derived class, data serialization could not take place in Visit.cs.
 *          Therefore, ProxyVisit.cs acts as a placeholder for Visit objects stored in listOfVisits (ref. DataAccess.cs). This allow's for serialization.
 *          * * * UTILISES PROXY DESIGN PATTERN * * *
 * LAYER: Business Object
 */

/*
 * Refer to Visit.cs for more information in regards to properties
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOSD
{
    public class ProxyVisit : ISerializable
    {
        private Person person;
        private Location location;
        private DateTime date;

        public ProxyVisit(Person person, Location location, DateTime date)
        {
            this.person = person;
            this.location = location;
            this.date = date;
        }

        public ProxyVisit()
        {

        }

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public Location Location
        {
            get { return location; }
            set { location = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        // Attributes for Serialization/Deserialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Person", Person);
            info.AddValue("Location", Location);
            info.AddValue("Date", Date);
        }

        // Attributes for Serialization/Deserialization
        public ProxyVisit(SerializationInfo info, StreamingContext context)
        {
            Person = (Person)info.GetValue("Person", typeof(Person));
            Location = (Location)info.GetValue("Location", typeof(Location));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
        }
    }
}
