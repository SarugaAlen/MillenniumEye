using Discord.WebSocket;
using MillenniumEye.model;

namespace MillenniumEye.service
{
    public interface ICardService
    {
        Task<Data> GetCardData(string cardName);
        Task SendAccountAgeMessageAsync(SocketMessage message);
        Task SendCardInformationMessageAsync(SocketMessage message);
        Task SendCardPriceMessageAsync(SocketMessage message);
        Task SendHelloMessageAsync(SocketMessage message);
        Task SendHelpMessageAsync(SocketMessage message);
    }
}