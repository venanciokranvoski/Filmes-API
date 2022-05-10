using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Filmes_API.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = " O campo titulo nao pode ser vazio! " )] // campo obrigatorio passar
        
        public string Titulo  {get; set;}

        [Required(ErrorMessage = " O campo Diretor nao pode ser vazio! ")]
        public string Diretor {get; set;}
        
        // Limitando a quantidade de caracteres no campo. 
        [StringLength(30, ErrorMessage = "O campo genero só pode até 30 caracteres :) ")]
        public string Genero  {get; set;}
        
        [Range(1, 600, ErrorMessage = "A duração tem que ser de 1 a 600 ")] // range entre os valores
        public int Duracao {get; set;}
    }
}
