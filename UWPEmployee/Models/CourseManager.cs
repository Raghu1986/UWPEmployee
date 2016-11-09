using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace UWPEmployee.Models
{
    public class CourseManager
    {
        private const string url = "http://localhost:82/api/courses";

        private async static Task<string> CallCourseAsync(string url)
        {
            var http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync(new Uri(url));
            //var jsonString = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();

        }

        public async static Task GetAllCourseAsnc(ObservableCollection<Course> Courses)
        {

            var jsonString = await CallCourseAsync(url);
            var allCourses = JsonConvert.DeserializeObject<List<Course>>(jsonString);
            Courses.Clear();
            allCourses.ForEach(p => Courses.Add(p));
        }
    }
}
