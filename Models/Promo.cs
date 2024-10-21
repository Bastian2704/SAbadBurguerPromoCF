using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SAbadBurguerPromoCF.Models
{
    public class Promo
    {
        public int PromoID { get; set; }
        public string? Descripcion { get; set; }
        public DateOnly? FechaPromo { get; set; }

        public int BurguerID { get; set; } 
        public Burguer? Burguer { get; set; }
    }
}
