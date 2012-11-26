using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NancyMessageHandler
{
    public static class HandlerExtensions
    {
        public static Action<JsonMessage> DeserializeAs<T>(this JsonMessage message, Action<JsonMessage<T>> newHandler)
        {
            return m =>
                       {
                           var strong = JsonConvert.DeserializeObject<T>(message.Content);
                           newHandler(new JsonMessage<T>(m,strong));
                       };
        }


        public static void AddStrongHandler<T>(this IDictionary<string, Action<JsonMessage>> handlers, string path, Action<JsonMessage<T>> newHandler)
        {
            handlers[path] = m => m.DeserializeAs<T>(newHandler);
        }
        
    }
}