using System;
using System.Collections.Generic;
using System.Text;
using Sledz.Guitars.Core;
using Sledz.Guitars.InterFaces;

namespace Sledz.Guitars.DAO
{
    public class Producer : IProducer
    {
        private string _name;
        private int _manufactures;
        private Sledz.Guitars.Core.CountryName _Country;
        public Producer() { }
        public Producer(string _producerName, Sledz.Guitars.Core.CountryName _Country, int _manufactures)
        {
            Name = _producerName;
            Country = _Country;
            Manufactures = _manufactures;
        }
        public Producer(string _producerName)
        {
            Name = _producerName;
            Country = (CountryName)System.Enum.Parse(typeof(CountryName), "USA");
            Manufactures = 0;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Manufactures
        {
            get => _manufactures;
            set => _manufactures = value;
        }
        public Sledz.Guitars.Core.CountryName Country
        {
            get => _Country;
            set => _Country = value;
        }

        public bool Equals(IProducer other)
        {
            if (Name == other.Name)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("Name: {0,-20} Factories: {2}, Source Country: {1,-20}", Name, Country, Manufactures);
        }

    }
}
