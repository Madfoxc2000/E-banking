using EBanking.DataAccess.Modeli;
using EBanking.DataAccess.Repozitorijumi;
using EBanking.Services.Modeli;

namespace EBanking.Services.Implementacija
{
    public class RacunService : IRacunService
    {
        private readonly IRepozitorijumTekucegRacuna _repozitorijumRacuna;
        private readonly IRepozitorijumTransakcija _repozitorijumTransakcija;
        private readonly IRepozitorijumMenjacnica _repozitorijumMenjacnica;

        public RacunService(IRepozitorijumTekucegRacuna repozitorijumRacuna, IRepozitorijumTransakcija repozitorijumTransakcija, IRepozitorijumMenjacnica repozitorijumMenjacnica)
        {
            _repozitorijumRacuna = repozitorijumRacuna;
            _repozitorijumTransakcija = repozitorijumTransakcija;
            _repozitorijumMenjacnica = repozitorijumMenjacnica;
        }

        public async Task<RacunModel> GetRacunByBrojRacuna(string brojRacuna)
        {
            TekuciRacun racun = await _repozitorijumRacuna.GetRacunByBrojRacuna(brojRacuna);

            return new RacunModel
            {
                BrojRacuna = racun.BrojRacuna,
                Balans = racun.Balans,
                DatumKreiranja = racun.DatumKreiranja,
                IdKorisnika = racun.IdKorisnika,
                Tip = racun.Tip,
                Valuta = racun.Valuta
            };
        }

        //Pozivamo repo za izvlacenje racuna i mapiramo ih na modele u sloju servisa
        public List<RacunModel> GetRacunForKorsnik(int idKorisnika)
        {
            List<TekuciRacun> racuni = _repozitorijumRacuna.GetRacuniByKorsnikId(idKorisnika);

            List<RacunModel> result = new List<RacunModel>();
            List<TransakcijaModel> transakcije = new List<TransakcijaModel>();

            foreach (var racun in racuni)
            {
                var transakcijeResults = _repozitorijumTransakcija.GetTransakcijeByBrojRacuna(racun.BrojRacuna);

                transakcije = new List<TransakcijaModel>();

                foreach(var transakcija in transakcijeResults)
                {
                    transakcije.Add(new TransakcijaModel
                    {
                        IdTransakcije = transakcija.IdTransakcije,
                        BrojRacuna = transakcija.BrojRacuna,
                        BrojKartice = transakcija.BrojKartice,
                        KolicinaNovca = transakcija.KolicinaNovca,
                        BalansNakonTransakcije = transakcija.BalansNakonTransakcije,
                        Datum = transakcija.Datum,
                        NazivSekundarnogAktera = transakcija.NazivSekundarnogAktera,
                        BrojRacunaSekundarnogAktera = transakcija.BrojRacunaSekundarnogAktera
                    });
                };

                result.Add(new RacunModel
                {
                    BrojRacuna = racun.BrojRacuna,
                    Balans = racun.Balans,
                    DatumKreiranja = racun.DatumKreiranja,
                    IdKorisnika = racun.IdKorisnika,
                    Tip = racun.Tip,
                    Valuta = racun.Valuta,
                    Korisnik = new KorisnikModel
                    {
                        BrojLicneKarte = racun.Korisnik.BrojLicneKarte,
                        DatumRodjenja = racun.Korisnik.DatumRodjenja,
                        Email = racun.Korisnik.Email,
                        Ime = racun.Korisnik.Ime,
                        Prezime = racun.Korisnik.Prezime,
                        Telefon = racun.Korisnik.Telefon,
                    },
                    Transakcije = transakcije,
                    Kursevi = MapirajKurseve(racun.Valuta)
                });
            }

            return result;
        }

        public List<MenjacnicaModel> MapirajKurseve(string valutaRacuna)
        {
            var results = _repozitorijumMenjacnica.GetMenjacnicaByValuta(valutaRacuna);

            var modeli = new List<MenjacnicaModel>();

            foreach(var result in results)
            {
                modeli.Add(new MenjacnicaModel
                {
                    Valuta = result.Valuta,
                    Vrednost = result.Vrednost
                });
            }

            return modeli;
        }

        public bool IsValidRacun(string brojRacuna)
        {
            return _repozitorijumRacuna.IsValidRacun(brojRacuna);
        }

        public void UpdateBalance(double noviBalans, string brojRacuna)
        {
            _repozitorijumRacuna.UpdateBalance(noviBalans, brojRacuna);
        }
    }
}
