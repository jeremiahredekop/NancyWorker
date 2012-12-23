namespace NancyMessageHandler
{
    public interface ITypedMessage<out T> : IMessage   
    {
        T MessageBody { get; }
    }

    public interface ITypedMessage : IMessage
    {
        string AssemblyQualifiedTypeName { get;  }
        object GetMessageBody();
    }
}