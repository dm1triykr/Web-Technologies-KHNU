using System.Threading.Tasks;

namespace Services.EmailSender
{
    public interface IEmailSender
    {
        Task SendMessage(string emailTo, string messageBody, string subject);
    }
}
