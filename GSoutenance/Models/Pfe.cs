using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSoutenance.Models
{
    public class Pfe
    {
        [Key]
        public int PFEID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string titre { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string desc { get; set; }

        [Required]
        [Display(Name = "Date De Debuit")]
        public DateTime Dated { get; set; }

        [Required]
        [Display(Name = "Date De Fin")]
        public DateTime DateF { get; set; }

        [ForeignKey("Encadrant")]
        public int EncadrantID { get; set; }
        public virtual Ensignant? Encadrant { get; set; }

        [ForeignKey("Societe")]
        public int SocieteID { get; set; }
        public virtual Societe? Societe { get; set; }
        public virtual ICollection<Pfe_Etudiant>? Pfe_Etudiants { get; set; }
    }
}
