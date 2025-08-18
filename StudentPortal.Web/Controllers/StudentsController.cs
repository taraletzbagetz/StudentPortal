using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entites;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public StudentsController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentVM vm)
        {
            var student = new Student
            {
                Name = vm.Name,
                Email = vm.Email,
                Phone = vm.Phone,
                Subscribed = vm.Subscribed
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> List() {
            var students =  await dbContext.Students.ToListAsync();

            return View(students);
        }
    }
}
