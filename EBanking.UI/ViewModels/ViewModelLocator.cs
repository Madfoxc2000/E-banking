using CommonServiceLocator;
using EBanking.DataAccess.Repozitorijumi;
using EBanking.DataAccess.Repozitorijumi.Implementacija;
using EBanking.Services;
using EBanking.Services.Implementacija;
using EBanking.UI.ViewModels.Windows;
using GalaSoft.MvvmLight.Ioc;

namespace EBanking.UI.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region Register Services
            SimpleIoc.Default.Register<IRacunService, RacunService>();
            SimpleIoc.Default.Register<IKorisnikService, KorisnikService>();
            SimpleIoc.Default.Register<ITransakcijaService, TransakcijaService>();
            SimpleIoc.Default.Register<IMenjacnicaService, MenjacnicaService>();
            SimpleIoc.Default.Register<IRepozitorijumTekucegRacuna, RepozitorijumTekucegRacuna>();
            SimpleIoc.Default.Register<IRepozitorijumKorisnika, RepozitorijumKorisnika>();
            SimpleIoc.Default.Register<IRepozitorijumTransakcija, RepozitorijumTransakcija>();
            SimpleIoc.Default.Register<IRepozitorijumMenjacnica, RepozitorijumMenjacnica>();
            #endregion

            #region Register Views
            SimpleIoc.Default.Register<TekuciRacunViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<RegistracijaViewModel>();
            SimpleIoc.Default.Register<PlacanjeViewModel>();
            SimpleIoc.Default.Register<MenjacnicaViewModel>();
            SimpleIoc.Default.Register<DetaljiTransakcijeViewModel>();
            #endregion
        }


        public DetaljiTransakcijeViewModel DetaljiTransakcijeView => ServiceLocator.Current.GetInstance<DetaljiTransakcijeViewModel>();
        public TekuciRacunViewModel RacunView => ServiceLocator.Current.GetInstance<TekuciRacunViewModel>();
        public LoginViewModel LoginView => ServiceLocator.Current.GetInstance<LoginViewModel>();
        public RegistracijaViewModel RegistracijaView => ServiceLocator.Current.GetInstance<RegistracijaViewModel>();
        public PlacanjeViewModel PlacanjeView => ServiceLocator.Current.GetInstance<PlacanjeViewModel>();
        public MenjacnicaViewModel MenjacnicaView => ServiceLocator.Current.GetInstance<MenjacnicaViewModel>();

        public static void Cleanup() { }
    }
}
