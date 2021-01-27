/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 09/12/2020
 * FILE NAME: RecordVisit.xaml.cs
 * PURPOSE: Handles events in response to the user's interaction with window 'RecordVisit'
 * LAYER: Presentation
 */
using System;
using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for RecordVisit.xaml
    /// </summary>
    public partial class RecordVisit : Window
    {
        public RecordVisit()
        {
            InitializeComponent();

            // Populates peopleListBox listbox with all the Person objects stored in listOfPeople list (ref. DataAccess.cs)
            foreach (Person person in DataAccess.listOfPeople)
            {
                peopleListBox.Items.Add(person);
            }

            // Populates locListBox listbox with all the Location objects stored in listOfLocations list (ref. DataAccess.cs)
            foreach (Location location in DataAccess.listOfLocations)
            {
                locListBox.Items.Add(location);
            }
        }

        // The 'Go Back' button directs the user back to window 'MainWindow'
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }

        // Following events are triggered when the user clicks the 'SUBMIT' button
        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;

            if (DateTime.TryParse(dateTxtBox.Text, out date))
            {
                try
                {
                    // A new object of type Visit is created to store the location, person details and date of visit
                    Visit visitRec = new Visit();
                    visitRec.Location = (Location)locListBox.SelectedItem;
                    visitRec.Person = (Person)peopleListBox.SelectedItem;
                    visitRec.Date = date;

                    // The object is stored in listOfVisits list (ref. DataAccess.cs)
                    DataAccess.listOfVisits.Add(visitRec);

                    // Confirmation message to show that the visit has been sucessfully registered
                    MessageBox.Show(visitRec.Person.ID + " visited " + visitRec.Location.Name + " on " + date);
                }
                catch
                {
                    // Error handling/validation check: in the event an unexpected error is raised, the following message is triggered preventing the program from crashing
                    MessageBox.Show("Error! Please ensure all fields are correctly entered/selected");
                }
            }
            else
            {
                // Error handling/validation check: in the event the date/time textbox is entered incorrectly, the following message is triggered preventing the program from crashing
                MessageBox.Show("Error! Please ensure the date is entered in DD/MM/YYYY HH:MM");
            }
        }
    }
}
