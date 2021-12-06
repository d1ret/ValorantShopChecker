using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ValAPINet
{
    
    public class GetImage
    {
        public string skinPNG { get; set; }
        public string responce { get; set; }
        public ImageSource skinbytes { get; set; }

        public static GetImage GetOffers(string skinUUUID)
        {
            GetImage ret = new GetImage();
            string url = $"https://valorant-api.com/v1/weapons/skinlevels/{skinUUUID}";
            RestClient client = new RestClient(url);
            client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);

            var responce = client.Execute(request);
            string responcecontent = responce.Content;
            ret = JsonConvert.DeserializeObject<GetImage>(responcecontent);
            JObject obj = JObject.FromObject(JsonConvert.DeserializeObject(responcecontent));
            ret.skinPNG = obj["data"].Value<string>("displayIcon");
            ret.responce = responcecontent;
            return ret;
           
        }
        public ImageSource GetImage2(string name)
        {
            GetImage ret = new GetImage();
            string uri = string.Format(name);
            return BitmapFrame.Create(new Uri(uri));
        }
    }

}
