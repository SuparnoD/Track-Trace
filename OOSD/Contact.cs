/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 10/12/2020
 * FILE NAME: Contact.cs
 * PURPOSE: Acts as a constructor for Contact which is used to hold informations when a contact occurs between two individuals
 * LAYER: Business Object
 */
using System;

namespace OOSD
{
    /*
     * Inherits from Record:
     * Person - allows the access of type Person (which holds an ID and phone number)
     * Date - the date & time of a particular incident 
     */
    public class Contact : Record
    {
        private Person personTwo;

        public Contact(Person person, Person personTwo, DateTime date) : base(person, date)
        {
            this.personTwo = personTwo;
        }

        public Contact()
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
