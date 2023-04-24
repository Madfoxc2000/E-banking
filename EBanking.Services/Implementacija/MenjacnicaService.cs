using EBanking.DataAccess.Repozitorijumi;

namespace EBanking.Services.Implementacija
{
    public class MenjacnicaService : IMenjacnicaService
    {
        private readonly IRepozitorijumMenjacnica _repozitorijumMenjacnica;
        public MenjacnicaService(IRepozitorijumMenjacnica repozitorijumMenjacnica)
        {
            _repozitorijumMenjacnica = repozitorijumMenjacnica;

        }
    }
}
