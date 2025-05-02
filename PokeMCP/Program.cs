using PokeMCP;
using PokeMCP.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithTools<PokeFunctionsTool>()
    .WithTools<PokeApiTool>();

var app = builder.Build();

app.MapMcp();

app.MapGet("/home", () => "Pokemon MCP Server - Ready for use with SSE");

app.Run();