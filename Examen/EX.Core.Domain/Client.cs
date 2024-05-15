namespace EX.Core.Domain
{
    public class Client
    {
        public int clientId { get; set; }
        //public string nom { get; set; }

        //public string adresse { get; set; }
        //public string prenom { get; set; }
        //public string tel { get; set; }
         public Cooredonnnes Cooredonnnes { get; set; }
        public IList<Presation> presationsC { get; set; }
       
    }
}
