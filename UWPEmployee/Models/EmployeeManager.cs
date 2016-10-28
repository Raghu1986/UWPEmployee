using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Windows.Data.Json;
using Windows.UI.Xaml.Media.Imaging;


namespace UWPEmployee.Models
{
    
    public class EmployeeManager
    {
        private const string url = "http://localhost/api/employees";
        //public static async Task PopulateEmployeeCharactersAsync(ObservableCollection<RootObject> EmployeeCharacters)
        //{
        //    string url = "http://localhost/api/employees";



        //    var jsonString = await CallEmployeeAsync(url);

        //  //  GetAllEmployees(EmployeeCharacters, jsonString);

        //    //var allEmployess = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
        //    //EmployeeCharacters.Clear();
        //    ////var filteredSounds = allEmployess.Where(p => p.Department == "java").ToList();
        //    //allEmployess.ForEach(p => EmployeeCharacters.Add(p));

        //    //JsonArray root = JsonValue.Parse(jsonString).GetArray();
        //    //for (uint i = 0; i < root.Count; i++)
        //    //{
        //    //    int EmpNo = Convert.ToInt32(root.GetObjectAt(i).GetNamedNumber("EmpNo"));
        //    //    string FirstName = root.GetObjectAt(i).GetNamedString("FirstName");
        //    //    string LastName = root.GetObjectAt(i).GetNamedString("LastName");
        //    //    string Gender = root.GetObjectAt(i).GetNamedString("Gender");
        //    //    string EMedia = root.GetObjectAt(i).GetNamedString("EMedia");

        //    //    string FatherName = root.GetObjectAt(i).GetNamedString("FatherName");
        //    //    string MotherName = root.GetObjectAt(i).GetNamedString("MotherName");
        //    //    DateTime Dob = Convert.ToDateTime(root.GetObjectAt(i).GetNamedString("Dob"));
        //    //    string Personalemail = root.GetObjectAt(i).GetNamedString("Personalemail");
        //    //    string ProffesionalEmail = root.GetObjectAt(i).GetNamedString("ProffesionalEmail");
        //    //    string MobileNum = root.GetObjectAt(i).GetNamedString("MobileNum");
        //    //    string Department = root.GetObjectAt(i).GetNamedString("Department");
        //    //    //string image1 = root.GetObjectAt(i).GetNamedString("image");
        //    //    var chan = new RootObject
        //    //    {
        //    //        EmpNo = EmpNo,
        //    //        FirstName = FirstName,
        //    //        LastName = LastName,
        //    //        Gender = Gender,
        //    //        EMedia = EMedia,
        //    //        FatherName = FatherName,
        //    //        MotherName = MotherName,
        //    //        Dob = Dob,
        //    //        Personalemail = Personalemail,
        //    //        ProffesionalEmail = ProffesionalEmail,
        //    //        MobileNum = MobileNum,
        //    //        Department = Department

        //    //    };
        //    //    EmployeeCharacters.Add(chan);

        //    //}

        //}

        private async static Task<string> CallEmployeeAsync(string url)
        {
            var http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync(new Uri(url));
            //var jsonString = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();

        }

        public async static Task GetAllEmployeesAsnc(ObservableCollection<RootObject> EmployeeCharacters)
        {
            
            var jsonString = await CallEmployeeAsync(url);
            var allEmployess = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
            EmployeeCharacters.Clear();
            allEmployess.ForEach(p => EmployeeCharacters.Add(p));
        }

        public async static Task GetEmployeesByNameAsnc(ObservableCollection<RootObject> EmployeeCharacters, string FirstName)
        {

            var jsonString = await CallEmployeeAsync(url);
            var allEmployess = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
            var filteredEmployees = allEmployess.Where(p => p.FirstName == FirstName).ToList();
            EmployeeCharacters.Clear();
            filteredEmployees.ForEach(p => EmployeeCharacters.Add(p));
        }

        public async static Task GetDeprtEmployeesAsnc(ObservableCollection<RootObject> EmployeeCharacters,string Department)
        {
            
            var jsonString = await CallEmployeeAsync(url);
            var allEmployess = JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
            var filteredEmployees = allEmployess.Where(p => p.Department == Department).ToList();
            EmployeeCharacters.Clear();
            filteredEmployees.ForEach(p => EmployeeCharacters.Add(p));
        }



    }
}
