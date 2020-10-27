using System;
using System.Net;

namespace SmiteAPIWebsite
{
    class Program
    {

        static void Main(string[] args)
        {
            var responseFormat = "JSON";

            string devId = "3646";

            string authKey = "D478B2446D7B462D889F936197667A06";

            string utcDate = DateTime.UtcNow.ToString("yyyy" + "MM" + "dd" + "HH" + "mm" + "ss");
            
            var signature = GetMD5Hash(devId + "createsession" + authKey + utcDate);

            string urlPrefix = "http://api.smitegame.com/smiteapi.svc/";

            WebRequest request = WebRequest.Create(urlPrefix + "createsession" + responseFormat + "/" + devId + "/" + signature + "/" + utcDate);


            System.Console.WriteLine(request);
        }

        private static string GetMD5Hash(string input) {
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
