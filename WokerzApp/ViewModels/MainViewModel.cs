using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace WokerzApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        private string _message = "";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (value != _message)
                {
                    _message = value;
                    NotifyPropertyChanged("Message");
                }
            }
        }

        private currentSelection _selection = currentSelection.In;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public currentSelection Selection
        {
            get
            {
                return _selection;
            }
            set
            {
                if (value != _selection)
                {
                    _selection = value;
                    NotifyPropertyChanged("Selection");
                    this.IsDataLoaded = false;
                    this.LoadData();
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            //User Service
            if (!this.IsDataLoaded)
            {
                ServiceReferenceWorkerz.WebServiceWorkerzSoapClient client = new ServiceReferenceWorkerz.WebServiceWorkerzSoapClient();
                if (_selection == currentSelection.In || _selection == currentSelection.Out)
                {
                    
                    client.GetWorkerzInAndOutCompleted += new EventHandler<ServiceReferenceWorkerz.GetWorkerzInAndOutCompletedEventArgs>(client_GetWorkerzInAndOutCompleted);
                    

                    client.GetWorkerzInAndOutAsync();
                    
                    // Sample data; replace with real data
                    //this.Items.Add(new ItemViewModel() { ImageOne="jeff.jpg", LineOne = "Jeff Meyers", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
                    //this.Items.Add(new ItemViewModel() { ImageOne = "jeff.jpg", LineOne = "Huey Lewis", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
                }
                else
                {
                    client.GetWorkerzAllCompleted += new EventHandler<ServiceReferenceWorkerz.GetWorkerzAllCompletedEventArgs>(client_GetWorkerzAllCompleted);
                    
                    

                    client.GetWorkerzAllAsync();
                    
                    
                }
                
            }
        }

        void client_GetWorkerzAllCompleted(object sender, ServiceReferenceWorkerz.GetWorkerzAllCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error Connection to web service! Please try again later.");
                this.Items.Clear();
                this.Items.Add(new ItemViewModel()
                {
                    LineThree = string.Format("Error Connection to web service! Please try again later.")
                });
                return;
            }
            
            
            this.Items.Clear();
            var workers = e.Result;
            string imagePath;
            foreach (ServiceReferenceWorkerz.WebWorkerz w in workers)
            {
                
                imagePath = string.Format("http://iam.colum.edu/myIAM/workerz/picts/{0}.jpg", w.UserName);
                this.Items.Add(new ItemViewModel()
                {
                    ImageOne = imagePath,
                    Position = w.WorkerTypeName,
                    LineOne = string.Format("{0} {1}", w.FirstName, w.LastName),
                    LineTwo = string.Format("{0}", w.LocationName),
                    LineThree = string.Format("{0} - {1}", w.StartTimeString, w.EndTimeString),
                    PeopleID = w.PeopleID.ToString(),
                    UserName = string.Format("{0} {1}", w.FirstName, w.LastName)
                });
            }
            this.IsDataLoaded = true;
        }

        void client_GetWorkerzInAndOutCompleted(object sender, ServiceReferenceWorkerz.GetWorkerzInAndOutCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error Connection to web service! Please try again later.");
                this.Items.Clear();
                this.Items.Add(new ItemViewModel()
                {
                    LineThree = string.Format("Error Connection to web service! Please try again later.")
                });
                return;
            }
            
            this.Items.Clear();
            var workers = e.Result;
            foreach (ServiceReferenceWorkerz.WebWorkerz w in workers)
            {
                if (w.PunchedIn && _selection == currentSelection.In)
                {
                    this.Items.Add(new ItemViewModel()
                    {
                        ImageOne = string.Format("http://iam.colum.edu/myIAM/workerz/picts/{0}.jpg", w.UserName),
                        Position = w.WorkerTypeName,
                        LineOne = string.Format("{0} {1}", w.FirstName, w.LastName),
                        LineTwo = string.Format("{0}", w.LocationName),
                        LineThree = string.Format("{0} - {1}", w.StartTimeString, w.EndTimeString),
                        PeopleID = w.PeopleID.ToString(),
                        UserName = string.Format("{0} {1}", w.FirstName, w.LastName)
                    });
                }
                else
                {
                    if (!w.PunchedIn && _selection == currentSelection.Out)
                        this.Items.Add(new ItemViewModel()
                        {
                            ImageOne = string.Format("http://iam.colum.edu/myIAM/workerz/picts/{0}.jpg", w.UserName),
                            LineOne = string.Format("{0} {1}", w.FirstName, w.LastName),
                            LineTwo = string.Format("{0}", w.LocationName),
                            LineThree = string.Format("{0} - {1}", w.StartTimeString, w.EndTimeString),
                            PeopleID = w.PeopleID.ToString(),
                            UserName = string.Format("{0} {1}", w.FirstName, w.LastName)
                        });
                 
                }
            }
            this.IsDataLoaded = true;
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

        public enum currentSelection { In, Out, All}
    }
}