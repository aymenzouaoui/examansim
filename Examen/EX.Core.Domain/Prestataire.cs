using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace EX.Core.Domain
{
    public class Prestataire
    {

        public int appreciation { get; set; }
        public int prestataireId { get; set; }
        [MaxLength(20)]
        public string prestataireNom { get; set; }
        public string prestatairePhoto { get; set; }
        public string prestataireTel { get; set; }

        [Range(0, 5, ErrorMessage = "entre 0-5.")]

        public double tarifHoriare { get; set; }
        [ForeignKey(nameof(specialiteFK))]
        public Specialite specialite { get; set; }
        public int specialiteFK { get; set; }
        public IList<Presation> presations { get; set; }
       
    }
}
