namespace NancyMessageHandler
{
    public interface IMessageHandlerFacade
    {
        void HandleMessage(IMessage message);
    }
}