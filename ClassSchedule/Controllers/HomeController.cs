using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;

namespace ClassSchedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClassScheduleUnitOfWork unitOfWork;

        public HomeController(ClassScheduleContext ctx)
        {
            unitOfWork = new ClassScheduleUnitOfWork(ctx);
        }

        public ViewResult Index(int id)
        {
            var dayOptions = new QueryOptions<Day>
            {
                OrderBy = d => d.DayId
            };

            var classOptions = new QueryOptions<Class>
            {
                Includes = "Teacher, Day"
            };

            if (id == 0)
            {
                classOptions.OrderBy = c => c.DayId;
                classOptions.ThenOrderBy = c => c.MilitaryTime;
            }
            else
            {
                classOptions.Where = c => c.DayId == id;
                classOptions.OrderBy = c => c.MilitaryTime;
            }

            ViewBag.Days = unitOfWork.Days.List(dayOptions);
            return View(unitOfWork.Classes.List(classOptions));
        }
    }
}
