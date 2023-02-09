using Discord;
using Discord.WebSocket;
using MillenniumEye.service;

public class Program
{
    private DiscordSocketClient _client = null!;

    public static async Task Main(string[] args) => await new Program().MainAsync();

    public async Task MainAsync()
    {
        var config = new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.All
        };

        _client = new DiscordSocketClient(config);
        _client.MessageReceived += CommandHandlerAsync;
        _client.Log += Log;

        var token = await File.ReadAllTextAsync("token.txt");

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        _client.Ready += OnReady;

        await Task.Delay(-1);
    }

    private Task OnReady()
    {
        Console.WriteLine("Bot connected.");
        return Task.CompletedTask;
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    private async Task CommandHandlerAsync(SocketMessage message)
    {
        CardService cardService = new();

        if (!message.Content.StartsWith("!") || message.Author.IsBot)
        {
            return;
        }

        string command = message.Content.TrimStart('!');

        switch (command)
        {
            case "hello":
                await cardService.SendHelloMessageAsync(message);
                break;
            case "age":
                await cardService.SendAccountAgeMessageAsync(message);
                break;
            case "price":
                await cardService.SendCardPriceMessageAsync(message, command);
                break;
            case "info":
                await cardService.SendCardInformationMessageAsync(message, command);
                break;
            case "help":
                await cardService.SendHelpMessageAsync(message);
                break;
            default:
                await message.Channel.SendMessageAsync("Invalid command. Use !help to see a list of available commands.");
                break;
        }
    }
}
