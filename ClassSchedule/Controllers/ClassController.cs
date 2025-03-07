using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;

namespace ClassSchedule.Controllers
{
    public class ClassController : Controller
    {
        private readonly ClassScheduleUnitOfWork unitOfWork;
        public ClassController(ClassScheduleContext ctx)
        {
            unitOfWork = new ClassScheduleUnitOfWork(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var c = this.GetClass(id);
            return View("Add", c);
        }

        [HttpPost]
        public IActionResult Add(Class c)
        {
            if (ModelState.IsValid)
            {
                if (c.ClassId == 0)
                    unitOfWork.Classes.Insert(c);
                else
                    unitOfWork.Classes.Update(c);
                unitOfWork.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string operation = (c.ClassId == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetClass(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Class c)
        {
            unitOfWork.Classes.Delete(c);
            unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }
        private Class GetClass(int id)
        {
            var classOptions = new QueryOptions<Class>
            {
                Includes = "Teacher, Day",
                Where = c => c.ClassId == id
            };

            return unitOfWork.Classes.Get(classOptions);
        }

        private void LoadViewBag(string operation)
        {
            ViewBag.Days = unitOfWork.Days.List(new QueryOptions<Day>
            {
                OrderBy = d => d.DayId
            });
            ViewBag.Teachers = unitOfWork.Teachers.List(new QueryOptions<Teacher>
            {
                OrderBy = t => t.LastName
            });
            ViewBag.Operation = operation;
        }
    }
}