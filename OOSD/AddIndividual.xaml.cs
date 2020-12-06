/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 04/12/2020
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

            // Error handling/validation check: if the text box are blank, an error message is triggered
            if ((string.IsNullOrWhiteSpace(foreNameTxt.Text)) || (string.IsNullOrWhiteSpace(surNameTxt.Text)) || (string.IsNullOrWhiteSpace(numberTxt.Text)))
            {
                MessageBox.Show("Error! Please ensure that all fields are correctly entered");
            }
            // Error handling/validation check: if the forename and surname text box contain a number, an error message is triggered
            else if ((foreNameTxt.Text.Any(char.IsDigit)) || (surNameTxt.Text.Any(char.IsDigit)))
            {
                MessageBox.Show("Error! Please ensure that the names are correctly entered");
            }
            /* Error handling validation check: if the phone number text box:
             * - is more than or less than 11 digits
             * - is not solely numerical digit
             * - does not start with 0
             * then an error message is triggered */
            else if (!(numberTxt.Text.Length.Equals(11)) || !(numberTxt.Text.Take(4).All(char.IsDigit)) || !(numberTxt.Text.StartsWith("0")))
            {
                MessageBox.Show("Error! Please ensure you have correctly entered your phone number");
            }
            // If validation check is passed, the following lines of code are executed
            else
            {
                // The forename and surname is concatenated to form full name. The Name (property) of newIndividual (object of type Person) is then initialised to the full name
                newIndividual.Name = string.Concat(foreNameTxt.Text, " ", surNameTxt.Text);
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
                foreNameTxt.IsEnabled = false;
                surNameTxt.IsEnabled = false;
                numberTxt.IsEnabled = false;
                addPersonBtn.IsEnabled = false;

                // Confirmation message to show that the individual has been sucessfully registered
                MessageBox.Show(newIndividual.Name + " has been added to the database");
            }
        }
    }
}