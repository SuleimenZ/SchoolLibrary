using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolLibrary.Models
{
    public class Book
    {
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("price")]
        public double price { get; set; }
        [NotMapped]
        [JsonProperty("image")]
        public string imageLink{ get { return GetImageLink(); } }
        [NotMapped]
        [JsonProperty("subtitle")]
        public string subtitle { get { return GetSubtitle(); } }

        private string GetSubtitle()
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"https://api.itbook.store/1.0/search/{title}".Replace("#","sharp");
                var task = httpClient.GetAsync(url);
                task.Wait();
                var result = task.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();
                    content.Wait();
                    var jsonString = content.Result;
                    var parsedObject = JObject.Parse(jsonString);
                    var linqList = parsedObject.Last.First.ToArray();
                    foreach (var linq in linqList)
                    {
                        JObject obj = JObject.Parse(linq.ToString());
                        if (obj["title"].ToString() == title)
                        {
                            return obj["subtitle"].ToString();
                        }
                    }
                    return "";
                }
                return "";
            }
        }

        private string GetImageLink()
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"https://api.itbook.store/1.0/search/{title}".Replace("#", "sharp");
                var task = httpClient.GetAsync(url);
                task.Wait();
                var result = task.Result;
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();
                    content.Wait();
                    var jsonString = content.Result;
                    var parsedObject = JObject.Parse(jsonString);
                    var linqList = parsedObject.Last.First.ToArray();
                    foreach(var linq in linqList)
                    {
                        JObject obj = JObject.Parse(linq.ToString());
                        if(obj["title"].ToString() == title)
                        {
                            return obj["image"].ToString();
                        }
                    }
                    return "";
                }
                return "";
            }
        }
    }
}
