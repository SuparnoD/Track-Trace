/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 09/12/2020
 * FILE NAME: Database.xaml.cs
 * PURPOSE: Handles events in response to the user's interaction with window 'LocVisits'
 * LAYER: Presentation
 */
using System;
using System.Windows;
using System.Windows.Controls;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : Window
    {
        public Database()
        {
            InitializeComponent();

            /* If the listOfPeople list (ref. DataAccess.cs) is populated, format each item like below:
             * ID: {personID}
             * Phone Number {personPhoneNumber}
             */
            if (DataAccess.listOfPeople.Count >= 1)
            {
                foreach (Person person in DataAccess.listOfPeople)
                {
                    peopleListBox.Items.Add("ID: " + person.ID + Environment.NewLine
                        + "Phone Number: " + person.PhoneNumber + Environment.NewLine);
                }
            }
            else
            {
                // Else if the list is empty, notify the user that no one is currently registered
                peopleListBox.Items.Add("No one is currently registered");
            }

            /* If the listOfLocations list (ref. DataAccess) is populated, format each item like below:
             * Location Name: {locationName}
             * Location Type: {locationType}
             */
            if (DataAccess.listOfLocations.Count >= 1)
            {
                foreach (Location location in DataAccess.listOfLocations)
                {
                    locListBox.Items.Add("Location Name: " + location.Name + Environment.NewLine
                        + "Location Type: " + location.Type + Environment.NewLine);
                }
            }
            else
            {
                // Else if the list is empty, notify the user that no locations are currently registered
                locListBox.Items.Add("No location is currently registered");
            }
        }

        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // The 'Go Back' button directs the user back to window 'MainWindow'
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }

        // The 'Location Visits' button directs the user to window 'LocVisits'
        private void locVisitBtn_Click(object sender, RoutedEventArgs e)
        {
            LocVisits locVisits = new LocVisits();
            locVisits.Show();
            this.Close();
        }

        // The 'Peope Contacts' button directs the user to window 'PeopleContacts'
        private void peopleContactBtn_Click(object sender, RoutedEventArgs e)
        {
            PeopleContacts peopleContacts = new PeopleContacts();
            peopleContacts.Show();
            this.Close();
        }
    }
}
