using System;
using System.Collections.Generic;
using System.Text;
using Sledz.Guitars.Core;

namespace Sledz.Guitars.DAO
{
    public class Producer : Sledz.Guitars.InterFaces.IProducer
    {
        private string _name;
        private int _manufactures;
        private Sledz.Guitars.Core.CountryName _Country;
        public Producer(string _producerName, Sledz.Guitars.Core.CountryName _Country, int _manufactures)
        {
            Name = _producerName;
            Country = _Country;
            manufactures = _manufactures;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int manufactures
        {
            get => _manufactures;
            set => _manufactures = value;
        }
        public Sledz.Guitars.Core.CountryName Country
        {
            get => _Country;
            set => _Country = value;
        }
        public override string ToString()
        {
            return string.Format("Name: {0,-20} Factories: {2}, Source Country: {1,-20}", Name, Country, manufactures);
        }

    }
}
