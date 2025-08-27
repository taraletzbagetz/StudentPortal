using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentPortal.Empty.Web.Models;
using StudentPortal.Empty.Web.Services;

namespace StudentPortal.Empty.Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IEmailService emailService;

        public ContactModel(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        public string Title { get; set; } = "Contact Me";
        public string Message { get; set; } = "";

        [BindProperty]
        public ContactViewModel Contact { get; set; } = new ContactViewModel();

        public void OnGet()
        {
            Message = "";
        }

        public void OnPost(){
            

            if (ModelState.IsValid)
            {
                this.emailService.SendMail("gmbinos@gmail.com", Contact.Email, Contact.Subject, Contact.Body);
                Contact = new ContactViewModel();
                ModelState.Clear();
                Message = "Sent....";
            }
            else {
                Message = "Please fix the errors.";
            }
        }
    }
}
