using System.Text.Json.Serialization;

namespace OpenRoom.Admin.Models.Settings;

public class JwtSettings
{
    public const string SettingKey = "JwtSettings";//�নJSON�R�X����
    
    [JsonPropertyName("Issuer")]
    public string Issuer { get; set; }
    [JsonPropertyName("SignKey")]
    public string SignKey { get; set; }
}