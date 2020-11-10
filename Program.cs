using System;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;


namespace SmiteAPIWebsite
{
    class Program
    {

        static void Main(string[] args)
        {
            CreateSession();
            GetLeagueLeaderboard("504", "27");

        }

        private static void CreateSession()
        {
            var signature = GetMD5Hash(Dev.id + "createsession" + Dev.authKey + Dev.timeStamp);

            WebRequest request = WebRequest.Create(Dev.urlPrefix + "createsessionjson/" + Dev.id + "/" + signature + "/" + Dev.timeStamp);

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
                    Dev.session = g.session_id;
                }
        }

        private static void GetGodsInfo()
        {
            var signature = GetMD5Hash(Dev.id + "getgods" + Dev.authKey + Dev.timeStamp);

            WebRequest request = WebRequest.Create(Dev.urlPrefix + "getgodsjson/" + Dev.id + "/" + signature + "/" + Dev.session + "/" + Dev.timeStamp + "/" + Dev.languageCode);

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();
            
            System.Console.WriteLine(responseFromServer);

            using (var web = new WebClient())
                {
                    web.Encoding = System.Text.Encoding.UTF8;
                    var jsonString = responseFromServer;
                    var gods = JsonSerializer.Deserialize<List<Gods>>(jsonString);

                    foreach (Gods g in gods)
                    {
                        System.Console.WriteLine(g.Name);
                    }
                }


        }
     
        private static string GetPlayerId(string playerName)
        {
            string jsonInfo = ApiCall("getplayeridbyname", playerName);

            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerInfo = JsonSerializer.Deserialize<List<PlayerIdInfo>>(jsonString);

                return playerInfo[0].player_id.ToString();
            }
        }

        private static void GetPlayerInfo(string playerName)
        {
            string jsonInfo = ApiCall("getplayer", playerName);

            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerInfo = JsonSerializer.Deserialize<List<PlayerInfoBase>>(jsonString);
                System.Console.WriteLine(playerInfo);
            }

        }

        private static void GetMatchHistory(string playerName)
        {
            string jsonInfo = ApiCall("getmatchhistory", playerName);

            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerMatchHistory = JsonSerializer.Deserialize<List<MatchHistory>>(jsonString);

            }
        }
        

        private static void GetLeagueLeaderboard(string queue, string tier)
        {
            var signature = GetMD5Hash(Dev.id + "getleagueleaderboard" + Dev.authKey + Dev.timeStamp);

            WebRequest request = WebRequest.Create(Dev.urlPrefix + "getleagueleaderboardjson/" + Dev.id + "/" + signature + "/" + Dev.session + "/" + Dev.timeStamp + "/" + queue + "/" + tier + "/" + "6");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            System.Console.WriteLine(responseFromServer);

            reader.Close();
            response.Close();
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
    
        private static string ApiCall(string requestType, string playerName = "")
            {
                var signature = GetMD5Hash(Dev.id + requestType + Dev.authKey + Dev.timeStamp);

                WebRequest request = WebRequest.Create(Dev.urlPrefix + requestType + "json/" + Dev.id + "/" + signature + "/" + Dev.session + "/" + Dev.timeStamp + "/" + playerName);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return responseFromServer;
            }
    }

        
}
