
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;

namespace Infrastructure.EmailServices
{
    public class BravoEmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public BravoEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async System.Threading.Tasks.Task SendEmailAsync(string toEmail, string subject, string body)
        {
            Configuration.Default.ApiKey["api-key"] = _configuration["BravoSettings:ApiKey"];

            var apiInstance = new TransactionalEmailsApi();
            var SenderName = _configuration["ApplicationEmails:ApplicationEmailUsername"];
            var SenderEmail = _configuration["ApplicationEmails:AuthenticatorEmailSender"];
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);

            string ToEmail = toEmail;
            string ToName = toEmail;
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);


            string HtmlContent = body;
            string Subject = subject;

            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, HtmlContent, null, Subject);
                CreateSmtpEmail result = await apiInstance.SendTransacEmailAsync(sendSmtpEmail);
                Console.WriteLine("Response: " + result.ToJson());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
