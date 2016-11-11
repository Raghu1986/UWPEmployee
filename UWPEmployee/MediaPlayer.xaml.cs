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

        public ObservableCollection<Media> Medias { get; set; }

        public string CourseName;
        public MediaPlayer()
        {
            this.InitializeComponent();
            Courses = new ObservableCollection<Course>();
            Medias = new ObservableCollection<Media>();
        }

        private async void getAllCourse()
        {

            await CourseManager.GetAllCourseAsnc(Courses);

        }

        private async void getAllMedia()
        {

            await MediaManager.GetAllMediaAsnc(Medias);

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //MyCourseProgressRing.IsActive = true;
            //MyCourseProgressRing.Visibility = Visibility.Visible;
            getAllCourse();
            //getAllMedia();
            //MyCourseProgressRing.Visibility = Visibility.Collapsed;
            //MyCourseProgressRing.IsActive = false;
            MediaListSplitView.Visibility = Visibility.Collapsed;
            VideoButton.Visibility = Visibility.Collapsed;
            MyMediaPlayer.Visibility = Visibility.Collapsed;


        }

        private async void CourseGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

            MyMediaPlayer.Visibility = Visibility.Collapsed;
            var value = (Course)e.ClickedItem;
            CourseName = value.CourseType;
            await MediaManager.GetCatMediaAsnc(Medias, CourseName);
            MediaListSplitView.Visibility = Visibility.Visible;
            VideoButton.Visibility = Visibility.Visible;
            MediaListSplitView.IsPaneOpen = true;

        }
        private void MediaListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            MyMediaPlayer.Visibility = Visibility.Collapsed;
            var value = (Media)e.ClickedItem;
            var Strvalue = String.Format(" http://localhost:87/{0}/{1}", CourseName, value.MediaUri);
            System.Uri manifestUri = new Uri(Strvalue);
            MyMediaPlayer.Source = MediaSource.CreateFromUri(manifestUri);
            MyMediaPlayer.MediaPlayer.Play();
            MyMediaPlayer.Visibility = Visibility.Visible;
            MediaListSplitView.IsPaneOpen = !MediaListSplitView.IsPaneOpen;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MediaListSplitView.IsPaneOpen = !MediaListSplitView.IsPaneOpen;
        }
    }
}
