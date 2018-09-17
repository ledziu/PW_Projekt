using System;
using System.Collections.Generic;
using System.Text;
using Sledz.Guitars.Core;
using Sledz.Guitars.InterFaces;
using System.Linq;

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
                new Producer("EEE"),
            };
            _guitars = new List<IGuitar> {
                new Guitar(_producers.Find(x=>x.Name == "Gibson"),"Explorer",6,"blue"),
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
            else { return false; }
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

        public IGuitar NewGuitar()
        {
            return new Guitar();
        }
        public IProducer NewProducer() => new Producer();

        public bool UpdateGuitar(IProducer producer, string model, int strings, string color) {
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
        public bool UpdateProducer(IProducer producer)
        {
            if (_producers.Contains(producer))
            {
                _producers.Where(x => x.Equals(producer)).ToList().ForEach(x => { x.Country = producer.Country; x.Manufactures = producer.Manufactures; });
                return true;
            }
            return false;
        }
        private int CountProducersGuitar(IProducer producer)
        {
            return _guitars.Where(x => x.Producer.Equals(producer)).Count();
        }

    }

}


