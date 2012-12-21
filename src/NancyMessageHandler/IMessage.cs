using System.Collections.Generic;

namespace NancyMessageHandler
{
    public interface IMessage
    {
        IDictionary<string, object> Headers { get; }
        object MessageBody { get;  }
    }

    public interface ITypedMessage : IMessage
    {
        string AssemblyQualifiedTypeName { get;  }
    }

    public interface IMessage<out T> : ITypedMessage
    {
        new T MessageBody { get;  }
    }
}