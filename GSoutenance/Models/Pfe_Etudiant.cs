using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSoutenance.Models
{
    public class Pfe_Etudiant
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Pfe")]
        public int PFEID { get; set; }
         public virtual Pfe? Pfe { get; set; }

        [ForeignKey("Etudiant")]
        public int EtudiantId { get; set; }
        public virtual Etudiant? Etudiant { get; set; }
     
    }
}
