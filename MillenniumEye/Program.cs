using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
public class Program
{
    private DiscordSocketClient? _client;
    public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
    public async Task MainAsync()
    {
        var config = new DiscordSocketConfig()
        {
            GatewayIntents = GatewayIntents.All
        };

        _client = new DiscordSocketClient(config);
        _client.MessageReceived += CommandHandler;
        _client.Log += Log;

        var token = File.ReadAllText("token.txt");

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        _client.Ready += () =>
        {
            Console.WriteLine("Bot is connected!");
            return Task.CompletedTask;
        };

        await Task.Delay(-1);
    }

    public async Task<Card> GetCardData(string cardName)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var url = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?name={cardName}";
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Card card = JsonConvert.DeserializeObject<Card>(json);
            return card;
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    Task Log(LogMessage msg)
    {

        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    async Task CommandHandler(SocketMessage message)
    {
        string command = "";
        if (!message.Content.StartsWith("!"))
            return;

        if (message.Author.IsBot)
            return;

        command = message.Content.ToString().Replace("!", "");

        if (command.Equals("hello"))
        {
            await message.Channel.SendMessageAsync($@"Hello {message.Author.Mention}");
        }
        else if (command.Equals("age"))
        {
            await message.Channel.SendMessageAsync($@"Your account was created at {message.Author.Mention + message.Author.CreatedAt.DateTime.Date}");
        }
        else if (command.StartsWith("price"))
        {
            string cardName = command.Replace("price ", "");
            if (cardName.Length > 0)
            {
                Card card = await GetCardData(cardName);
                await message.Channel.SendMessageAsync($@"{message.Author.Mention} the price for " + cardName + " is : " + card.Data[0].CardPrices[0].CardmarketPrice);
            }
            else
            {
                await message.Channel.SendMessageAsync($@"Invalid card name!");
            }
        }
        else if (command.StartsWith("info"))
        {
            string cardName = command.Replace("info ", "");
            if (cardName.Length > 0)
            {
                //ce je karta monster ne pokazi atk and def and level
                Card card = await GetCardData(cardName);
                if (card.Data[0].Type == "Spell Card" || card.Data[0].Type == "Trap Card")
                {
                    //await message.Channel.SendFileAsync($@"->" + card.Data[0].CardImages[0].ImageUrl);
                    await message.Channel.SendMessageAsync($@"{message.Author.Mention} the information for " + cardName + " is: " + $"{Environment.NewLine} ID: " + card.Data[0].Id + $"{Environment.NewLine} Name: " + card.Data[0].Name + $"{Environment.NewLine} Archetype: " + card.Data[0].Archetype + $"{Environment.NewLine} Type: " + card.Data[0].Type + $"{Environment.NewLine} Description: " + card.Data[0].Desc);
                }
                else if (card.Data[0].Type == "Link Monster")
                {
                    //await message.Channel.SendFileAsync($@"" + card.Data[0].CardImages[0].ImageUrl);
                    await message.Channel.SendMessageAsync($@"{message.Author.Mention} the information for " + cardName + " is: " + $"{Environment.NewLine} ID: " + card.Data[0].Id + $"{Environment.NewLine} Name: " + card.Data[0].Name + $"{Environment.NewLine} Archetype: " + card.Data[0].Archetype + $"{Environment.NewLine} Type: " + card.Data[0].Type + $"{Environment.NewLine} ATK: " + card.Data[0].Atk + $"{Environment.NewLine} Description: " + card.Data[0].Desc);
                }
                else
                {
                    //await  message.Channel.SendFileAsync($@"" + card.Data[0].CardImages[0].ImageUrl);
                    await message.Channel.SendMessageAsync($@"{message.Author.Mention} the information for " + cardName + $" is: {Environment.NewLine}" + " ID: " + card.Data[0].Id + $"{Environment.NewLine} Name: " + card.Data[0].Name + $"{Environment.NewLine} Archetype: " + card.Data[0].Archetype + $"{Environment.NewLine} Type: " + card.Data[0].Type + $"{Environment.NewLine} Level: " + card.Data[0].Level + $"{Environment.NewLine} ATK: " + card.Data[0].Atk + $"{Environment.NewLine} DEF: " + card.Data[0].Def + $"{Environment.NewLine} Description: " + card.Data[0].Desc);
                }
            }
            else
            {
                await message.Channel.SendMessageAsync($@"Invalid card name!" + $"{Environment.NewLine} use !help");
            }
        }
        else if (command.Equals("help"))
        {
            await message.Channel.SendMessageAsync($@"Here is a list of commands: {Environment.NewLine}!hello - Says hello to you {Environment.NewLine}!age - Tells you when your account was created {Environment.NewLine}!info - Tells you the information about the card you are searching for {Environment.NewLine}!price - Tells you the price of the card you are looking for on cardmarket {Environment.NewLine}!help - Shows this message");
        }
        else
        {
            await message.Channel.SendMessageAsync($@"Command not found. Type !help for a list of commands.");
        }
    }
}
