using OpenRoom.Admin.Models.Settings;
using Microsoft.Extensions.Options;

namespace OpenRoom.Admin.Configurations;

public static class ConfigureWebSettings
{
    public static IServiceCollection AddWebSettings(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingKey))
            .AddSingleton(setting => setting.GetRequiredService<IOptions<JwtSettings>>().Value);//AddSingleton�u�n�@��new�@���N�n�F�ҥH�M�ץu�n�`�JJwtSettings�N�i�H����

        return services;//��appsettings�̭���]�w�ɰ�������A�ܦ�service�i�ݨ쪺
    }
}