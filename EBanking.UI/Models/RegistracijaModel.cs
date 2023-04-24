namespace EBanking.UI.Models
{
    public class RegistracijaModel : BaseModel
    {
        public string Email { get; set; }
        public string KorisnickiPin { get; set; }
        public string Lozinka { get; set; }
        public string PonoviLozinku { get; set; }

        public string Label { get; set; }

        #region Validacija
        public string EmailError { get; set; }
        public string KorisnickiPinError { get; set; }
        public string LozinkaError { get; set; }
        public string PonoviLozinkuError { get; set; }
        #endregion
    }
}
