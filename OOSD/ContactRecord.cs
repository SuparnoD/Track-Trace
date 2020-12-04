/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 03/12/2020
 * FULL NAME: ContactRecord.cs
 * PURPOSE: Acts as a constructor for ContactRecord which is used to hold informations when a contact occurs between two individuals
 * LAYER: Business
 */
using System;

namespace OOSD
{
    [Serializable]
    /*
     * Inherits from Record:
     * Person - allows the access of type Person (which holds an ID, name and phone number)
     * Date - the date & time of a particular incident 
     */
    public class ContactRecord : Record
    {
        private Person personTwo;

        public ContactRecord(Person person, Person personTwo, DateTime date) : base(person, date)
        {
            this.personTwo = personTwo;
        }

        public ContactRecord()
        {

        }

        // PROPERTY: Allows the access of type Person (which holds an ID, name and phone number)
        public Person PersonTwo
        {
            get { return personTwo; }
            set { personTwo = value; }
        }
    }
}
