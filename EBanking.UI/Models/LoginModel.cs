namespace EBanking.UI.Models
{
    public class LoginModel : BaseModel
    {
        public string Email { get; set; } = "123@gmail.com";

        public string Password { get; set; } = "2222";

        #region Validacija 
        public string EmailError { get; set; }
        public string PasswordError { get; set; }
        #endregion
    }
}
