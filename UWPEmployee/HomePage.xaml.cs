using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPEmployee.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPEmployee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public ObservableCollection<RootObject> EmployeeCharacters { get; set; }
        private List<String> Suggestions;



        public HomePage()
        {
            this.InitializeComponent();
            EmployeeCharacters = new ObservableCollection<RootObject>();
        }


        protected   override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            getAll();

        }

        private async void getAll()
        {
            MyProgressRing.IsActive = true;
            MyProgressRing.Visibility = Visibility.Visible;
            await EmployeeManager.GetAllEmployeesAsnc(EmployeeCharacters);
            MyProgressRing.Visibility = Visibility.Collapsed;
            MyProgressRing.IsActive = false;
        }

        private async void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

            if (String.IsNullOrEmpty(sender.Text)) getAll();

            await EmployeeManager.GetAllEmployeesAsnc(EmployeeCharacters);
            Suggestions = EmployeeCharacters
                .Where(p => p.FirstName.Contains(sender.Text))
                .Select(p => p.FirstName)
                .ToList();
            SearchAutoSuggestBox.ItemsSource = Suggestions;

        }

        private async void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

            MyProgressRing.IsActive = true;
            MyProgressRing.Visibility = Visibility.Visible;
            await EmployeeManager.GetEmployeesByNameAsnc(EmployeeCharacters,sender.Text);
            MyProgressRing.Visibility = Visibility.Collapsed;
            MyProgressRing.IsActive = false;
            

        }

    }
}
