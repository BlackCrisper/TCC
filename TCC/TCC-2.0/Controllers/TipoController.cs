using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;


namespace TCC_2._0.Controllers
{
    [Authorize]
    public class TipoController : Controller
    {

        private readonly ApplicationDbContext bd;

        public TipoController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public ActionResult Index()
        {
            // select * from produto
            return View(bd.TIPO.ToList());
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
            TIPO novotipo = new TIPO();

            novotipo.TIPNOME = descricao;


            bd.TIPO.Add(novotipo);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            TIPO tipolocalizar = bd.TIPO.ToList().Where(x => x.TIPID == id).First();
            return View(tipolocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao)
        {
            TIPO tipoatualizar = bd.TIPO.ToList().Where(x => x.TIPID == id).First();
            tipoatualizar.TIPNOME = descricao;


            bd.Entry(tipoatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            TIPO tipoDeletar = bd.TIPO.ToList().Where(x => x.TIPID == id).First();
            return View(tipoDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            TIPO tipoDeletar = bd.TIPO.ToList().Where(x => x.TIPID == id).First();
            bd.TIPO.Remove(tipoDeletar);
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
    }
}
