using PostOffice.API.Utilities.Mail.Models;

namespace PostOffice.API.Utilities.Mail.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
