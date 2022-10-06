namespace TicketSelling.Core.Validators
{
    public interface IJsonSchemaValidator
    {
        bool IsValid(string content, string jsonSchemaName);
    }
}
