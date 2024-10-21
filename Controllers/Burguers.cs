using System.ComponentModel.DataAnnotations;

namespace SAbadBurguerPromoCF.Controllers
{
    public class Burguers
    {
        public int BurguerID { get; set; }
       
        public string? Nombre { get; set; }
        public bool WithCheese { get; set; }

        [Range(0.99, 99.99)]
        public decimal price { get; set; }
    }
}
