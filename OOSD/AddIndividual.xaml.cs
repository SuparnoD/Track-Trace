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

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Show();
            this.Close();
        }

        private void addPersonBtn_Click(object sender, RoutedEventArgs e)
        {
            Person newIndividual = new Person();

            if ((string.IsNullOrWhiteSpace(foreNameTxt.Text)) || (string.IsNullOrWhiteSpace(surNameTxt.Text)) || (string.IsNullOrWhiteSpace(numberTxt.Text)))
            {
                MessageBox.Show("Error! Please ensure that all fields are correctly entered");
            }
            else if ((foreNameTxt.Text.Any(char.IsDigit)) || (surNameTxt.Text.Any(char.IsDigit)))
            {
                MessageBox.Show("Error! Please ensure that the names are correctly entered");
            }
            else if (!(numberTxt.Text.Length.Equals(11)) || !(numberTxt.Text.Take(4).All(char.IsDigit)) || !(numberTxt.Text.StartsWith("0")))
            {
                MessageBox.Show("Error! Please ensure you have correctly entered your phone number");
            }
            else
            {
                newIndividual.Name = string.Concat(foreNameTxt.Text, " ", surNameTxt.Text);
                newIndividual.PhoneNumber = numberTxt.Text;
                DataAccess.listOfPeople.Add(newIndividual);

                foreach (Person person in DataAccess.listOfPeople)
                {
                    DataAccess.listOfPeople.Last().ID += 500;
                }

                foreNameTxt.IsEnabled = false;
                surNameTxt.IsEnabled = false;
                numberTxt.IsEnabled = false;
                addPersonBtn.IsEnabled = false;

                MessageBox.Show(newIndividual.Name + " has been added to the database");
            }
        }
    }
}