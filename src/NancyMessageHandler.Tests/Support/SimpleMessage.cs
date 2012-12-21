using System.Collections.Generic;

namespace NancyMessageHandler.Tests.Support
{
    public class SimpleMessage : ITypedMessage
    {
        public SimpleMessage(object body)
        {
            Headers = new Dictionary<string, object>();
            MessageBody = body;
            AssemblyQualifiedTypeName = body.GetType().AssemblyQualifiedName;
        }

        public IDictionary<string, object> Headers { get; set; }
        public object MessageBody { get; set; }
        public string AssemblyQualifiedTypeName { get; private set; }
    }
}