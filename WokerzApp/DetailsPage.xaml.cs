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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using WokerzApp;
using Microsoft.Phone.Tasks;

namespace WokerzApp
{
    public partial class DetailsPage : PhoneApplicationPage
    {

        ServiceReferenceWorkerz.WorkerDetailDTO dto;
        int peopleID;
        string UserName, ImageOne;
        ItemDetailViewModel vm;
        
        
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            vm = new ItemDetailViewModel();
            
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                if (App.ViewModel.Items.Count > 0)
                {
                    var worker = App.ViewModel.Items[index];

                    ServiceReferenceWorkerz.WebServiceWorkerzSoapClient client = new ServiceReferenceWorkerz.WebServiceWorkerzSoapClient();
                    client.GetWorkerDetailsCompleted += new EventHandler<ServiceReferenceWorkerz.GetWorkerDetailsCompletedEventArgs>(client_GetWorkerDetailsCompleted);
                    peopleID = int.Parse(worker.PeopleID);
                    UserName = worker.UserName;
                    ImageOne = worker.ImageOne;
                    client.GetWorkerDetailsAsync(peopleID);
                    //DataContext = App.ViewModel.Items[index];
                }
                else
                {
                    //go back
                }
                
            }
        }

        void client_GetWorkerDetailsCompleted(object sender, ServiceReferenceWorkerz.GetWorkerDetailsCompletedEventArgs e)
        {
            dto = e.Result;
            vm.ImageOne = ImageOne;
            if (vm.ImageOne == "")
                vm.ImageOne = "IAMTreatment90x120.png";
            vm.UserFullName = UserName;
            vm.Email = dto.Email;
            vm.Position = dto.Position;
            vm.PeopleID = peopleID.ToString();
            vm.Phone = dto.Phone;
            vm.Skills = dto.Skills;
            vm.MondayHours = dto.MondayHours;
            vm.TuesdayHours = dto.TuesdayHours;
            vm.WednesdayHours = dto.WednesdayHours;
            vm.ThursdayHours = dto.ThursdayHours;
            vm.FridayHours = dto.FridayHours;
            vm.SaturdayHours = dto.SaturdayHours;
            vm.SundayHours = dto.SundayHours;
            
            DataContext = vm;
        }

        private void phoneHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallTask task =
              new PhoneCallTask();
            task.PhoneNumber = vm.Phone;
            task.Show();
        }

        private void emailHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
           EmailComposeTask emailcomposer = new EmailComposeTask();
            emailcomposer.To = string.Format("<a href=\"mailto:{0}\">{1}</a>", vm.Email, vm.Email);
             emailcomposer.Subject = "subject from test app";
            emailcomposer.Body = "";
            emailcomposer.Show();
        }
    }
}