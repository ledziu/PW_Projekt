namespace Sledz.Guitars.InterFaces
{
    public interface IGuitar
    {
        Sledz.Guitars.InterFaces.IProducer Producer
        {
            set;
            get;
        }
        string Model
        {
            set;
            get;
        }

    }
}
