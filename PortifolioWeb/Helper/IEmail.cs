namespace PortifolioWeb.Helper
{
    public interface IEmail
    {
        bool SendEmail(string email, string title, string message);
    }
}
