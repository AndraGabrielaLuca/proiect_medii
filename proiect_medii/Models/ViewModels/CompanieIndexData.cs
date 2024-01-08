using System.Security.Policy;

namespace proiect_medii.Models.ViewModels
{
    public class CompanieIndexData
    {
        public IEnumerable<Companie> Companii { get; set; }
        public IEnumerable<Zbor> Zbor { get; set; }
    }
}
