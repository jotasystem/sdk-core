namespace JotaSystem.Sdk.Core.CrossCutting.Exceptions
{
    public class DomainException(string message) 
        : CustomException("DomainError", message);
}