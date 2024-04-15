namespace OfflineMode.API.Services.Interface
{
    public interface IEmailSender<TUser>
    {
        Task SendEmailAsync(TUser user, string subject, string htmlMessage);
    }
}
