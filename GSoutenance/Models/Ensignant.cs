using System.ComponentModel.DataAnnotations;

namespace GSoutenance.Models
{
    public class Ensignant
    {
        [Key]
        [Display(Name = "ID")]
        public int EncadreurID { get; set; }

        [Required(ErrorMessage = "Nom Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "Prénom Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenom { get; set; }

        public virtual ICollection<Pfe>? Pfes { get; set; }
    }
}
