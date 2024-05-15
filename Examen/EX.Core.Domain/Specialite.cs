using System.ComponentModel.DataAnnotations;

namespace EX.Core.Domain
{
    public class Specialite
    {
        [Key]
        public int code {  get; set; }
        public string description { get; set; }
        public Intitule intule { get; set; }
        public  IList<Prestataire> prestataires { get; set; }

    }
}
