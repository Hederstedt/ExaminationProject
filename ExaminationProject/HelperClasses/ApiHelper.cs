using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExaminationProject.HelperClasses
{
    public static class ApiHelper
    {
        public static HttpClient client = new HttpClient();

        //public static T GetJson<T>(this IDictionary<string, string> parameters, string url, HttpMethod method = null, T fallBack = default(T)) where T : class
        //{
        //    var Request = new HttpRequestMessage(method ?? HttpMethod.Post, url);

        //    Request.Content = new FormUrlEncodedContent(parameters);

        //    return client.SendAsync(Request).Result.FromJson(fallBack);
        //}

        //public static T FromJson<T>(this HttpResponseMessage response, T fallBack = default(T)) where T : class
        //{
        //    return (response.IsSuccessStatusCode)
        //            ? response.Content
        //                    .ReadAsStringAsync()
        //                    .Result
        //                    .FromJson(fallBack)
        //            : fallBack;
        //}

        //public static T FromJson<T>(this string json, T fallBack = default(T)) where T : class
        //{
        //    var serializer = new DataContractJsonSerializer(typeof(T));
        //    using (var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(json)))
        //    {
        //        var data = (T)serializer.ReadObject(ms);
        //        return data ?? fallBack;
        //    }
        //}

        //public static T FromXml<T>(this string xml, T fallBack = default(T)) where T : class
        //{
        //    var serializer = new XmlSerializer(typeof(T));
        //    using (var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(xml)))
        //    {
        //        var data = (T)serializer.Deserialize(ms);
        //        return data ?? fallBack;
        //    }
        //}
    }
}
