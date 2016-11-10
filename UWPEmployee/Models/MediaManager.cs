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
    public class MediaManager
    {
        private const string url = "http://localhost:84/api/Media";

        private async static Task<string> CallMediaAsync(string url)
        {
            var http = new HttpClient();
            HttpResponseMessage response = await http.GetAsync(new Uri(url));
            //var jsonString = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();

        }

        public async static Task GetAllMediaAsnc(ObservableCollection<Media> Medias)
        {

            var jsonString = await CallMediaAsync(url);
            var allMedias = JsonConvert.DeserializeObject<List<Media>>(jsonString);
            Medias.Clear();
            allMedias.ForEach(p => Medias.Add(p));
        }
    }
}
