/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 10/12/2020
 * FILE NAME: ProxyContact.cs
 * PURPOSE: Due to being a derived class, data serialization could not take place in Contact.cs.
 *          Therefore, ProxyContact.cs acts as a placeholder for Contact objects stored in listOfContacts (ref. DataAccess.cs). This allow's for serialization.
 *          * * * UTILISES PROXY DESIGN PATTERN * * *
 * LAYER: Business Object
 */

/*
 * Refer to Contact.cs for more information in regards to properties
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOSD
{
    [Serializable()]
    public class ProxyContact : ISerializable
    {
        private Person person;
        private Person personTwo;
        private DateTime date;

        public ProxyContact(Person person, Person personTwo, DateTime date)
        {
            this.person = person;
            this.personTwo = personTwo;
            this.date = date;
        }

        public ProxyContact()
        {

        }

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public Person PersonTwo
        {
            get { return personTwo; }
            set { personTwo = value; }
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
            info.AddValue("PersonTwo", PersonTwo);
            info.AddValue("Date", Date);
        }

        // Attributes for Serialization/Deserialization
        public ProxyContact(SerializationInfo info, StreamingContext context)
        {
            Person = (Person)info.GetValue("Person", typeof(Person));
            PersonTwo = (Person)info.GetValue("Person", typeof(Person));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
        }
    }
}
