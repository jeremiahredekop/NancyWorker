using System.Collections.Generic;

namespace NancyMessageHandler
{
    internal class MessageAdapter<T> : IMessage<T> where T : class
    {
        private readonly IMessage _inner;

        public MessageAdapter(IMessage inner)
        {
            _inner = inner;
        }

        public IDictionary<string, object> Headers { get { return _inner.Headers; } }
        public T MessageBody { get { return _inner.MessageBody as T; } }

        object IMessage.MessageBody
        {
            get { return MessageBody; }
        }

        public string AssemblyQualifiedTypeName { get { return typeof(T).AssemblyQualifiedName; } }
    }
}