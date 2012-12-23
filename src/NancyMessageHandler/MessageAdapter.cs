using System.Collections.Generic;

namespace NancyMessageHandler
{
    internal class MessageAdapter<T> : ITypedMessage<T> where T : class
    {
        private readonly ITypedMessage _inner;

        public MessageAdapter(ITypedMessage inner)
        {
            _inner = inner;
        }

        public IDictionary<string, object> Headers { get { return _inner.Headers; } }
        public T MessageBody { get { return _inner.GetMessageBody() as T; } }

        public string AssemblyQualifiedTypeName { get { return typeof(T).AssemblyQualifiedName; } }
    }
}