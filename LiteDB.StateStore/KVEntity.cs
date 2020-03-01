namespace LiteDB.StateStore
{
    internal class KVEntity<T>
    {
        public static string DefaultCollection { get; } = $"statestore${typeof(T).Name}";
        public string Id { get; set; }
        public T Value { get; set; }
    }
}