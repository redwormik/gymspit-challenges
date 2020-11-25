using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lecture11
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Model.Person> data;


        public MainWindow(): this(new ObservableCollection<Model.Person>())
        {
            data.Add(new Model.Person("Test", "Testing", 185, DateTime.Parse("1991-01-01")));
            data.Add(new Model.Person("Second", "Test", 175, DateTime.Parse("1997-01-01")));
            data.Add(new Model.Person("Last", "Person", 165, DateTime.Parse("2001-01-01")));
        }


        public MainWindow(ObservableCollection<Model.Person> data)
        {
            InitializeComponent();
            this.data = data;
            this.DataContext = this.data;
        }


        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            AddPersonWindow window = new AddPersonWindow(data);
            window.Show();
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditPersonWindow window = new EditPersonWindow((sender as Button).DataContext as Model.Person);
            window.Show();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            data.Remove((sender as Button).DataContext as Model.Person);
        }
    }
}
