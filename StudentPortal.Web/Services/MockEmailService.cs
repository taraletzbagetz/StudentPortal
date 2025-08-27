namespace StudentPortal.Web.Services
{
    public class MockEmailService : IEmailService
    {
        public MockEmailService()
        {
            
        }
        public void SendMail(string to, string from, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
