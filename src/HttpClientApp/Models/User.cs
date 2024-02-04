using System.Text.Json.Serialization;

namespace HttpClientApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        public string? Avatar { get; set; }
    }
}
