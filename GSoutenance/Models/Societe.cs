using System.ComponentModel.DataAnnotations;

namespace GSoutenance.Models
{
    public class Societe
    {
        [Key]
        [Display(Name = "ID")]
        public int SocieteID { get; set; }

        [Display(Name = "Nom Societe")]
        [Required, StringLength(30, MinimumLength = 3)]
        public string? LibSociete { get; set; }

        [Required(ErrorMessage = "Adresse Obligatoire")]
        public string? Adresse { get; set; }

        [Required(ErrorMessage = "Tel Obligatoire")]
        [Range(99999999,99999999, ErrorMessage = "Le numéro de téléphone doit comporter obligatoire 8 chiffres.")]
        public int Tel { get; set; }

        public virtual ICollection<Pfe>? Pfes { get; set; }
    }
}
