using System.ComponentModel.DataAnnotations;

namespace GestionCEGEP.Models
{
    public class Cegep
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? CodePostal { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public int Effectif { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateCreation { get; set; }
    }
}
