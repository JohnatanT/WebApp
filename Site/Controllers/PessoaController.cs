using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa model)
        {

            ModelState.Remove("Codigo");

            if (ModelState.IsValid) { 

            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(model);

            if(Session["Lista Pessoas"] != null){
                lista.AddRange((List<Pessoa>)Session["Lista Pessoas"]);
            }

            Session["Lista Pessoas"] = lista;
            }
            else
                return View(model);


                return View("List");
 
        }



        public ActionResult List()
        {
            if(Session["Lista Pessoas"] != null)
            {
                var model = (List<Pessoa>)Session["Lista Pessoas"];



                return View(model);
            }

            return View(new List<Pessoa>());


        }

        public ActionResult Edit(int id)
        {
            //Recuperar o objeto com o ID
            //Enviar o objeto encontrado para a View de Edição

            if(((List<Pessoa>)Session["ListaPessoas"]).Where(p => p.Codigo == id).Any())
            {
                var model = ((List<Pessoa>)Session["ListaPessoas"])
                .Where(p => p.Codigo == id).FirstOrDefault();

                return View("Create", model);
            }

            return View("Create", new Pessoa());
        }

        [HttpPost]
        public ActionResult Edit(Pessoa model)
        {
            //Recuperar o objeto com o ID
            //Alterar como o objeto do parametro
            //Aplicar/Salvar objeto alterado na fonte de dados

            if (Session["ListaPessoas"] != null)
            {

                if (((List<Pessoa>)Session["ListaPessoas"]).Where(p => p.Codigo == model.Codigo).Any())
                {
                    var modelBase = ((List<Pessoa>)Session["ListaPessoas"])
                    .Where(p => p.Codigo == model.Codigo).FirstOrDefault();

                    //Atualizar seu registro com o model enviado por parametro...
                    ((List<Pessoa>)Session["ListaPessoas"])[model.Codigo - 1] = model;

                }

                var lista = (List<Pessoa>)Session["ListaPessoas"];
                return View("List", lista);


            }

            return View("Create", new Pessoa());
        }



        public ActionResult Delete(int id)
        {

            if(Session["ListaPessoas"] != null)
            {

                if (((List<Pessoa>)Session["ListaPessoas"]).Where(p => p.Codigo == id).Any())
                {
                    var modelBase = ((List<Pessoa>)Session["ListaPessoas"])
                    .Where(p => p.Codigo == id).FirstOrDefault();

                    //Atualizar seu registro com o model enviado por parametro...

                    var lista = ((List<Pessoa>)Session["ListaPessoas"]);
                    lista.Remove(modelBase);

                    Session["ListaPessoas"] = lista;
                    return View("List", lista);

                }

            }


            return View("List", new List<Pessoa>());

        }



    }
}