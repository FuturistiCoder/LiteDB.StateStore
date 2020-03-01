using System;

namespace LiteDB.StateStore.Builders
{
    public interface IRealtimeStateOperationBuilder<T> : IStateOperationBuilder<T>, IObservable<T>
    { }
}