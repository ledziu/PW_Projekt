using System;
using System.Collections.Generic;
using System.Text;
using Sledz.Guitars.Core;
using Sledz.Guitars.InterFaces;

namespace Sledz.Guitars.DAO
{
    public class DAOMock : IDAO
    {
        private List<IGuitar> _guitars;
        private List<IProducer> _producers;

        public DAOMock()
        {
            _producers = new List<IProducer>
            {
                new Producer("Cort",CountryName.China,100),
                new Producer("Fender", CountryName.Mexico, 300),
                new Producer("Gibson", CountryName.USA, 400),
                new Producer("Ibanez", CountryName.Japan, 300),
                new Producer("Mayonez", CountryName.Poland, 1),
                new Producer("Skervesen", CountryName.Poland, 3),
            };
            _guitars = new List<IGuitar> {
                new Guitar(_producers.Find(x=>x.Name == "Gibson"),"Explorer",6),
                new Guitar(_producers.Find(x=>x.Name == "Gibson"),"SG",6),
                new Guitar(_producers.Find(x=>x.Name == "Gibson"),"V",6),
                new Guitar(_producers.Find(x=>x.Name == "Cort"),"Zenox",6),
                new Guitar(_producers.Find(x=>x.Name == "Fender"),"Telecaster",6),
                new Guitar(_producers.Find(x=>x.Name == "Ibanez"),"RG",7),
                new Guitar(_producers.Find(x=>x.Name == "Mayonez"),"Regius",7),
                new Guitar(_producers.Find(x=>x.Name == "Skervesen"),"4T",7),
            };
        }
        public List<IGuitar> GetAllGuitars()
        {
            return _guitars;
        }

        public List<IGuitar> GetAllGuiters()
        {
            throw new NotImplementedException();
        }


        public List<IProducer> GetAllProducers()
        {
            return _producers;
        }
    }

}


