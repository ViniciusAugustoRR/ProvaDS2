using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaC.Models
{
    public class Placar
    {

        public int PlacarId { get; set; }

        public virtual Jogador Jogador { get; set; }
        [Required(ErrorMessage = "Jogador é obrigatório.", AllowEmptyStrings = false)]
       
        public int IdJogador { get; set; }

        [Required(ErrorMessage = "Pontos é obrigatório.", AllowEmptyStrings = false)]
        [Range(0, 999999)]
        public int Pontos { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data é obrigatório.", AllowEmptyStrings = false)]
        public DateTime Data { get; set; }
    }
}
