# OptionsDemo

This short demo outlines:

- Basic project structure for `dotnet new console`
- Adding configuration providers (in-memory, JSON, and INI files)
- Binding of settings to a typed `IOptions` instance from multiple configuration provider sources
- Retrieval of services and options

## Configuration

In .NET Framework and .NET Core, configuration is handled differently due to the architectural and design differences between the two frameworks:

### .NET Framework Configuration:
  
  - In .NET Framework, configuration settings are typically stored in XML-based configuration files, such as `web.config` for web applications or `app.config` for non-web applications.
    
  - Configuration settings include application settings, connection strings, custom settings, and configuration sections for various components like ASP.NET, WCF, and more.
    
  - Configuration settings can be accessed using the `ConfigurationManager` class and related APIs (`Configuration`, `ConfigurationSection`, `ConnectionStringSettings`, etc.).
    
  - Configuration files can be modified manually or through tools like Visual Studio's project settings editor.
    
### .NET Core Configuration:
  
  - In .NET Core, configuration is more flexible and can be stored in various formats, including JSON, XML, INI, environment variables, command-line arguments, and Azure Key Vault.
  - The most common format for configuration in .NET Core is JSON, using files like `appsettings.json` or environment-specific files like `appsettings.Production.json`.
  - Configuration settings are accessed using the `IConfiguration` interface, which is part of the Microsoft.Extensions.Configuration namespace.
  - Configuration settings are typically loaded and managed through the `ConfigurationBuilder` class, which reads configuration sources and builds the configuration object.
  - .NET Core provides a hierarchy for configuration sources, allowing settings to be overridden or merged from multiple sources based on precedence rules.

### Key Differences:

- **Format:** .NET Framework primarily uses XML-based configuration files, while .NET Core favors JSON-based configuration files, although it supports multiple formats.
- **APIs:** .NET Framework uses `ConfigurationManager` and related APIs for configuration access, while .NET Core uses the `IConfiguration` interface and the `ConfigurationBuilder` class.
- **Flexibility:** .NET Core offers more flexibility in configuration sources and formats, making it easier to manage settings in different environments and scenarios.
- **Environment-based Configuration:** .NET Core has built-in support for environment-specific configuration, allowing developers to define settings for development, staging, production, etc., and switch between them easily.

Overall, .NET Core's approach to configuration is more modern, modular, and adaptable to different deployment environments, compared to the more rigid XML-based configuration system of .NET Framework.

Despite the differences, there is still optional support for legacy configuration management via the **System.Configuration.ConfigurationManager** nuget package, which allows for configuration using the `web.config` or `app.config` files.