using DbFirstApproach.Data;
using DbFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproach.Controllers
{
    public class EmpController : Controller
    {
        private readonly EcommerecedotnetcoreContext db;
        public EmpController(EcommerecedotnetcoreContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.emps.FromSqlRaw($"exec FetchEmp").ToList();
            return View(data);
        }

        public IActionResult addEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addEmp(Emp emp)
        {
            db.Database.ExecuteSqlRaw($"exec InsertEmp '{emp.Name}','{emp.Department}',{emp.Salary}");
            TempData["Addmsg"] = "Emp Added Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult EditEmp(int Id)
        {
            var data = db.emps.FromSqlRaw($"exec FindById {Id}").ToList().SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult EditEmp(Emp emp)
        {
            db.Database.ExecuteSqlRaw($"exec EditEmp {emp.Id},'{emp.Name}','{emp.Department}',{emp.Salary}");
            TempData["msg"] = "Emp Edited Successfully";
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult AddorUpdateEmp(Emp emp)
        //{
        //    db.Database.ExecuteSqlRaw($"exec AddorUpdate {emp.Id},'{emp.Name}','{emp.Department}',{emp.Salary}");
        //    return RedirectToAction("Index");
        //}
    }
}
