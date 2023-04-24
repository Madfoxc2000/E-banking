namespace EBanking.Services
{
    public interface IKorisnikService
    {
        int Login(string email, string password);

        void UpdateLozinkeKorisnika(string email, string korisnickiPin, string lozinka);

        bool ProveraKorisnika(string email, string korisnickiPin);
    }
}
