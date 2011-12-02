using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Data;

namespace WokerzApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Handle selection changed on ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MainListBox.SelectedIndex, UriKind.Relative));

            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Workerz In";
            App.ViewModel.Selection = MainViewModel.currentSelection.In;
        }

        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Workerz Out";
            App.ViewModel.Selection = MainViewModel.currentSelection.Out;
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Text = "Workerz All";
            App.ViewModel.Selection = MainViewModel.currentSelection.All;
        }
    }

    public class EmailConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string address = value as string;
            if (address != null)
            {
                return new Uri("mailto:" + address, UriKind.Absolute);
            }
            return new Uri("mailto:default@default.com", UriKind.Absolute);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}