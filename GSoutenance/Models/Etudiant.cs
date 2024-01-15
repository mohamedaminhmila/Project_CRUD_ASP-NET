using System.ComponentModel.DataAnnotations;

namespace GSoutenance.Models
{
    public class Etudiant
    {
        [Key]
        [Display(Name = "ID")]
        public int EtudiantId { get; set; }
        [Required(ErrorMessage = "Nom Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "Prénom Obligatoire")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenom { get; set; }

        [Display(Name = "Date De Naissance")]
        public DateTime DateN { get; set; }
        public virtual ICollection<Pfe_Etudiant>? Pfe_etudiants { get; set; }
    }
}
