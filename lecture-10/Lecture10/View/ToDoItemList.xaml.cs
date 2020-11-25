using Lecture10.Model;
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

namespace Lecture10.View
{
    /// <summary>
    /// Interakční logika pro UserControl1.xaml
    /// </summary>
    public partial class ToDoItemList : UserControl
    {
        public ObservableCollection<ToDoItem> items;

        public ToDoItemList()
        {
            InitializeComponent();

            items = new ObservableCollection<ToDoItem> {
                new ToDoItem("Finish ToDoItemList"),
                new ToDoItem("Add ToDoAddControl"),
            };

            this.DataContext = items;
        }
    }
}
