using EBanking.DataAccess.Modeli;
using EBanking.DataAccess.Repozitorijumi;
using EBanking.Services.Modeli;
using System.Collections.Generic;

namespace EBanking.Services.Implementacija
{
    public class TransakcijaService : ITransakcijaService
    {
        private readonly IRepozitorijumTransakcija _repozitorijumTransakcija;

        public TransakcijaService(IRepozitorijumTransakcija repozitorijumTransakcija)
        {
            _repozitorijumTransakcija = repozitorijumTransakcija;
        }

        public void CreateTransakcija(TransakcijaModel transakcijaModel)
        {
            _repozitorijumTransakcija.CreateTransakcija(new Transakcija
            { 
                BrojKartice = transakcijaModel.BrojKartice ?? "/",
                BrojRacuna = transakcijaModel.BrojRacuna,
                BrojRacunaSekundarnogAktera = transakcijaModel.BrojRacunaSekundarnogAktera,
                NazivSekundarnogAktera = transakcijaModel.NazivSekundarnogAktera,
                BalansNakonTransakcije = transakcijaModel.BalansNakonTransakcije,
                KolicinaNovca = transakcijaModel.KolicinaNovca,
                Datum = transakcijaModel.Datum
            });
        }
        public List<TransakcijaModel> GetTransakcijeByBrojRacuna(string brojRacuna) {
            List<Transakcija> listaTransakcija = new List<Transakcija>();
            List<TransakcijaModel> result = new List<TransakcijaModel>();
            listaTransakcija = _repozitorijumTransakcija.GetTransakcijeByBrojRacuna(brojRacuna);
            foreach (Transakcija transakcija in listaTransakcija) {
                result.Add(new TransakcijaModel {
                    IdTransakcije = transakcija.IdTransakcije,
                    BrojRacuna = transakcija.BrojRacuna,
                    BrojKartice = transakcija.BrojKartice,
                    KolicinaNovca = transakcija.KolicinaNovca,
                    BalansNakonTransakcije = transakcija.BalansNakonTransakcije,
                    Datum = transakcija.Datum,
             NazivSekundarnogAktera = transakcija.NazivSekundarnogAktera,
             BrojRacunaSekundarnogAktera = transakcija.BrojRacunaSekundarnogAktera,
                
                }) ;       
                                                }
            return result;
        }


    }
}
