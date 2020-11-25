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
    /// Interakční logika pro EditPersonWindow.xaml
    /// </summary>
    public partial class EditPersonWindow : Window
    {
        private Model.Person person;


        public EditPersonWindow(Model.Person person)
        {
            InitializeComponent();
            this.person = person;
            this.DataContext = this.person;

            FirstName.Text = person.FirstName;
            LastName.Text = person.LastName;
            Height.Text = person.Height.ToString();
            BirthDate.SelectedDate = person.BirthDate;
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

            person.FirstName = FirstName.Text;
            person.LastName = LastName.Text;
            person.Height = int.Parse(Height.Text);
            person.BirthDate = BirthDate.SelectedDate.Value;

            this.Close();
        }
    }
}
