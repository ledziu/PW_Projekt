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
            _producers = new List<IProducer> {
                new Producer("BCRich",CountryName.USA,10),
                new Producer("Gretsch", CountryName.USA, 30),
                new Producer("Lootnick", CountryName.Poland, 1),
                new Producer("PRS", CountryName.Japan, 100),
                new Producer("ESP", CountryName.USA, 20),
            };
            _guitars = new List<IGuitar> {
                new Guitar(_producers.Find(x=>x.Name == "BCRich"),"KK2"),
                new Guitar(_producers.Find(x=>x.Name == "Gretsch"),"G9500"),
                new Guitar(_producers.Find(x=>x.Name == "Gretsch"),"G540T"),
                new Guitar(_producers.Find(x=>x.Name == "Lootnick"),"White Angel"),
                new Guitar(_producers.Find(x=>x.Name == "Lootnick"),"Relic"),
                new Guitar(_producers.Find(x=>x.Name == "PRS"),"SE"),
                new Guitar(_producers.Find(x=>x.Name == "PRS"),"Custom 24"),
                new Guitar(_producers.Find(x=>x.Name == "ESP"),"Nergal"),
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
