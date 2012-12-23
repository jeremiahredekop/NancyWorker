using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NancyMessageHandler.Tests.Support
{
    internal class JsonTypedMessage : ITypedMessage
    {
        private readonly string _body;

        public static ITypedMessage FromMessage(object message)
        {
            return new JsonTypedMessage(JsonConvert.SerializeObject(message), message.GetType().AssemblyQualifiedName);
        }

        public JsonTypedMessage(string body, string assemblyQualifiedTypeName)
        {
            _body = body;
            Headers = new Dictionary<string, object>();
            AssemblyQualifiedTypeName = assemblyQualifiedTypeName;
        }

        public IDictionary<string, object> Headers { get; set; }
        public object GetMessageBody()
        {
            return JsonConvert.DeserializeObject(_body, Type.GetType(AssemblyQualifiedTypeName));
        }
        public string AssemblyQualifiedTypeName { get; private set; }
    }
}