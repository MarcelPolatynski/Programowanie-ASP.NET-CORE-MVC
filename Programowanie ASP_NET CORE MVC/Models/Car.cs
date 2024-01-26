using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Programowanie_ASP_NET_CORE_MVC.Models
{
    public class Car
    {
        public int Id { get; set; }

        [DisplayName("Marka")]
        public string? Brand { get; set; }

        [DisplayName("Model")]
        public string? Model { get; set; }

        [DisplayName("Rok produkcji")]
        public int? Year { get; set; }
    }
}
