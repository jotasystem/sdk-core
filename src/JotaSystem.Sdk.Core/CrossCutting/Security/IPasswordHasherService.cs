namespace JotaSystem.Sdk.Core.CrossCutting.Security
{
    public interface IPasswordHasherService
    {
        string Hash(string password);
        bool Verify(string hashedPassword, string password);
    }
}