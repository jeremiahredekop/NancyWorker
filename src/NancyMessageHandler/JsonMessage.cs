namespace NancyMessageHandler
{
    public class JsonMessage
    {
        public string Content { get; set; }
    }

    public class JsonMessage<T>
    {
        private readonly JsonMessage _originalMessage;

        public JsonMessage(JsonMessage originalMessage, T body)
        {
            Body = body;
            _originalMessage = originalMessage;
        }

        public string Content { get { return _originalMessage.Content; } }
        public T Body { get; private set; }
    }
}