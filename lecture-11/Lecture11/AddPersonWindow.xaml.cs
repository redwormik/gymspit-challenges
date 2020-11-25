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
using System.Windows.Shapes;


namespace Lecture11
{
    /// <summary>
    /// Interakční logika pro AddPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        private ObservableCollection<Model.Person> data;


        public AddPersonWindow(ObservableCollection<Model.Person> data)
        {
            InitializeComponent();
            this.data = data;
            this.DataContext = this.data;
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int _;
            e.Handled = !int.TryParse(e.Text, out _);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Height.Text == "" || !BirthDate.SelectedDate.HasValue)
            {
                return;
            }

            Model.Person person = new Model.Person(FirstName.Text, LastName.Text, int.Parse(Height.Text), BirthDate.SelectedDate.Value);
            data.Add(person);

            this.Close();
        }
    }
}
