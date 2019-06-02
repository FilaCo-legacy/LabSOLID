namespace LabSOLID
{
    public class MonoListEntry<T>
    {
        public MonoListEntry<T> Next { get; set; }

        public T Data { get; }
        
        public MonoListEntry (T data)
        {
            Data = data;
        }
    }
}