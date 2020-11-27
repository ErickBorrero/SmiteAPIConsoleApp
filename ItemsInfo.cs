namespace SmiteAPIWebsite
{

    public class ItemsInfo
    {
        public string ActiveFlag { get; set; }
        public int ChildItemId { get; set; }
        public string DeviceName { get; set; }
        public int IconId { get; set; }
        public Itemdescription ItemDescription { get; set; }
        public int ItemId { get; set; }
        public int ItemTier { get; set; }
        public int Price { get; set; }
        public string RestrictedRoles { get; set; }
        public int RootItemId { get; set; }
        public string ShortDesc { get; set; }
        public bool StartingItem { get; set; }
        public string Type { get; set; }
        public string itemIcon_URL { get; set; }
        public object ret_msg { get; set; }
    }

    public class Itemdescription
    {
        public string Description { get; set; }
        public object[] Menuitems { get; set; }
        public string SecondaryDescription { get; set; }
    }

}