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

namespace Lecture12
{

	/// <summary>
	/// Interakční logika pro MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<Model.Ingredient> ingredients = new ObservableCollection<Model.Ingredient>();

		private IngredientWindow ingredientWindow;


		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this.ingredients;
		}


		private void IngredientsButton_Click(object sender, RoutedEventArgs e)
		{
			if (ingredientWindow == null) {
				ingredientWindow = new IngredientWindow(ingredients);
				ingredientWindow.Closed += delegate {
					ingredientWindow = null;
				};
			}

			ingredientWindow.Show();
			ingredientWindow.Focus();
		}
	}
}
