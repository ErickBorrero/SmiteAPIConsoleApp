using System;


namespace SmiteApiWebsite
{

    public class TopConquestPlayers
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public int Rank_Stat { get; set; }
        public int Rank_Variance { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public string player_id { get; set; }
        public object ret_msg { get; set; }
    }

}