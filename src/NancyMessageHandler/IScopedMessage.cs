namespace NancyMessageHandler
{
    public interface IScopedMessage : IMessage
    {
        string MessageAddress { get; }
        T GetMessageBody<T>();
    }
}