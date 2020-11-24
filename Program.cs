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
            // GetGodRanks("its the flea");
            // GetLeagueLeaderboard("504", "27");

            PlayerQueueStats("xxmonstinatorxx", "504");
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
     
        private static string SearchPlayer(string playerName)
        {
            string jsonInfo = ApiCallWithName("searchplayers", playerName);

            using (var web = new WebClient())
                {
                    web.Encoding = System.Text.Encoding.UTF8;
                    var jsonString = jsonInfo;
                    var playerInfo = JsonSerializer.Deserialize<List<BasePlayerInfo>>(jsonString);

                    return playerInfo[0].player_id.ToString();
                }
        }

        private static void GetPlayerInfo(string playerName)
        {
            string playerId = SearchPlayer(playerName);

            string jsonInfo = ApiCallWithId("getplayer", playerId);

            System.Console.WriteLine(jsonInfo);

            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerInfo = JsonSerializer.Deserialize<List<PlayerInfo>>(jsonString);
            }

        }

        private static void PlayerQueueStats(string playerName, string queue)
        {
            string playerId = SearchPlayer(playerName);

            var signature = GetMD5Hash(Dev.id + "getqueuestats" + Dev.authKey + Dev.timeStamp);

                WebRequest request = WebRequest.Create(Dev.urlPrefix + "getqueuestatsjson/" + Dev.id + "/" + signature + "/" + Dev.session + "/" + Dev.timeStamp + "/" + playerId + "/" + queue);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string jsonInfo = reader.ReadToEnd();

                reader.Close();
                response.Close();
            
            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerInfo = JsonSerializer.Deserialize<List<PlayerQueueStats>>(jsonString);
            }
        }

        private static void GetMatchHistory(string playerName)
        {
            string playerId = SearchPlayer(playerName);

            string jsonInfo = ApiCallWithId("getmatchhistory", playerId);

            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerMatchHistory = JsonSerializer.Deserialize<List<MatchHistory>>(jsonString);

            }
        }
        
        private static void GetMatchDetails(string matchId)
        {
            string jsonInfo = ApiCallWithId("getmatchdetails", matchId);

            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerMatchHistory = JsonSerializer.Deserialize<List<MatchDetails>>(jsonString);

            }
        }

        private static void GetGodRanks(string playerName)
        {
            string playerId = SearchPlayer(playerName);

            string jsonInfo = ApiCallWithId("getgodranks", playerId);

            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerInfo = JsonSerializer.Deserialize<List<GodRanks>>(jsonString);
            }
        }
        
        private static void GetLeagueLeaderboard(string queue, string tier)
        {
            var signature = GetMD5Hash(Dev.id + "getleagueleaderboard" + Dev.authKey + Dev.timeStamp);

            WebRequest request = WebRequest.Create(Dev.urlPrefix + "getleagueleaderboardjson/" + Dev.id + "/" + signature + "/" + Dev.session + "/" + Dev.timeStamp + "/" + queue + "/" + tier + "/" + Dev.seasonRound);

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string jsonInfo = reader.ReadToEnd();

            reader.Close();
            response.Close();

            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = jsonInfo;
                var playerInfo = JsonSerializer.Deserialize<List<TopRankedPlayers>>(jsonString);
            }
        }
        
        private static string GetMD5Hash(string input) 
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            bytes = md5.ComputeHash(bytes);
            var sb = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    
        private static string ApiCallWithId(string requestType, string playerId)
            {
                var signature = GetMD5Hash(Dev.id + requestType + Dev.authKey + Dev.timeStamp);

                WebRequest request = WebRequest.Create(Dev.urlPrefix + requestType + "json/" + Dev.id + "/" + signature + "/" + Dev.session + "/" + Dev.timeStamp + "/" + playerId);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return responseFromServer;
            }
    
        private static string ApiCallWithName(string requestType, string playerName)
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
    
    
    
    //Deprecated
        private static string GetPlayerId(string playerName)
            {
                var signature = GetMD5Hash(Dev.id + "getplayeridbyname" + Dev.authKey + Dev.timeStamp);

                WebRequest request = WebRequest.Create(Dev.urlPrefix + "getplayeridbyname" + "json/" + Dev.id + "/" + signature + "/" + Dev.session + "/" + Dev.timeStamp + "/" + playerName);

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
                    var playerInfo = JsonSerializer.Deserialize<List<PlayerIdInfo>>(jsonString);

                    return playerInfo[0].player_id.ToString();
                }
            }

        private static string GetConsolePlayerId(string gamertag, string portalId)
        {
            var signature = GetMD5Hash(Dev.id + "getplayeridsbygamertag" + Dev.authKey + Dev.timeStamp);

                WebRequest request = WebRequest.Create(Dev.urlPrefix + "getplayeridsbygamertag" + "json/" + Dev.id + "/" + signature + "/" + Dev.session + "/" + Dev.timeStamp + "/" + portalId + "/" + gamertag);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();
                
                Console.WriteLine(responseFromServer);

                using (var web = new WebClient())
                {
                    web.Encoding = System.Text.Encoding.UTF8;
                    var jsonString = responseFromServer;
                    var playerInfo = JsonSerializer.Deserialize<List<PlayerIdInfo>>(jsonString);

                    return playerInfo[0].player_id.ToString();
                }
        }
    }      
}
