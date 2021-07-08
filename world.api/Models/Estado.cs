using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace world.api.Models
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string NomeEstado { get; set; }

        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public ICollection<Cidade> Cidades { get; set; }

    }
}
