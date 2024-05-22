using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<EmpretismoModel> emprestimos = _db.Empretismos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(EmpretismoModel emprestimos)
        {
            if(ModelState.IsValid)
            {
                _db.Empretismos.Add(emprestimos);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
