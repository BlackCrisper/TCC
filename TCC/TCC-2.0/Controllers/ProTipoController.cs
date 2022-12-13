using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;


namespace TCC_2._0.Controllers
{
    [Authorize]
    public class ProTipoController : Controller
    {

        private readonly ApplicationDbContext bd;

        public ProTipoController(ApplicationDbContext contexto)
        {
            bd = contexto;
        }

        public ActionResult Index()
        {
            ViewBag.tip = bd.TIPO.ToList();
            ViewBag.desp = bd.PRODUTO.ToList();
            return View(bd.PROTIPO.ToList());
        }

        public ActionResult Alerta()
        {
            ViewBag.tip = bd.TIPO.ToList();
            ViewBag.desp = bd.PRODUTO.ToList();
            return View(bd.PROTIPO.ToList());
        }

        public ActionResult AvisoS()
        {
            return View();
        }

        public ActionResult AvisoE()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Criar()
        {
            ViewBag.listaTipo = bd.TIPO.ToList();
            ViewBag.listaProduto = bd.PRODUTO.ToList();
            return View();
        }
        


        [HttpPost]
        public async Task<ActionResult> CriarAsync(int produto, int tipo, string maximo, string minimo, int estoque, IFormFile imagem)
        {
            PROTIPO novoproduto = new PROTIPO();

            novoproduto.PROID = produto;
            novoproduto.TIPID = tipo;
            novoproduto.PTMAXIMO = Convert.ToInt32(maximo);
            novoproduto.PTMINIMO = Convert.ToInt32(minimo);
            novoproduto.PTESTOQUE = estoque;
            
            if (imagem != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                     await imagem.CopyToAsync(memoryStream);
                     novoproduto.PTIMAGEM = memoryStream.ToArray();
                }
            }

            bd.PROTIPO.Add(novoproduto);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }
        


        [HttpGet]
        public ActionResult Editar(int? id)
        {
            ViewBag.listaTipo = bd.TIPO.ToList();
            ViewBag.listaProduto = bd.PRODUTO.ToList();
            PROTIPO prolocalizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            return View(prolocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, int produto, int tipo, string maximo, string minimo, int estoque)
        {
            PROTIPO proatualizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            proatualizar.PROID = produto;
            proatualizar.TIPID = tipo;
            proatualizar.PTMAXIMO = Convert.ToInt32(maximo);
            proatualizar.PTMINIMO = Convert.ToInt32(minimo);
            proatualizar.PTESTOQUE = estoque;


            bd.Entry(proatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            ViewBag.tipos = bd.TIPO.ToList();
            ViewBag.dp = bd.PRODUTO.ToList();
            PROTIPO proDeletar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            return View(proDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            PROTIPO proDeletar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            bd.PROTIPO.Remove(proDeletar);
            try
            {
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("/Home/Erro");
            }





            return RedirectToAction("Index");
        }


        


        public ActionResult EntradaEstoque()
        {
            ViewBag.attip = bd.TIPO.ToList();
            ViewBag.atpro = bd.PRODUTO.ToList();
            return View(bd.PROTIPO.ToList());
        }

        public ActionResult SaidaEstoque()
        {
            ViewBag.attip = bd.TIPO.ToList();
            ViewBag.atpro = bd.PRODUTO.ToList();
            return View(bd.PROTIPO.ToList());
        }

        [HttpGet]
        public ActionResult AtualizarEstoque(int? id)
        {
            ViewBag.listaTip = bd.TIPO.ToList();
            ViewBag.listaProdut = bd.PRODUTO.ToList();
            PROTIPO ptelocalizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            return View(ptelocalizar);
        }

        [HttpPost]
        public ActionResult AtualizarEstoque(int? id, int qtd)
        {
            PROTIPO pteatualizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            var estoque = pteatualizar.PTESTOQUE;
            pteatualizar.PTESTOQUE = estoque + qtd;


            bd.Entry(pteatualizar).State = EntityState.Modified;

            bd.SaveChanges();
             return RedirectToAction("Alerta");

        }

        public ActionResult RetirarEstoque(int? id)
        {
            ViewBag.listaTip = bd.TIPO.ToList();
            ViewBag.listaProdut = bd.PRODUTO.ToList();
            PROTIPO ptelocalizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            return View(ptelocalizar);
        }

        [HttpPost]
        public ActionResult RetirarEstoque(int? id, int qtd)
        {
            PROTIPO pteatualizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            var estoque = pteatualizar.PTESTOQUE;
            pteatualizar.PTESTOQUE = estoque - qtd;


            

            try
            {
                bd.Entry(pteatualizar).State = EntityState.Modified;
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("AvisoS");
            }

            return RedirectToAction("Alerta");

        }

    }
}
