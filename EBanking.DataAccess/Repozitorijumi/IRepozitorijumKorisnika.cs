namespace EBanking.DataAccess.Repozitorijumi
{
    public interface IRepozitorijumKorisnika
    {
        Modeli.Korisnik GetKorisnikById(int id);

        int IsValidKorisnik(string email, string password);

        List<Modeli.Korisnik> GetAllKorisnici();

        int AddKorisnik(Modeli.Korisnik korisnik);

        void UpdateLozinkeKorisnika(string email, string korisnickiPin, string lozinka);

        bool ProveraKorisnika(string email, string korisnickiPin);
    }
}
