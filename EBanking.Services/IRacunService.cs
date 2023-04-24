using EBanking.Services.Modeli;

namespace EBanking.Services
{
    public interface IRacunService
    {
        List<RacunModel> GetRacunForKorsnik(int IdKorsnika);
        void UpdateBalance(double noviBalans, string brojRacuna);
        bool IsValidRacun(string brojRacuna);
        Task<RacunModel> GetRacunByBrojRacuna(string brojRacuna);
    }
}
