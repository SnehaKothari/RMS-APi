using recruitmentmanagementsystem.CommonModel;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.MailServices
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
