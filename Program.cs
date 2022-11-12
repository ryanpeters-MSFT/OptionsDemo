using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var configValues = new Dictionary<string, string>()
{
    ["credentials:name"] = "ryan"
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
        services.Configure<Person>(builder.Configuration.GetSection("Person"));
    });

var app = builder.Build();

var configuration = app.Services.GetService<IConfiguration>();

Console.WriteLine($"Setting from memory: {configuration["credentials:name"]}");
Console.WriteLine($"Setting from settings.json: {configuration["Towns:1:City"]}");

var options = app.Services.GetService<IOptions<Person>>();

Console.WriteLine($"Settings from options: {options.Value.Name}");