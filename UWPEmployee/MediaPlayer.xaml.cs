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
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Reflection;
using Windows.Media.Core;
using System.Collections.ObjectModel;
using UWPEmployee.Models;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPEmployee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MediaPlayer : Page
    {
        public ObservableCollection<Course> Courses { get; set; }
        public MediaPlayer()
        {
            this.InitializeComponent();
            Courses = new ObservableCollection<Course>();
        }

        private async void getAllCourse()
        {

            await CourseManager.GetAllCourseAsnc(Courses);

        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {

            
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MyCourseProgressRing.IsActive = true;
            MyCourseProgressRing.Visibility = Visibility.Visible;
            getAllCourse();
            MyCourseProgressRing.Visibility = Visibility.Collapsed;
            MyCourseProgressRing.IsActive = false;

            //var value = (string)e.Parameter;
            //var Strvalue = String.Format("http://localhost:87/{0}.mp4", value);
            //System.Uri manifestUri = new Uri(Strvalue);
            //MyMediaPlayer.Source = MediaSource.CreateFromUri(manifestUri);
            //MyMediaPlayer.MediaPlayer.Play();

        }


    }
}
