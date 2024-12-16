namespace ShopAPI.Request
{
    public class UpdateUserRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }

    }
}
