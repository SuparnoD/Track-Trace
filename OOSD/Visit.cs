/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 10/12/2020
 * FILE NAME: Visit.cs
 * PURPOSE: Acts as a constructor for Visit which is used to hold informations when an individual visits a particular location
 * LAYER: Business Objecr
 */
using System;
using System.Runtime.Serialization;

namespace OOSD
{
    /*
    * Inherits from Record:
    * Person - allows the access of type Person (which holds an ID and phone number)
    * Date - the date & time of a particular incident 
    */
    public class Visit : Record
    {
        private Location location;

        public Visit(Person person, Location location, DateTime date) : base(person, date)
        {
            this.location = location;
        }

        public Visit()
        {

        }

        // PROPERTY: Allows the access of type Location (which holds the location type and name)
        public Location Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
