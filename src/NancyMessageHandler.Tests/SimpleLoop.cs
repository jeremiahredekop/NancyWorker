using System;
using System.Threading;

namespace NancyMessageHandler.Tests
{
    public class SimpleLoop
    {
        private readonly Action _workItem;
        private readonly int _sleepInterval;

        public SimpleLoop(Action workItem, int sleepInterval)
        {
            _workItem = workItem;
            _sleepInterval = sleepInterval;
        }

        private bool _keepWorking;

        public void Work()
        {
            _keepWorking = true;

            while (_keepWorking)
            {
                _workItem.Invoke();
                Thread.Sleep(_sleepInterval);
            }
        }

        public void Stop()
        {
            _keepWorking = false;
        }
    }
}
