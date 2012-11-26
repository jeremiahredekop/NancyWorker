using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NancyMessageHandler.Domain
{
    public interface IAggregateRepository
    {
        T GetById<T>(Guid id);
        void Save<T>(T aggregate);
    }

    public class JsonAggregateHandler<TAggregate>
    {
        public JsonAggregateHandler()
        {
            
        }
    }
}
