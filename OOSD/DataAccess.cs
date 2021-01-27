/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 10/12/2020
 * FILE NAME: DataAccess.cs
 * PURPOSE: Acts as an intermediary to access all the lists required to run the program
 *          * * * UTILISES SINGLETON DESIGN PATTERN * * *
 * LAYER: Data Access
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace OOSD
{
    class DataAccess
    {
        // List of type Person which stores data of all individuals
        public static List<Person> listOfPeople = new List<Person>();

        // List of type Location which stores data of all locations
        public static List<Location> listOfLocations = new List<Location>();

        // List of type Visit which stores data when a visit to a particular location occurs (visitor, date & time of the visit and location)
        public static List<Visit> listOfVisits = new List<Visit>();

        // List of type Contact which stores data when a contact occurs between two individuals (details of the two individuals involved and the date & time of the contact)
        public static List<Contact> listOfContacts = new List<Contact>();

        // Proxy lists to manage data storage (ref. ProxyVisit.cs & ProxyContact.cs)
        public static List<ProxyContact> proxyContact = new List<ProxyContact>();
        public static List<ProxyVisit> proxyVisit = new List<ProxyVisit>();

        private DataAccess()
        {

        }

        // Copies contents from the real contact list (listOfPeople) to the proxy contact list (proxyContact)
        public static void copyContactList()
        {
            foreach (Contact conRec in listOfContacts)
            {
                ProxyContact proxy = new ProxyContact();
                proxy.Person = conRec.Person;
                proxy.PersonTwo = conRec.PersonTwo;
                proxy.Date = conRec.Date;
                proxyContact.Add(proxy);
            }
        }

        // Restore's contents from the proxy contact list (proxyContact) to the real contact list (listOfPeople)
        public static void restoreContactList()
        {
            foreach (ProxyContact proxy in proxyContact)
            {
                Contact conRec = new Contact();
                conRec.Person = proxy.Person;
                conRec.PersonTwo = proxy.PersonTwo;
                conRec.Date = proxy.Date;
                listOfContacts.Add(conRec);
            }
            proxyContact.Clear();
        }

        // Copies contents from the real visit list (listOfVisits) to the proxy visit list (proxyVisit)
        public static void copyVisitList()
        {
            foreach (Visit visRec in listOfVisits)
            {
                ProxyVisit proxy = new ProxyVisit();
                proxy.Person = visRec.Person;
                proxy.Location = visRec.Location;
                proxy.Date = visRec.Date;
                proxyVisit.Add(proxy);
            }
        }

        // Restore's contents from the proxy visit list (proxyVisit) to the real visit list (listOfVisits)
        public static void restoreVisitList()
        {
            foreach (ProxyVisit proxy in proxyVisit)
            {
                Visit visRec = new Visit();
                visRec.Person = proxy.Person;
                visRec.Location = proxy.Location;
                visRec.Date = proxy.Date;
                listOfVisits.Add(visRec);
            }
            proxyVisit.Clear();
        }
    }
}
