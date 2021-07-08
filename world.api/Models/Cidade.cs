using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace world.api.Models
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }

        public string NomeCidade { get; set; }

        public Estado Estado { get; set; }

        public int EstadoId { get; set; }

    }
}
