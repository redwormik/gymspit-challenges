using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Lecture12.Model
{
	public class Ingredient: INotifyPropertyChanged
	{
		private string _Name;
		public string Name
		{
			get {
				return _Name;
			}

			set {
				_Name = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;


		public Ingredient(string Name)
		{
			_Name = Name;
		}


		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
