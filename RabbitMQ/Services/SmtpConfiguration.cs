using Microsoft.Extensions.Configuration;

namespace RabbitMQ.Services;

public class SmtpConfiguration : ISmtpConfiguration
{
    private readonly IConfiguration _config;
    public SmtpConfiguration(IConfiguration configuration) => _config = configuration;
    public string Host => _config.GetSection("SmtpConfig:Host").Value!;
    public int Port => int.Parse(_config.GetSection("SmtpConfig:Port").Value!);
    public string User => _config.GetSection("SmtpConfig:User").Value!;
    public string Password => _config.GetSection("SmtpConfig:Password").Value!;
    public bool UseSSL => bool.Parse(_config.GetSection("SmtpConfig:UseSSL").Value!);
}