namespace Scheduling.Interfaces
{
    public interface IAuthenticationRepository
    {
        bool ValidateCredentials(string username, string password);
    }
}
