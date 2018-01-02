using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Pessoa
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "CPF é Obrigatório")]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nome { get; set; }

        [MaxLength(20)]
        public string SobreNome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

    }
}