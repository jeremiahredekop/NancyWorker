using System;
using NancyMessageHandler.Implementations;

namespace NancyMessageHandler
{
    public interface IModuleFactory
    {
        MessageModule GetModule(Type typeRequested);
    }
}