using EBanking.DataAccess.Modeli;

namespace EBanking.DataAccess.Repozitorijumi
{
    public interface IRepozitorijumTekucegRacuna
    {
        void CreateRacun(TekuciRacun model);
        List<TekuciRacun> GetRacuniByKorsnikId(int idKorisnika);
        Task<TekuciRacun> GetRacunByBrojRacuna(string brojRacuna);
        void UpdateBalance(double balans, string brojRacuna);
        bool IsValidRacun(string brojRacuna);
    }
}
