namespace SmiteAPIWebsite
{
    public class PlayerStatus
    {
        public int Match { get; set; }
        public int match_queue_id { get; set; }
        public object personal_status_message { get; set; }
        public object ret_msg { get; set; }
        public int status { get; set; }
        public string status_string { get; set; }
    }
}