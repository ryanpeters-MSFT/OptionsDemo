using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var configValues = new Dictionary<string, string>()
{
    ["credentials:name"] = "ryan",

    // when uncommented, will provide data for IOptions<Person> instance
    // ["Person:Name"] = "Jane",
    // ["Person:Age"] = "25",
    // ["Person:Hometown"] = "New York"
};

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        // load in-memory settings
        config.AddInMemoryCollection(configValues);

        // load settings from settings.json
        config.AddJsonFile("settings.json");

    }).ConfigureServices((builder, services) =>
    {
        // configure IOptions<Person>
        services.Configure<PaymentProcessing>(builder.Configuration.GetSection("PaymentProcessing"));
    });

var app = builder.Build();

var configuration = app.Services.GetService<IConfiguration>();

Console.WriteLine($"Setting from memory: {configuration["credentials:name"]}");
Console.WriteLine($"Setting from settings.json: {configuration["PaymentProcessing:SetConfig:0:Name"]}");

var paymentProcessingSettings = app.Services.GetService<IOptions<PaymentProcessing>>();

Console.WriteLine($"Setting from IOptions<PaymentProcessing>: {paymentProcessingSettings.Value.SetConfig[1].Name}");