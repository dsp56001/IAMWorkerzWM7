using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WokerzApp
{
    public class ItemDetailViewModel : INotifyPropertyChanged
    {
        

        public ItemDetailViewModel()
        {
            
        }

        private string _imageOne;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string ImageOne
        {
            get
            {
                return _imageOne;
            }
            set
            {
                if (value != _imageOne)
                {
                    _imageOne = value;
                    NotifyPropertyChanged("ImageOne");
                }
            }
        }
        
        private string _userfullName;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string UserFullName
        {
            get
            {
                return _userfullName;
            }
            set
            {
                if (value != _userfullName)
                {
                    _userfullName = value;
                    NotifyPropertyChanged("UserFullName");
                }
            }
        }

        private string _peopleID;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string PeopleID
        {
            get
            {
                return _peopleID;
            }
            set
            {
                if (value != _peopleID)
                {
                    _peopleID = value;
                    NotifyPropertyChanged("PeopleID");
                }
            }
        }

        private string _position;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value != _position)
                {
                    _position = value;
                    NotifyPropertyChanged("Position");
                }
            }
        }

        private string _phone;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    NotifyPropertyChanged("Phone");
                }
            }
        }

        private string _email;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }

        private string _skills;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                if (value != _skills)
                {
                    _skills = value;
                    NotifyPropertyChanged("Skills");
                }
            }
        }

        private string _mondayHours;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string MondayHours
        {
            get
            {
                return _mondayHours;
            }
            set
            {
                if (value != _mondayHours)
                {
                    _mondayHours = value;
                    NotifyPropertyChanged("MondayHours");
                }
            }
        }

        private string _tuesdayHours;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string TuesdayHours
        {
            get
            {
                return _tuesdayHours;
            }
            set
            {
                if (value != _tuesdayHours)
                {
                    _tuesdayHours = value;
                    NotifyPropertyChanged("TuesdayHours");
                }
            }
        }

        private string _wednesdayHours;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string WednesdayHours
        {
            get
            {
                return _wednesdayHours;
            }
            set
            {
                if (value != _wednesdayHours)
                {
                    _wednesdayHours = value;
                    NotifyPropertyChanged("WednesdayHours");
                }
            }
        }

        private string _thursdayHours;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string ThursdayHours
        {
            get
            {
                return _thursdayHours;
            }
            set
            {
                if (value != _thursdayHours)
                {
                    _thursdayHours = value;
                    NotifyPropertyChanged("ThursdayHours");
                }
            }
        }


        private string _fridayHours;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string FridayHours
        {
            get
            {
                return _fridayHours;
            }
            set
            {
                if (value != _fridayHours)
                {
                    _fridayHours = value;
                    NotifyPropertyChanged("FridayHours");
                }
            }
        }

        private string _saturdayHours;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string SaturdayHours
        {
            get
            {
                return _saturdayHours;
            }
            set
            {
                if (value != _saturdayHours)
                {
                    _saturdayHours = value;
                    NotifyPropertyChanged("SaturdayHours");
                }
            }
        }

        private string _sundayHours;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string SundayHours
        {
            get
            {
                return _sundayHours;
            }
            set
            {
                if (value != _sundayHours)
                {
                    _sundayHours = value;
                    NotifyPropertyChanged("SundayHours");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
