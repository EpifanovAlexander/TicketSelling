using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using TicketSelling.Core.Validators;

namespace TicketSelling.Validators
{
    public class JsonSchemaValidator : IJsonSchemaValidator
    {
        private readonly string json_schemas_folder = Path.Combine(Environment.CurrentDirectory, "JsonSchemes");

        private IMemoryCache _memoryCache;

        public JsonSchemaValidator(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private bool TryGetJsonSchema(string jsonSchemaName, out string jsonSchemaContent)
        {
            var result = _memoryCache.TryGetValue(jsonSchemaName, out jsonSchemaContent);
            if (!result)
            {
                string jsonSchemaPath = Path.Combine(json_schemas_folder, $"{jsonSchemaName}.json");
                if (File.Exists(jsonSchemaPath))
                {
                    jsonSchemaContent = File.ReadAllText(jsonSchemaPath);
                    _memoryCache.Set(jsonSchemaName, jsonSchemaContent);
                    result = true;
                }
            }
            return result;
        }

        public bool IsValid(string jsonContent, string jsonSchemaName)
        {
            var isJsonSchemaExists = TryGetJsonSchema(jsonSchemaName, out string jsonSchemaContent);
            if (string.IsNullOrWhiteSpace(jsonContent) || string.IsNullOrWhiteSpace(jsonSchemaName)
                || !isJsonSchemaExists)
            {
                return false;
            }

            JSchema schema = JSchema.Parse(jsonSchemaContent);
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