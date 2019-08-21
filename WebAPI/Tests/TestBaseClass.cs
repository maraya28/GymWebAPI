namespace GymWebAPI.Tests
{
    public abstract class TestBaseClass<T> where T: class
    {
        public T Target { get; set; }

        public virtual void Initialize()
        {

        }
    }
}
