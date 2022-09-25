namespace TicketSelling.Core.Validators
{
    public interface IJsonSchemaValidator
    {
        Task<bool> IsValidAsync(string content, string jsonSchemaName);
    }
}
