using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class CarrinhoComprasController : Controller
    {
        // GET: CarrinhoCompras
        public ActionResult Index()
        {

            var produtos = new List<Produto>();
            for (int i = 1; i < 6; i++)
            {
                produtos.Add(new Produto()
                {
                    ID = i,
                    Nome = "Produto " + i,
                    Valor = i * 2.5M
                });
            }

            var model = new CarrinhoCompasViewModel()
            {
                Mensagem = "Parabéns pela compra!",
                Produtos = produtos,
                ValorTotal = produtos.Sum(p => p.Valor)
            };

            return View(model);
        }












    }
}