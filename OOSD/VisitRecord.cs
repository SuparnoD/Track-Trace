/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 03/12/2020
 * FULL NAME: VisitRecord.cs
 * PURPOSE: Acts as a constructor for VisitRecord which is used to hold informations when an individual visits a particular location
 * LAYER: Business
 */
using System;

namespace OOSD
{
    [Serializable()]
    public class VisitRecord : Record
    {
        private Location location;

        public VisitRecord(Person person, Location location, DateTime date) : base(person, date)
        {
            this.location = location;
        }

        public VisitRecord()
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
