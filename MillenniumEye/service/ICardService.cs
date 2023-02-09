using Discord.WebSocket;
using MillenniumEye.model;

namespace MillenniumEye.service
{
    public interface ICardService
    {
        Task<Card> GetCardData(string cardName);
        Task SendAccountAgeMessageAsync(SocketMessage message);
        Task SendCardInformationMessageAsync(SocketMessage message, string command);
        Task SendCardPriceMessageAsync(SocketMessage message, string command);
        Task SendHelloMessageAsync(SocketMessage message);
        Task SendHelpMessageAsync(SocketMessage message);
    }
}