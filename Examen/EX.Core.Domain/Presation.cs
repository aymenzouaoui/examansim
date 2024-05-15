namespace EX.Core.Domain
{
    public class Presation
    {
        public DateTime heureDeut { get; set; }
        public int nbHeures { get; set; }
        public Prestataire prestataire { get; set; }
        public Client client { get; set; }
        public int prestataireFK { get; set; }
        public int clientFK { get; set; }
    }
}
