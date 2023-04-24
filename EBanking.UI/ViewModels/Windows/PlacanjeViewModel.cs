using CommunityToolkit.Mvvm.Input;
using EBanking.Services;
using EBanking.Services.Modeli;
using EBanking.UI.Common.Validacija;
using EBanking.UI.Models;
using GalaSoft.MvvmLight.Ioc;
using System;

namespace EBanking.UI.ViewModels.Windows
{
    public class PlacanjeViewModel : BaseViewModel<PlacanjeModel>
    {
        private readonly ITransakcijaService _transakcijaService;
        private readonly IRacunService _racunService;

        [PreferredConstructor]
        public PlacanjeViewModel()
        {
        }

        public PlacanjeViewModel(ITransakcijaService transakcijaService, IRacunService racunService, TransakcijaInfo transakcijaInfo)
        {
            Validator = new PlacanjeViewValidator<PlacanjeModel>();
            _transakcijaService = transakcijaService;
            _racunService = racunService;
            Model.Title = "Novo Placanje";
            Model.BrojRacunaPlatioca = transakcijaInfo.BrojRacuna;
            Model.TrenutnoStanje = transakcijaInfo.TrenutniBalans;
            PlacanjeCommand = new RelayCommand(Plati);
            TransakcijaInfo = transakcijaInfo;
        }

        public RelayCommand PlacanjeCommand { get; set; }
        public TransakcijaInfo TransakcijaInfo { get; set; }

        public void Plati()
        {
            if (Validator.ValidateModel(Model))
            {
                _transakcijaService.CreateTransakcija(new TransakcijaModel
                {
                    BrojRacuna = Model.BrojRacunaPlatioca,
                    KolicinaNovca = Model.KolicinaNovca,
                    BrojRacunaSekundarnogAktera = Model.BrojRacunaPrimaoca,
                    NazivSekundarnogAktera = Model.NazivPrimaoca,
                    BalansNakonTransakcije = Model.TrenutnoStanje - Model.KolicinaNovca,
                    Datum = DateTime.UtcNow
                });

                _racunService.UpdateBalance(Model.TrenutnoStanje - Model.KolicinaNovca, Model.BrojRacunaPlatioca);

                if (_racunService.IsValidRacun(Model.BrojRacunaPrimaoca))
                {
                    DodajTransakcijuPrimaocu();
                }
                Close();
            }
        }

        private async void DodajTransakcijuPrimaocu()
        {
            var racun = await _racunService.GetRacunByBrojRacuna(Model.BrojRacunaPrimaoca);

            _transakcijaService.CreateTransakcija(new TransakcijaModel
            {
                BrojRacuna = Model.BrojRacunaPrimaoca,
                KolicinaNovca = Model.KolicinaNovca,
                BrojRacunaSekundarnogAktera = Model.BrojRacunaPlatioca,
                NazivSekundarnogAktera = TransakcijaInfo.ImeKorisnika,
                BalansNakonTransakcije = racun.Balans + Model.KolicinaNovca,
                Datum = DateTime.UtcNow
            });

            _racunService.UpdateBalance(racun.Balans + Model.KolicinaNovca, Model.BrojRacunaPrimaoca);
        }
    }
}
