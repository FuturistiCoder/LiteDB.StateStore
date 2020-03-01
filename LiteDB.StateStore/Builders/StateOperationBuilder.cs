namespace LiteDB.StateStore.Builders
{
    internal class StateOperationBuilder<T> : IStateOperationBuilder<T>
    {
        private readonly LiteCollection<KVEntity<T>> _collection;
        private readonly string _id;

        public StateOperationBuilder(LiteCollection<KVEntity<T>> collection, string id)
        {
            _collection = collection;
            _id = id;
        }

        public bool Delete()
            => _collection.Delete(_id);

        public T Get()
        {
            var entity = _collection.FindById(_id);
            if (entity is null)
            {
                return default;
            }
            return entity.Value;
        }

        public bool Set(T value)
            => _collection.Upsert(new KVEntity<T> { Id = _id, Value = value });
    }
}