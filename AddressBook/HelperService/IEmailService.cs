using System.Threading.Tasks;

namespace AddressBook.HelperService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
