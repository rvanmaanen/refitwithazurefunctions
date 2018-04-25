using Refit;

namespace RefitWithAzureFunctions
{
    public interface IEmailService
    {
        [Post("/url")]
        string Method();
    }
}
