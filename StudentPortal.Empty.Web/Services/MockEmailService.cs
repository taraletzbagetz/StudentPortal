namespace StudentPortal.Empty.Web.Services
{
    public class MockEmailService : IEmailService
    {
        private readonly ILogger<MockEmailService> logger;

        public MockEmailService(ILogger<MockEmailService> logger)
        {
            this.logger = logger;
        }

        public void SendMail(string to, string from, string subject, string body)
        {
            this.logger.LogInformation($"Sending email to {to} with a subject of {subject}.");
        }
    }
}
