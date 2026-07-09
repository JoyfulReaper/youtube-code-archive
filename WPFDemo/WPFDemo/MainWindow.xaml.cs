using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDemo.Models;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<PersonModel> people = new List<PersonModel>();

        public MainWindow()
        {
            InitializeComponent();

            SetupDemoData();

            myComboBox.ItemsSource = people;
        }

        private void SetupDemoData()
        {
            people.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            people.Add(new PersonModel { FirstName = "Joe", LastName = "Smith" });
            people.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Hello {FirstNameText.Text}");
        }
    }
}
