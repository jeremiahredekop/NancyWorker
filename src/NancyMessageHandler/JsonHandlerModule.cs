using System;
using System.Collections.Generic;

namespace NancyMessageHandler
{
    public abstract class JsonHandlerModule
    {
        private readonly string _rootuUl;

        protected JsonHandlerModule(string rootuUl)
        {
            _rootuUl = rootuUl;
        }

        protected abstract void RegisterHandlers();


        protected IDictionary<string, Action<JsonMessage>> Handle { get; private set; }


    }
}