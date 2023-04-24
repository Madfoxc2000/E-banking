using EBanking.DataAccess.Repozitorijumi;

namespace EBanking.Services.Implementacija
{
    public class KorisnikService : IKorisnikService
    {
        private readonly IRepozitorijumKorisnika _repozitorijumKorisnika;

        public KorisnikService(IRepozitorijumKorisnika repozitorijumKorisnika)
        {
            _repozitorijumKorisnika = repozitorijumKorisnika;
        }

        public int Login(string email, string password)
        {
            return _repozitorijumKorisnika.IsValidKorisnik(email, password);
        }

        public bool ProveraKorisnika(string email, string korisnickiPin)
        {
            return _repozitorijumKorisnika.ProveraKorisnika(email, korisnickiPin);
        }

        public void UpdateLozinkeKorisnika(string email, string korisnickiPin, string lozinka)
        {
            _repozitorijumKorisnika.UpdateLozinkeKorisnika(email, korisnickiPin, lozinka);
        }
    }
}
