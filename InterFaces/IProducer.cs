namespace Sledz.Guitars.InterFaces
{
    public interface IProducer
    {
        string Name
        {
            set;
            get;
        }

        Sledz.Guitars.Core.CountryName Country
        {
            set;
            get;
        }
        int manufactures
        {
            set;
            get;
        }
    }
}
