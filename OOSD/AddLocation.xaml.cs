/*
 * AUTHOR: Suparno Deb
 * DATE LAST MODIFIED: 04/12/2020
 * FILE NAME: AddLocation.xaml.cs
 * PURPOSE: Handles events in response to the user's interaction with window 'AddLocation'
 * LAYER: Presentation
 */
using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Window
    {
        public AddLocation()
        {
            InitializeComponent();

            // Following items are added to the listbox so that the user can select which category the location belongs to
            locListBox.Items.Add("Hospitality");
            locListBox.Items.Add("Bars, Pubs & Clubs");
            locListBox.Items.Add("Hotels");
            locListBox.Items.Add("Conference Centres");
            locListBox.Items.Add("Business Centres");
            locListBox.Items.Add("Community Centres");
            locListBox.Items.Add("Sports Clubs");
            locListBox.Items.Add("Art Galleries");
            locListBox.Items.Add("Academic Venues");
            locListBox.Items.Add("Private Property");
            locListBox.Items.Add("Parks & Fields");
            locListBox.Items.Add("Others");
        }

        // The 'Go Back' button directs the user back to window 'MainWindow'
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }

        // Following events are triggered when the user clicks the 'Add Location' button
        private void addPersonBtn_Click(object sender, RoutedEventArgs e)
        {
            // New object of type Location is created
            Location newLocation = new Location();

            // Error handling/validation check: if the text box are blank, an error message is triggered
            if (string.IsNullOrWhiteSpace(locNameTextBox.Text))
            {
                MessageBox.Show("Error! Please ensure all fields are correctly entered/selected");
            }
            // If validation check is passed, the following lines of code are executed
            else
            {
                try
                {
                    // The Type (property) of newLocation (object of type Location) is initialised to the category/type listbox. For ToString() refer to Location.cs
                    newLocation.Type = locListBox.SelectedItem.ToString();
                    // The Name (property) of newLocation (object of type Location) is initialised to the name textbox
                    newLocation.Name = locNameTextBox.Text;
                    // The object newLocation (of type Location) is added to the listOfLocation (list of type Location, refer to DataAccess.cs for more info)
                    DataAccess.listOfLocations.Add(newLocation);

                    // Type/category listbox and name textbox aswell as the add location button is disabled after adding a location. This prevents the user from adding unwanted items to the list by mistake.
                    // In order to add another location, the user would have to go back and click Add Location again
                    locListBox.IsEnabled = false;
                    locNameTextBox.IsEnabled = false;
                    addLocBtn.IsEnabled = false;

                    // Confirmation message to show that the location has been sucessfully registered
                    MessageBox.Show(newLocation.Name + " has been added to the database");
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
