using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace ProvaC.Models
{
    public class Jogador
    {
        public int JogadorId { get; set; }


        [Required(ErrorMessage = "O campo Nome é obrigatório.", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Idade é obrigatório.", AllowEmptyStrings = false)]
        [Range(0, 220)]
        public int Idade { get; set; }

        

        public string Nacionalidade { get; set; }

    }
}
