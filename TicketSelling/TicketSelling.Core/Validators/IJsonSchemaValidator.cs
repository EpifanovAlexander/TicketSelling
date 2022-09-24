namespace TicketSelling.Core.Validators
{
    public interface IJsonSchemaValidator
    {
        Task<bool> IsValid(string content, string jsonSchemaName);
    }
}
