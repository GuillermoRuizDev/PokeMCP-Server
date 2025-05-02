# PokeMCP Server - Pokémon Server with Model Context Protocol (MCP)

## Description
PokeMCP Server is a server that provides Pokémon-related functionalities using the Model Context Protocol (MCP). The project allows querying information about Pokémon, calculating battle outcomes, and estimating shiny Pokémon encounter probabilities.

## Features
- Retrieve Pokémon information through the PokeAPI
- Calculate battle results between two Pokémon
- Estimate probabilities for finding shiny Pokémon
- Built on Clean Architecture principles
- Implements the MCP protocol for client-server communication

## Requirements
- .NET 9
- Internet connection (to access the PokeAPI)

## Installation

1. Clone the repository:
```git clone https://github.com/GuillermoRuizDev/PokeMCP-Server.git cd PokeMCP```

2. Restore dependencies:
```dotnet restore```

3. Build the project:
```dotnet build```

## Running the Application

### Development Mode

To run the application in development mode:

```dotnet run --project PokeMCP```


By default, the application will run at:
- HTTP: http://localhost:3002
- HTTPS: https://localhost:7133

You can verify it's working by accessing http://localhost:3002/home in your browser, where you should see the message: "Pokemon MCP Server - Ready for use with SSE".

## Integration with MCP Clients

To use this server from an MCP client (such as Semantic Kernel or compatible applications):

1. Connect to the MCP server using an MCP client by adding the following json to the `mcp.json` file:
```{
    "servers": {        
        "pokeapi-mcp-server": {
            "type": "sse",
            "url": "http://localhost:3002/sse"
        }
    }
}```

2. Use the exposed tools to interact with the Pokémon functionalities

## Project Structure (Clean Architecture)
```
PokeMCP/
├── Core/                      # Domain Layer
│   ├── Entities/            # Domain entities
│   ├── Enums/             # Enumerations
│   └── Interfaces/        # Repository and service interfaces
├── Application/           # Application Layer
│   ├── DTOs/                # Data transfer objects
│   └── UseCases/         # Use cases and business logic implementation
├── Infrastructure/        # Infrastructure Layer
│   ├── Clients/             # External service clients (PokeAPI)
│   └── Repositories/    # Repository implementations
└── Tools/                     # MCP tools for exposing functionality
```


## API Usage

The server exposes the following functionalities through the MCP protocol:

### PokeApiTool
- `GetPokemonInfo(pokemonName)`: Retrieves detailed information about a Pokémon by its name or ID.

### PokeFunctionsTool
- `GetBattleResult(attacker, defender)`: Calculates the result of a battle between two Pokémon.
- `ProbabilityFindingShiny(encounters, hasShinyCharm)`: Calculates the probability of finding a shiny Pokémon.


## License
This project is licensed under the [MIT License](https://github.com/GuillermoRuizDev/PokeMCP-Server/blob/main/LICENSE).

## Contact
If you have questions or suggestions, feel free to open an issue or contact me at [LinkedIn](https://www.linkedin.com/in/guillermo-ruiz-alv/).

## Acknowledgments
- [PokeAPI](https://pokeapi.co/) for providing Pokémon data
- [Model Context Protocol](https://github.com/microsoft/modelcontextprotocol) for the communication protocol