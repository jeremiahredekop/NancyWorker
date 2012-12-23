using System.Collections.Generic;
using Newtonsoft.Json;

namespace NancyMessageHandler.Tests.Support
{
    internal class JsonScopedMessage : IScopedMessage
    {
        private readonly string _messageBody;

        public JsonScopedMessage(string messageBody, IDictionary<string, object> headers, string messageAddress)
        {
            _messageBody = messageBody;
            MessageAddress = messageAddress;
            Headers = headers ?? new Dictionary<string, object>();
        }

        public IDictionary<string, object> Headers { get; private set; }
        public string MessageAddress { get; private set; }
        public T GetMessageBody<T>()
        {
            return JsonConvert.DeserializeObject<T>(_messageBody);
        }
    }
}