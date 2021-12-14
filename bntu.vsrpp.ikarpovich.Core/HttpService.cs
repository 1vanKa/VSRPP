// <copyright file="HttpService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Ikarpovich.Core
{
    using System.IO;
    using System.Net;
    using Nancy.Json;

    /// <summary>
    /// Has methods for getting HTTP response.
    /// </summary>
    public class HttpService
    {
        private string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpService"/> class.
        /// </summary>
        /// <param name="url">url address.</param>
        public HttpService(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Gets object from URL.
        /// </summary>
        /// <typeparam name="T">Type of object from URL.</typeparam>
        /// <returns>Object from URL.</returns>
        public T GetObject<T>()
        {
            string response = this.GetStringResponse();
            if ("Not Found".Equals(response))
            {
                return default(T);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            T objects = serializer.Deserialize<T>(response);
            return objects;
        }

        private string GetStringResponse()
        {
            string responseString = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.url);
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
            using (StreamReader reader = new(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return responseString;
        }
    }
}
