using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class CarrinhoCompasViewModel
    {

        public List<Produto> Produtos { get; set; }

        public decimal ValorTotal { get; set; }

        public string Mensagem { get; set; }

    }
}