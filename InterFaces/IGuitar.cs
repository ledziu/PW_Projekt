using System;

namespace Sledz.Guitars.InterFaces
{
    public interface IGuitar : IEquatable<IGuitar>
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
        int Strings
        {
            set;
            get;
        }
        string Color
        {
            set;
            get;
        }
    }
}
