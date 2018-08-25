using System;
using System.Collections.Generic;
using System.Text;
using Sledz.Guitars.Core;
using System.Linq;
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
        public bool AddGuitar(IGuitar guitar)
        {

            if (!_guitars.Contains(guitar))
            {
                _guitars.Add(guitar);
                return true;
            }
            return false;
        }
        public bool AddGuitar(string producent, string model, string strings, string color)
        {
            int Intstrings = Int32.Parse(strings);
            var guitar = new Guitar(_producers.Find(x => x.Name == producent), model, Intstrings, color);
            if (!_guitars.Contains(guitar))
            {
                _guitars.Add(guitar);
                return true;
            }
            return false;
        }
        public bool AddProducer(IProducer producer)
        {
            if (!_producers.Contains(producer))
            {
                _producers.Contains(producer);
                return true;
            }
            return false;
        }

        public bool AddProducer(string producer, string country, string manufactures)
        {
            int Intmanufactures = Int32.Parse(manufactures);
            var prod = new Producer(producer, (CountryName)System.Enum.Parse(typeof(CountryName), country), Intmanufactures);
            if (!_producers.Contains(prod))
            {
                _producers.Add(prod);
                return true;
            }
            return false;
        }
        public bool DeleteGuitar(IGuitar guitar)
        {
            if (_guitars.Contains(guitar))
            {
                _guitars.Remove(guitar);
                return true;
            }
            return false;
        }
        public bool DeleteGuitar(string producent, string model, string strings)
        {
            int Intstrings = Int32.Parse(strings);
            var guitar = new Guitar(_producers.Find(x => x.Name == producent), model);
            if (_guitars.Contains(guitar))
            {
                _guitars.Remove(guitar);
                return true;
            }
            return false;

        }
        public bool DeleteProducer(IProducer producer)
        {
            if (_producers.Contains(producer))
            {
                if (_guitars.Where(x => x.Producer.Equals(producer)).Count() == 0)
                {
                    _producers.Remove(producer);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteProducer(string name)
        {
            var producer = new Producer(name);
            if (_producers.Contains(producer))
            {
                if (_guitars.Where(x => x.Producer.Equals(producer)).Count() == 0)
                {
                    _producers.Remove(producer);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateGuitar(IProducer producer, string model, int strings, string color)
        {
            var guitar = new Guitar(producer, model, strings);
            if (_guitars.Contains(guitar))
            {
                _guitars.Where(x => x.Equals(guitar)).ToList().ForEach(x => { x.Color = color; });
                return true;
            }


            return false;
        }
        public bool UpdateGuitar(IGuitar guitar)
        {
            if (_guitars.Contains(guitar))
            {
                _guitars.Where(x => x.Equals(guitar)).ToList().ForEach(x => { x.Color = guitar.Color; });
                return true;
            }
            return false;
        }

        public bool UpdateProducer(string name, string country, int manufactures)
        {
            var producer = new Producer(name, (CountryName)System.Enum.Parse(typeof(CountryName), country), manufactures);
            if (_producers.Contains(producer))
            {
                _producers.Where(x => x.Equals(producer)).ToList().ForEach(x => { x.Country = (CountryName)System.Enum.Parse(typeof(CountryName), country); x.Manufactures = manufactures; });
                return true;
            }
            return false;
        }
        public bool UpdateProducer(IProducer producer) {
            if (_producers.Contains(producer))
            {
                _producers.Where(x => x.Equals(producer)).ToList().ForEach(x => { x.Country =  producer.Country; x.Manufactures = producer.Manufactures; });
                return true;
            }
            return false;
        }
    
        public IGuitar NewGuitar() => new Guitar();
        public IProducer NewProducer() => new Producer();


    }
}
