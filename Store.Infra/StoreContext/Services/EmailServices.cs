using Store.Domain.StoreContext.Services;

namespace Store.Infra.StoreContext.Services
{
    public class EmailServices : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}