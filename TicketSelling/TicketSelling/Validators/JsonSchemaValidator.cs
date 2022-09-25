using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using TicketSelling.Core.Validators;

namespace TicketSelling.Validators
{
    public class JsonSchemaValidator: IJsonSchemaValidator
    {
        private readonly string json_schemas_folder = Path.Combine(Environment.CurrentDirectory, "JsonSchemes");
        public async Task<bool> IsValidAsync(string jsonContent, string jsonSchemaName) 
        {
            string jsonSchemaPath = Path.Combine(json_schemas_folder, $"{jsonSchemaName}.json");
            if (string.IsNullOrWhiteSpace(jsonContent) || string.IsNullOrWhiteSpace(jsonSchemaName) 
                || !File.Exists(jsonSchemaPath))
            {
                return false;
            }

            string jsonSchema = await File.ReadAllTextAsync(jsonSchemaPath);
            JSchema schema = JSchema.Parse(jsonSchema); 
            JObject content = JObject.Parse(jsonContent);

            var result = content.IsValid(schema, out IList<string> messages);
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
            return result;
        }
    }
}
