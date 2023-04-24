using EBanking.Services.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EBanking.UI.Models
{
    public class DetaljiTransakcijeModel : BaseModel    
    {
        public TransakcijaModel Transakcija { get; set; }
        public string BrojRacuna { get; set; }
    }
}
