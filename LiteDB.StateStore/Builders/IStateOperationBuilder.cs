namespace LiteDB.StateStore.Builders
{
    public interface IStateOperationBuilder<T>
    {
        bool Set(T value);
        T Get(T defaultValue = default);
        bool TryGet(out T value);
        bool Delete();
    }
}