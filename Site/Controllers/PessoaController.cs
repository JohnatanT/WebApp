using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Impl;
using Site.Models;

namespace Site.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        //Página de Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Cadastrar Pessoa
        [HttpPost]
        public ActionResult Create(Pessoa model)
        {

            ModelState.Remove("Codigo");
           
            if (ModelState.IsValid) {

                PessoaService srv = new PessoaService();
                srv.Salvar(model);
                return View("List",srv.Listar());
            }
            else
                return View(model);
     
        }


        //Listar Pessoas
        public ActionResult List()
        {

            PessoaService srv = new PessoaService();
           
            return View(srv.Listar());

        }

        //Página de Editar especifica de um ID
        public ActionResult Edit(int id)
        {
            var srv = new PessoaService();

            return View("Create", srv.Obter(id));
        }

        //Recebendo e salvando os arquivos editados
        [HttpPost]
        public ActionResult Edit(Pessoa model)
        {

            if (ModelState.IsValid)
            {
                PessoaService srv = new PessoaService();
                srv.Salvar(model);
                return View("List", srv.Listar());
            }
            else
                return View("Create",model);

        }


        //Deletar a pessoa da lista
        public ActionResult Delete(int id)
        {

            PessoaService srv = new PessoaService();
            srv.Deletar(id);

            return View("List", srv.Listar());

        }



    }
}