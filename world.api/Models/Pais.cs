using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace world.api.Models
{
    public class Pais
    {
        [Key]
        public int PaisId { get; set; }
        public string NomePais { get; set; }
        public ICollection<Estado> Estados { get; set; }
    }
}
