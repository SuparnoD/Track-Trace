/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 05/12/2020
 * FILE NAME: RecordContact.xaml.cs
 * PURPOSE: Handles events in response to the user's interaction with window 'RecordContact'
 * LAYER: Presentation
 */
using System;
using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for RecordContact.xaml
    /// </summary>
    public partial class RecordContact : Window
    {
        public RecordContact()
        {
            InitializeComponent();

            // Populates both listbox with all the Person objects that is stored in listOfPeople list (ref. DataAccess.cs)
            foreach (Person person in DataAccess.listOfPeople)
            {
                peopleListBox.Items.Add(person);
                peopleListBox2.Items.Add(person);
            }
        }

        // Following events are triggered when the user clicks the 'SUBMIT' button
        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;

            // Checks if the date is entered in the correct format - DD:MM:YYY
            if (DateTime.TryParse(dateTxtBox.Text, out date))
            {
                try
                {
                    /* Two objects of type ContactRecord is recorded to record:
                     * personOne contacted personTwo on a particular date
                     * personTwo contacted personOne on the same date
                     */

                    ContactRecord contactRec = new ContactRecord();
                    contactRec.Person = (Person)peopleListBox.SelectedItem;
                    contactRec.PersonTwo = (Person)peopleListBox2.SelectedItem;
                    contactRec.Date = date;

                    ContactRecord contactRecTwo = new ContactRecord();
                    contactRecTwo.Person = (Person)peopleListBox2.SelectedItem;
                    contactRecTwo.PersonTwo = (Person)peopleListBox.SelectedItem;
                    contactRecTwo.Date = date;

                    // Prevents user from selecting the same person in both listbox
                    if (contactRec.Person.Equals(contactRec.PersonTwo))
                    {
                        MessageBox.Show("Error! Select two different persons");
                    }
                    else
                    {
                        // Confirmation message to show that the contact between two individuals has been sucessfully registered
                        MessageBox.Show(contactRec.Person.Name + " contacted " + contactRec.PersonTwo.Name + " on " + contactRec.Date);
                        DataAccess.listOfContacts.Add(contactRec);
                        DataAccess.listOfContacts.Add(contactRecTwo);
                    }
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

        // The 'Go Back' button directs the user back to window 'MainWindow'
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }
    }
}
