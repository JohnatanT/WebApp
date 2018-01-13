using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
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
        public ActionResult Create(PessoaViewModel model)
        {

            ModelState.Remove("Codigo");
           
            if (ModelState.IsValid) {

                //Validação pra verificar se não é robô
                if(model.Captcha == "123")
                {

                    //MODO HARD
                    //Pessoa p = new Pessoa();
                    //p.Codigo = model.Codigo;
                    //p.Nome = model.Nome;
                    //p.SobreNome = model.SobreNome;
                    //p.DataNascimento = model.DataNascimento;
                    //p.Cpf = model.Cpf;
                    //p.Email = model.Email;

                    //Transformar um objeto em outro
                    var p = AutoMapper.Mapper.Map<PessoaViewModel,Pessoa>(model);

                    PessoaService srv = new PessoaService();
                    srv.Salvar(p);
                    return View("List",srv.Listar());

                }
                return View(model);
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

            var p = srv.Obter(id);

            //Transformar um objeto em outro
            var pVM = AutoMapper.Mapper.Map<Pessoa, PessoaViewModel>(p);

            return View("Create", pVM);
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