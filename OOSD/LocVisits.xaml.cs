/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 09/12/2020
 * FILE NAME: LocVisits.xaml.cs
 * PURPOSE: Handles events in response to the user's interaction with window 'LocVisits'
 * LAYER: Presentation
 */
using System;
using System.Windows;
using System.Windows.Controls;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for LocVisits.xaml
    /// </summary>
    public partial class LocVisits : Window
    {
        public LocVisits()
        {
            InitializeComponent();

            // Lists all the registered location objects the locList listbox
            foreach (Location location in DataAccess.listOfLocations)
            {
                locList.Items.Add(location);
            }
        }

        // The 'Go Back' button directs the user back to window 'Database'
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Database db = new Database();
            db.Show();
            this.Close();
        }

        private void locList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void visitRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Following events are triggered when the user clicks the 'Submit' button
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            // Error handling/validation check: if the text box are blank, an error message is triggered
            if ((string.IsNullOrWhiteSpace(date1.Text)) || (string.IsNullOrWhiteSpace(date2.Text)))
            {
                MessageBox.Show("Error! Please ensure that the date fields are correctly entered");
            }
            else
            {
                // If validation check is passed, the following lines of code are executed
                try
                {
                    // var dateOne of type DateTime is initialised to the value in date1 textbox
                    DateTime dateOne = Convert.ToDateTime(date1.Text);
                    // var dateTwo of type DateTime is initialised to the value in date2 textbox
                    DateTime dateTwo = Convert.ToDateTime(date2.Text);

                    // Error handling/validation check: checks to see if the range of date is valid. If date/time in date1 is after date/time in date2, then an error message is triggered
                    if (dateOne.CompareTo(dateTwo) > 0)
                    {
                        MessageBox.Show("Error! Incorrect date range.");
                    }

                    // Clears the visitRecord listbox after clicking 'Submit' button preventing from unwanted items piling up in that listbox
                    visitRecord.Items.Clear();

                    // Iterates through the listOfVisits list
                    foreach (Visit visitRec in DataAccess.listOfVisits)
                    {
                        // Error handling/validation check: checks to see if the location selected in locList listbox is equal to the location stored in the visit records
                        if (locList.SelectedItem.ToString().Equals(visitRec.Location.ToString()))
                        {
                            // Error handling/validation check: checks to see that the date/time value in date1 textbox is equal to or less than the date stored in visit records
                            if (dateOne.CompareTo(visitRec.Date) <= 0)
                            {
                                // Error handling/validation check: checks to see that the date/time value in date2 textbox is equal to or more than the date stored in visit records
                                if (dateTwo.CompareTo(visitRec.Date) >= 0)
                                {
                                    /* All the retrieved data is then listed in the visitRecord listbox in the format
                                     * Name: {personName}
                                     * Phone Number: {personPhoneNumber}
                                     * Date of Visit: {visitDate}
                                     */
                                    visitRecord.Items.Add("ID: " + visitRec.Person.ID + Environment.NewLine
                                        + "Phone Number: " + visitRec.Person.PhoneNumber + Environment.NewLine
                                        + "Date of Visit: " + visitRec.Date);
                                }
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
