/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 03/12/2020
 * FILE NAME: Record.cs
 * PURPOSE: Acts as a base class for any class dealing with holding records
 * LAYER: Business Object
 */
using System;

namespace OOSD
{
    public class Record
    {
        private Person person;
        private DateTime date;      //DateTime is a structure that holds date & time

        public Record(Person person, DateTime date)
        {
            this.person = person;
            this.date = date;
        }

        public Record()
        {

        }

        // PROPERTY: Allows the access of type Person (which holds an ID, name and phone number)
        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        // PROPERTY: The date of a particular incident
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
