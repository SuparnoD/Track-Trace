using System.Windows;

namespace OOSD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addPerson_Click(object sender, RoutedEventArgs e)
        {
            AddIndividual addPerson = new AddIndividual();
            addPerson.Show();
            this.Close();
        }

        private void database_Click(object sender, RoutedEventArgs e)
        {
            Database personList = new Database();
            personList.Show();
            this.Close();
        }

        private void addLocation_Click(object sender, RoutedEventArgs e)
        {
            AddLocation addLocation = new AddLocation();
            addLocation.Show();
            this.Close();
        }

        private void recordVisit_Click(object sender, RoutedEventArgs e)
        {
            RecordVisit recordVisit = new RecordVisit();
            recordVisit.Show();
            this.Close();
        }

        private void recordContact_Click(object sender, RoutedEventArgs e)
        {
            RecordContact recordContact = new RecordContact();
            recordContact.Show();
            this.Close();
        }
    }
}
