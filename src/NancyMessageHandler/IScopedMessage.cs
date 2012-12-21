namespace NancyMessageHandler
{
    public interface IScopedMessage<T> : IMessage<T>, IScopedMessage
    {
    }

    public interface IScopedMessage : IMessage
    {
        string MessageAddress { get; set; }
    }
}