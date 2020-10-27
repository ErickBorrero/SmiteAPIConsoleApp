using System;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SmiteAPIWebsite
{
    class Program
    {

        static void Main(string[] args)
        {
            CreateSession(); 
            System.Console.WriteLine();
            Console.ReadLine();

        }

        private static void CreateSession()
        {
            var signature = GetMD5Hash(Dev.id + "createsession" + Dev.authKey + Dev.timeStamp);

            WebRequest request = WebRequest.Create(Dev.urlPrefix + "createsessionJson/" + Dev.id + "/" + signature + "/" + Dev.timeStamp);

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();

            using (var web = new WebClient())
                {
                    web.Encoding = System.Text.Encoding.UTF8;
                    var jsonString = responseFromServer;
                    var g = JsonSerializer.Deserialize<SessionInfo>(jsonString);
                }
        }

        private static string GetMD5Hash(string input) 
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            bytes = md5.ComputeHash(bytes);
            var sb = new System.Text.StringBuilder();
            foreach (byte b in bytes) {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
