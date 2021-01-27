/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 00/12/2020
 * FILE NAME: PeopleContact.xaml.cs
 * PURPOSE: Handles events in response to the user's interaction with window 'PeopleContact'
 * LAYER: Presentation
 */
using System;
using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for PeopleContacts.xaml
    /// </summary>
    public partial class PeopleContacts : Window
    {
        public PeopleContacts()
        {
            InitializeComponent();

            // Lists all the registered person objects the locList listbox
            foreach (Person person in DataAccess.listOfPeople)
            {
                peopeListBox.Items.Add(person);
            }
        }

        // The 'Go Back' button directs the user back to window 'Database'
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            db.Show();
            this.Close();
        }

        // Following events are triggered when the user clicks the 'Submit' button
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            // Error handling/validation check: if the text box is blank, an error message is triggered
            if (string.IsNullOrWhiteSpace(dateTextBox.Text))
            {
                MessageBox.Show("Error! Please ensure that the date field is correctly entered");
            }
            else
            {
                // If validation check is passed, the following lines of code are executed
                try
                {
                    // var date of type DateTime is initialised to the value in dateTextBox textbox
                    DateTime date = Convert.ToDateTime(dateTextBox.Text);

                    // Clears the peopleListBox2 listbox after clicking 'Submit' button preventing from unwanted items piling up in that listbox
                    peopleListBox2.Items.Clear();

                    // Iterates through the listOfContacts list
                    foreach (Contact contactRec in DataAccess.listOfContacts)
                    {
                        // Error handling/validation check: checks to see if the person selected in peopleListBox listbox is equal to the person stored in the contact records
                        if (peopeListBox.SelectedItem.ToString().Equals(contactRec.Person.ToString()))
                        {
                            // Error handling/validation check: checks to see that the contact occured on or after the date/time value in the dateTextBox textbox
                            if (date.CompareTo(contactRec.Date) <= 0)
                            {
                                /* All the retrieved data is the listed in the peopleListBox2 listbox in the format
                                 * ID: {contactedPerson}
                                 * Phone Number: {contactedPersonPhoneNumber}
                                 * Date of Contact: {dateOfContact}
                                 */
                                peopleListBox2.Items.Add("ID: " + contactRec.PersonTwo.ID + Environment.NewLine
                                    + "Phone Number: " + contactRec.PersonTwo.PhoneNumber + Environment.NewLine
                                    + "Date of Contact: " + contactRec.Date);
                            }
                        }
                    }
                }
                catch
                {
                    // Error handling/validation check: in the event an unexpected error is raised, the following message is triggered preventing the program from crashing
                    MessageBox.Show("Error! Please ensure all fields are correctly entered/selected");
                }
            }
        }
    }
}
