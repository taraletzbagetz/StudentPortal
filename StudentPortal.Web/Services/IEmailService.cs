﻿namespace StudentPortal.Web.Services
{
    public interface IEmailService
    {
        void SendMail(string to, string from, string subject, string body);
    }
}
