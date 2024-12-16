namespace ShopAPI.Request
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
    }

    public class ChangePasswordModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

