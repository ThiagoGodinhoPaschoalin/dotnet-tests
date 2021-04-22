namespace LibApiSampleAbstraction.Services.Dtos
{
    public class SendWelcomeEmailRequest
    {
        public SendWelcomeEmailRequest(string htmlBody, string subject, string emailSender, string emailDestination)
        {
            HtmlBody = htmlBody;
            Subject = subject;
            EmailSender = emailSender;
            EmailDestination = emailDestination;
        }

        public string HtmlBody { get; private set; }
        public string Subject { get; private set; }
        public string EmailSender { get; private set; }
        public string EmailDestination { get; private set; }
    }
}