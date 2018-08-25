using System;
using System.Collections.Generic;
using System.Text;
using Sledz.Guitars.InterFaces;

namespace Sledz.Guitars.ViewModels
{
    public class ProducerViewModel : ViewModelBase
    {
        private IProducer _producer;
        public ProducerViewModel(IProducer producer)
        {
            _producer = producer;
        }
        public IProducer GetProducer()
        {
            return _producer;
        }

        public override string ToString()
        {
            return Name;
        }
        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public Sledz.Guitars.Core.CountryName Country
        {
            get => _producer.Country;
            set
            {
                _producer.Country = value;
                OnPropertyChanged("Country");
            }
        }
        public int Manufactures
        {
            get => _producer.Manufactures;
            set
            {
                _producer.Manufactures = value;
                OnPropertyChanged("Manufactures");
            }
        }
        public void Validate()
        {
            RemoveErrors(nameof(Name));
            RemoveErrors(nameof(Country));
            RemoveErrors(nameof(Manufactures));
        }
    }
}
