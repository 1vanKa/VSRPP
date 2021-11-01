using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bntu.vsrpp.ikarpovich.Core
{
    public class HttpService
    {
        public String url;

        public HttpService(String url)
        {
            this.url = url;
        }

        public T getObject<T>()
        {
            String response = getStringResponse();
            if ("Not Found".Equals(response)) return default(T);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T objects = serializer.Deserialize<T>(response);
            return objects;
        }

        public String getStringResponse()
        {
            String responseString = String.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return "Not Found";
            }
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }
            return responseString;
        }
    }
}
