using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokvijum2.Models
{
    public class Proizvodjac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProizvodjacID { get; set; }

        [DisplayName("Naziv proizvodjaca")]
        [Required(ErrorMessage = "Naziv je obavezan")]
        public string NazivProizvodjaca { get; set; }
        public IEnumerable<Automobil> Automobili { get; set; } = new List<Automobil>();
    }
}
