using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        string devKey = "3646"; // devKey goes here
        string authKey = "D478B2446D7B462D889F936197667A06";  // authKey goes here 
        string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        string urlPrefix = "http://api.smitegame.com/smiteapi.svc/";


        string signature = "";
        string session = "";

        public Form1()
        {
            InitializeComponent();
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

        private void buttonCreateSession_Click(object sender, EventArgs e)
        {
            // Get Signature that is specific to "createsession"
            //
            signature = GetMD5Hash(devKey + "createsession" + authKey + timestamp);

            // Call the "createsession" API method & wait for synchronous response
            //
            WebRequest request = WebRequest.Create(urlPrefix + "createsessionjson/" + devKey + "/" + signature + "/" + timestamp);
            WebResponse response = request.GetResponse();
         
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
           
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();
          
            // Parse returned JSON into "session" data
            //
            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = responseFromServer;
                var jss = new JavaScriptSerializer();
                var g = jss.Deserialize<SessionInfo>(jsonString);

                session = g.session_id;

                MessageBox.Show(session);
            }
        }

        private void buttonGetGods_Click(object sender, EventArgs e)
        {
            // Get Signature that is specific to "getgods"
            //
            signature = GetMD5Hash(devKey + "getgods" + authKey + timestamp);


            // Call the "getgods" API method & wait for synchronous response
            //
            string languageCode = "1";
           
            WebRequest request = WebRequest.Create(urlPrefix + "getgodsjson/" + devKey + "/" + signature + "/" + session + "/" + timestamp + "/" + languageCode);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
          
            reader.Close();
            response.Close();

            // Parse returned JSON into "gods" data
            //
            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = responseFromServer;
                var jss = new JavaScriptSerializer();
                var GodsList = jss.Deserialize<List<Gods>>(jsonString);
                string GodsListStr = "";

                foreach (Gods x in GodsList)
                    GodsListStr = GodsListStr + ", " + x.Name;

                MessageBox.Show("Here are the Gods: " + GodsListStr);
            }

        }

        public class SessionInfo
        {
            public string ret_msg { get; set; }
            public string session_id { get; set; }
            public string timestamp { get; set; }
           
        }

        public class Menuitem
        {
            public string description { get; set; }
            public string value { get; set; }
        }

        public class Rankitem
        {
            public string description { get; set; }
            public string value { get; set; }
        }

        public class AbilityDescription
        {
            public string description { get; set; }
            public string secondaryDescription { get; set; }
            public List<Menuitem> menuitems { get; set; }
            public List<Rankitem> rankitems { get; set; }
            public string cooldown { get; set; }
            public string cost { get; set; }
        }

        public class AbilityRoot
        {
            public AbilityDescription itemDescription { get; set; }
        }

        public class Gods
        {
            public int abilityId1 { get; set; }
            public int abilityId2 { get; set; }
            public int abilityId3 { get; set; }
            public int abilityId4 { get; set; }
            public int abilityId5 { get; set; }
            public AbilityRoot abilityDescription1 { get; set; }
            public AbilityRoot abilityDescription2 { get; set; }
            public AbilityRoot abilityDescription3 { get; set; }
            public AbilityRoot abilityDescription4 { get; set; }
            public AbilityRoot abilityDescription5 { get; set; }
            public int id { get; set; }
            public string Pros { get; set; }
            public string Type { get; set; }
            public string Roles { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public string OnFreeRotation { get; set; }
            public string Lore { get; set; }
            public int Health { get; set; }
            public Double HealthPerLevel { get; set; }
            public Double Speed { get; set; }
            public Double HealthPerFive { get; set; }
            public Double HP5PerLevel { get; set; }
            public Double Mana { get; set; }
            public Double ManaPerLevel { get; set; }
            public Double ManaPerFive { get; set; }
            public Double MP5PerLevel { get; set; }
            public Double PhysicalProtection { get; set; }
            public Double PhysicalProtectionPerLevel { get; set; }
            public Double MagicProtection { get; set; }
            public Double MagicProtectionPerLevel { get; set; }
            public Double PhysicalPower { get; set; }
            public Double PhysicalPowerPerLevel { get; set; }
            public Double AttackSpeed { get; set; }
            public Double AttackSpeedPerLevel { get; set; }
            public string Pantheon { get; set; }
            public string Ability1 { get; set; }
            public string Ability2 { get; set; }
            public string Ability3 { get; set; }
            public string Ability4 { get; set; }
            public string Ability5 { get; set; }
            public string Item1 { get; set; }
            public string Item2 { get; set; }
            public string Item3 { get; set; }
            public string Item4 { get; set; }
            public string Item5 { get; set; }
            public string Item6 { get; set; }
            public string Item7 { get; set; }
            public string Item8 { get; set; }
            public string Item9 { get; set; }
            public int ItemId1 { get; set; }
            public int ItemId2 { get; set; }
            public int ItemId3 { get; set; }
            public int ItemId4 { get; set; }
            public int ItemId5 { get; set; }
            public int ItemId6 { get; set; }
            public int ItemId7 { get; set; }
            public int ItemId8 { get; set; }
            public int ItemId9 { get; set; }
            public string ret_msg { get; set; }
        }
    }
}
