using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;

namespace TCC_2._0.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext bd;

        public CategoriasController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public ActionResult Index()
        {
            // select * from produto
            return View(bd.CATEGORIA.ToList());
        }
        // GET: Criar
        public ActionResult Criar()
        {
            return View();
        }
        public ActionResult Erro()
        {
            return View();
        }

        public ActionResult AvisoD()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(string descricao)
        {
            CATEGORIA novacategoria = new CATEGORIA();

            novacategoria.CATDESCRICAO = descricao;


            bd.CATEGORIA.Add(novacategoria);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            CATEGORIA catlocalizar = bd.CATEGORIA.ToList().Where(x => x.CATID == id).First();
            return View(catlocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao)
        {
            CATEGORIA catatualizar = bd.CATEGORIA.ToList().Where(x => x.CATID == id).First();
            catatualizar.CATDESCRICAO = descricao;


            bd.Entry(catatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            CATEGORIA catDeletar = bd.CATEGORIA.ToList().Where(x => x.CATID == id).First();
            return View(catDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            CATEGORIA catDeletar = bd.CATEGORIA.ToList().Where(x => x.CATID == id).First();
            bd.CATEGORIA.Remove(catDeletar);
            try
            {
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("AvisoD");
            }





            return RedirectToAction("Index");
        }

        public ActionResult Testes()
        {
            return View();
        }


    }
}
