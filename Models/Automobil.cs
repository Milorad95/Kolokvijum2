using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokvijum2.Models
{
    public class Automobil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutomobilID { get; set; }

        [DisplayName("Naziv automobila")]
        [Required(ErrorMessage = "Naziv je obavezan")]
        public string NazivAutomobila { get; set; }

        public Proizvodjac? Proizvodjac { get; set; } = new Proizvodjac();
    }
}
