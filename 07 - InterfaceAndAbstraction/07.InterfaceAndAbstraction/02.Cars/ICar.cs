
namespace Cars
{
    public interface ICar
    {
        string  Model { get; set; }
        string Color { get; set; }

        public void Start();
        public void Stop();

    }
}
