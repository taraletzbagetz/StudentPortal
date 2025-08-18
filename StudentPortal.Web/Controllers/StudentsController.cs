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

            return RedirectToAction("List", "Students");
        }

        [HttpGet]
        public async Task<IActionResult> List() {
            var students =  await dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student vm) {
            var student = await dbContext.Students.FindAsync(vm.Id);

            if (student is not null) {
                student.Name = vm.Name;
                student.Email = vm.Email;
                student.Phone = vm.Phone;
                student.Subscribed = vm.Subscribed;

                await dbContext.SaveChangesAsync(); 
            }

            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student vm) {
            var student = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == vm.Id);

            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }
    }
}
