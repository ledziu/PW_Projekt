using System;

namespace Sledz.Guitars.InterFaces
{
    public interface IProducer : IEquatable<IProducer>
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
        int Manufactures
        {
            set;
            get;
        }
    }
}
