using Discord.WebSocket;
using MillenniumEye.model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MillenniumEye.service
{
    public class CardService : ICardService
    {
        public async Task<Data> GetCardData(string cardName)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?name={cardName}";
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var card = JsonConvert.DeserializeObject<Data>(json);
            return card;
        }

        public async Task SendHelloMessageAsync(SocketMessage message)
        {
            await message.Channel.SendMessageAsync($"Hello {message.Author.Mention}");
        }

        public async Task SendAccountAgeMessageAsync(SocketMessage message)
        {
            await message.Channel.SendMessageAsync($"Your account was created at {message.Author.Mention} on {message.Author.CreatedAt.DateTime.ToShortDateString()}");
        }

        public async Task SendCardPriceMessageAsync(SocketMessage message)
        {
            string cardName = message.Content["!price".Length..].Trim();
            if (string.IsNullOrEmpty(cardName))
            {
                await message.Channel.SendMessageAsync("Invalid card name. Please provide a valid card name.");
                return;
            }

            var card = await GetCardData(cardName);
            if (card == null || card.CardData == null || !card.CardData.Any())
            {
                await message.Channel.SendMessageAsync($"No information found for the card '{cardName}'.");
                return;
            }

            await message.Channel.SendMessageAsync($"{message.Author.Mention}, the price for {cardName} is: {card.CardData[0].CardPrices[0].CardmarketPrice}");
        }

        public async Task SendCardInformationMessageAsync(SocketMessage message)
        {
            string cardName = message.Content["!info".Length..].Trim();
            if (string.IsNullOrEmpty(cardName))
            {
                await message.Channel.SendMessageAsync("Invalid card name. Please provide a valid card name.");
                return;
            }

            var card = await GetCardData(cardName);
            if (card == null || card.CardData == null || !card.CardData.Any())
            {
                await message.Channel.SendMessageAsync($"No information found for the card '{cardName}'.");
                return;
            }

            if (card.CardData[0].Type == "Spell Card" || card.CardData[0].Type == "Trap Card")
            {
                await message.Channel.SendMessageAsync($@"{message.Author.Mention} the information for " + cardName + " is: " + $"{Environment.NewLine} ID: " + card.CardData[0].Id + $"{Environment.NewLine} Name: " + card.CardData[0].Name + $"{Environment.NewLine} Archetype: " + card.CardData[0].Archetype + $"{Environment.NewLine} Type: " + card.CardData[0].Type + $"{Environment.NewLine} Description: " + card.CardData[0].Desc);
            }
            else if (card.CardData[0].Type == "Link Monster")
            {
                await message.Channel.SendMessageAsync($@"{message.Author.Mention} the information for " + cardName + " is: " + $"{Environment.NewLine} ID: " + card.CardData[0].Id + $"{Environment.NewLine} Name: " + card.CardData[0].Name + $"{Environment.NewLine} Archetype: " + card.CardData[0].Archetype + $"{Environment.NewLine} Type: " + card.CardData[0].Type + $"{Environment.NewLine} ATK: " + card.CardData[0].Atk + $"{Environment.NewLine} Description: " + card.CardData[0].Desc);
            }
            else
            {
                await message.Channel.SendMessageAsync($@"{message.Author.Mention} the information for " + cardName + $" is: {Environment.NewLine}" + " ID: " + card.CardData[0].Id + $"{Environment.NewLine} Name: " + card.CardData[0].Name + $"{Environment.NewLine} Archetype: " + card.CardData[0].Archetype + $"{Environment.NewLine} Type: " + card.CardData[0].Type + $"{Environment.NewLine} Level: " + card.CardData[0].Level + $"{Environment.NewLine} ATK: " + card.CardData[0].Atk + $"{Environment.NewLine} DEF: " + card.CardData[0].Def + $"{Environment.NewLine} Description: " + card.CardData[0].Desc);
            }
        }

        public async Task SendHelpMessageAsync(SocketMessage message)
        {
            await message.Channel.SendMessageAsync($@"Here is a list of commands: {Environment.NewLine}!hello - Says hello to you {Environment.NewLine}!age - Tells you when your account was created {Environment.NewLine}!info - Tells you the information about the card you are searching for {Environment.NewLine}!price - Tells you the price of the card you are looking for on cardmarket {Environment.NewLine}!help - Shows this message");
        }
    }
}
