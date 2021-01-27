/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 09/12/2020
 * FILE NAME: AddIndividual.xaml.cs
 * PURPOSE: Handles events in response to the user's interaction with window 'AddIndividual'
 * LAYER: Presentation
 */
using System.Linq;
using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for AddIndividual.xaml
    /// </summary>
    public partial class AddIndividual : Window
    {
        public AddIndividual()
        {
            InitializeComponent();

            // IDTxt is read-only as the ID is automatically set by the program to maintain uniqueness
            IDTxt.IsEnabled = false;

            // If the listOfPeople list (ref. DataAccess.cs) is empty, set the IDTxt textbox to 500
            if (DataAccess.listOfPeople.Any() != true)
            {
                int ID = 500;
                IDTxt.Text = ID.ToString();
            }
            else
            {
                // Else if the listOfPeople list is populated, set the IDTxt textbox to the last element's ID + 500
                int ID = DataAccess.listOfPeople.Last().ID;
                ID += 500;
                IDTxt.Text = ID.ToString();
            }
        }

        // The 'Go Back' button directs the user back to window 'MainWindow'
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }

        // Following events are triggered when the user clicks the 'Add Individual' button
        private void addPersonBtn_Click(object sender, RoutedEventArgs e)
        {
            // New object of type Person is created
            Person newIndividual = new Person();

            /* Error handling validation check: if the phone number text box:
             * - is more than or less than 11 digits
             * - is not solely numerical digit
             * - does not start with 0
             * then an error message is triggered */
            if (!(numberTxt.Text.Length.Equals(11)) || !(numberTxt.Text.Take(4).All(char.IsDigit)) || !(numberTxt.Text.StartsWith("0")))
            {
                MessageBox.Show("Error! Please ensure you have correctly entered your phone number");
            }
            // If validation check is passed, the following lines of code are executed
            else
            {
                // The PhoneNumber (property) of newIndividual (object of type Person) is initialised to the phone number
                newIndividual.PhoneNumber = numberTxt.Text;
                // The object newIndividual (of type Person) is added to the listOfPeople (list of type Person, refer to DataAccess.cs for more info)
                DataAccess.listOfPeople.Add(newIndividual);

                // The ID (property of type Person) is incremented by 500 for the last object in list listOfPeople
                foreach (Person person in DataAccess.listOfPeople)
                {
                    DataAccess.listOfPeople.Last().ID += 500;
                }

                // Forename, surname, phone number text box's are disabled after adding an individual. The add individual button is also disabled. This prevents the user from adding unwanted items to the list by mistake.
                // In order to add another individual, the user would have to go back and click Add Individual again
                numberTxt.IsEnabled = false;
                addPersonBtn.IsEnabled = false;

                // Confirmation message to show that the individual has been sucessfully registered
                MessageBox.Show("ID " + newIndividual.ID + " has been added to the database");
            }
        }
    }
}