using System;
using System.Collections.Concurrent;

namespace LiteDB.StateStore
{
    public class SubscriptionManager : IDisposable
    {
        private readonly BlockingCollection<IDisposable> _disposables = new BlockingCollection<IDisposable>();

        public SubscriptionManager Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
            return this;
        }

        public static SubscriptionManager operator +(SubscriptionManager manager, IDisposable disposable)
            => manager.Add(disposable);

        public void Dispose()
        {
            _disposables.CompleteAdding();
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}