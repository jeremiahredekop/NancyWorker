using System;

namespace NancyMessageHandler.Implementations
{
    public class ReflectionModuleFactory : IModuleFactory
    {
        public MessageModule GetModule(Type typeRequested)
        {
            return (MessageModule) Activator.CreateInstance(typeRequested);
        }
    }
}
