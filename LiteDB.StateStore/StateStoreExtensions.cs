using LiteDB.Realtime;
using LiteDB.StateStore.Builders;
using System;
using System.Reactive.Linq;

namespace LiteDB.StateStore
{
    public static class StateStoreExtensions
    {
        public static IRealtimeStateOperationBuilder<T> StateStore<T>(this RealtimeLiteDatabase db, string id)
        {
            if (db is null) throw new ArgumentNullException(nameof(db));
            var collection = db.GetCollection<KVEntity<T>>(KVEntity<T>.DefaultCollection);
            var observable = db.Realtime.Collection<KVEntity<T>>(KVEntity<T>.DefaultCollection)
                .Id(id)
                .Select(e => e is null ? default : e.Value);
            return new RealtimeStateOperationBuilder<T>(collection, id, observable);
        }

        public static IStateOperationBuilder<T> StateStore<T>(this LiteDatabase db, string id)
        {
            if (db is null) throw new ArgumentNullException(nameof(db));
            var collection = db?.GetCollection<KVEntity<T>>(KVEntity<T>.DefaultCollection);
            return new StateOperationBuilder<T>(collection, id);
        }
    }
}