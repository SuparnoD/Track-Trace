/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 03/12/2020
 * FILE NAME: DataAccess.cs
 * PURPOSE: Acts as an intermediary to access all the lists required to run the program
 * LAYER: Data
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace OOSD
{
    class DataAccess
    {
        // List of type Person which stores data of all individuals
        public static List<Person> listOfPeople = new List<Person>();

        // List of type Location which stores data of all locations
        public static List<Location> listOfLocations = new List<Location>();

        // List of type VisitRecord which stores data when a visit to a particular location occurs (visitor, date & time of the visit and location)
        public static List<VisitRecord> listOfVisits = new List<VisitRecord>();

        // List of type ContactRecord which stores data when a contact occurs between two individuals (details of the two individuals involved and the date & time of the contact)
        public static List<ContactRecord> listOfContacts = new List<ContactRecord>();
    }
}
