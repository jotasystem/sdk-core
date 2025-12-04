namespace JotaSystem.Sdk.Core.CrossCutting.Security
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string hashedPassword, string password);
    }
}