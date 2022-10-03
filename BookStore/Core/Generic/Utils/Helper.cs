using System.Text.Json;

namespace BookStore.Core.Generic.Utils
{
    public static class Helper
    {
        public static string Json(object obj)
        {
            var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            return json;
        }
    }
}
