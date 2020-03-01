using System;

namespace LiteDB.StateStore.Builders
{
    internal class RealtimeStateOperationBuilder<T> : StateOperationBuilder<T>, IRealtimeStateOperationBuilder<T>
    {
        private readonly IObservable<T> _observable;

        public RealtimeStateOperationBuilder(LiteCollection<KVEntity<T>> collection, string id, IObservable<T> observable)
            : base(collection, id)
        {
            _observable = observable;
        }

        public IDisposable Subscribe(IObserver<T> observer)
            => _observable.Subscribe(observer);
    }
}