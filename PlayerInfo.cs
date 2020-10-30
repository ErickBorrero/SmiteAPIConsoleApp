using System;
using System.Collections.Generic;


namespace SmiteAPIWebsite
{
    public class PlayerInfoBase
    {
        public List<PlayerInfo> Property1 { get; set; }
    }

    public class PlayerIdBase
    {
        public List<PlayerIdInfo> Property1 { get; set; }
    }

    public class PlayerIdInfo
    {
        public int player_id { get; set; }
        public string portal { get; set; }
        public string portal_id { get; set; }
        public string privacy_flag { get; set; }
        public object ret_msg { get; set; }
    }

    public class PlayerInfo
    {
        public int ActivePlayerId { get; set; }
        public string Avatar_URL { get; set; }
        public string Created_Datetime { get; set; }
        public int HoursPlayed { get; set; }
        public int Id { get; set; }
        public string Last_Login_Datetime { get; set; }
        public int Leaves { get; set; }
        public int Level { get; set; }
        public int Losses { get; set; }
        public int MasteryLevel { get; set; }
        public object MergedPlayers { get; set; }
        public int MinutesPlayed { get; set; }
        public string Name { get; set; }
        public string Personal_Status_Message { get; set; }
        public string Platform { get; set; }
        public float Rank_Stat_Conquest { get; set; }
        public float Rank_Stat_Conquest_Controller { get; set; }
        public float Rank_Stat_Duel { get; set; }
        public float Rank_Stat_Duel_Controller { get; set; }
        public float Rank_Stat_Joust { get; set; }
        public float Rank_Stat_Joust_Controller { get; set; }
        public Rankedconquest RankedConquest { get; set; }
        public Rankedconquestcontroller RankedConquestController { get; set; }
        public Rankedduel RankedDuel { get; set; }
        public Rankedduelcontroller RankedDuelController { get; set; }
        public Rankedjoust RankedJoust { get; set; }
        public Rankedjoustcontroller RankedJoustController { get; set; }
        public string Region { get; set; }
        public int TeamId { get; set; }
        public string Team_Name { get; set; }
        public int Tier_Conquest { get; set; }
        public int Tier_Duel { get; set; }
        public int Tier_Joust { get; set; }
        public int Total_Achievements { get; set; }
        public int Total_Worshippers { get; set; }
        public int Wins { get; set; }
        public string hz_gamer_tag { get; set; }
        public string hz_player_name { get; set; }
        public object ret_msg { get; set; }
    }

    public class Rankedconquest
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public float Rank_Stat { get; set; }
        public int Rank_Variance { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public object player_id { get; set; }
        public object ret_msg { get; set; }
    }

    public class Rankedconquestcontroller
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public float Rank_Stat { get; set; }
        public int Rank_Variance { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public object player_id { get; set; }
        public object ret_msg { get; set; }
    }

    public class Rankedduel
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public float Rank_Stat { get; set; }
        public int Rank_Variance { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public object player_id { get; set; }
        public object ret_msg { get; set; }
    }

    public class Rankedduelcontroller
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public float Rank_Stat { get; set; }
        public int Rank_Variance { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public object player_id { get; set; }
        public object ret_msg { get; set; }
    }

    public class Rankedjoust
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public float Rank_Stat { get; set; }
        public int Rank_Variance { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public object player_id { get; set; }
        public object ret_msg { get; set; }
    }

    public class Rankedjoustcontroller
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public float Rank_Stat { get; set; }
        public int Rank_Variance { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public object player_id { get; set; }
        public object ret_msg { get; set; }
    }
}