namespace LiteDB.StateStore.Builders
{
    public interface IStateOperationBuilder<T>
    {
        bool Set(T value);

        T Get();

        bool Delete();
    }
}