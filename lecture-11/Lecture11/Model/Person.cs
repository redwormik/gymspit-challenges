using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Lecture11.Model
{
    public class Person: INotifyPropertyChanged
    {
        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                _FirstName = value;
                OnPropertyChanged();
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                _LastName = value;
                OnPropertyChanged();
            }
        }

        private int _Height;
        public int Height
        {
            get
            {
                return _Height;
            }

            set
            {
                _Height = value;
                OnPropertyChanged();
            }
        }

        private DateTime _BirthDate;
        public DateTime BirthDate {
            get
            {
                return _BirthDate;
            }

            set
            {
                _BirthDate = value;
                OnPropertyChanged();
                OnPropertyChanged("Age");
            }
        }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                return now.Year - BirthDate.Year - (now.ToString("MMdd").CompareTo(BirthDate.ToString("MMdd")) < 0 ? 1 : 0);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public Person(string firstName, string lastName, int height, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Height = height;
            BirthDate = birthDate;
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
