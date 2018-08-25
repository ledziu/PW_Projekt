using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Sledz.Guitars.InterFaces;

namespace Sledz.Guitars.Wpf.ViewModels
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
        [Required(ErrorMessage = "Producer must have a name")]
        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                OnPropertyChanged(nameof(Name));
                Validate();
            }
        }
        [Required(ErrorMessage = "Producer must have a Country")]
        public Sledz.Guitars.Core.CountryName Country
        {
            get => _producer.Country;
            set
            {
                _producer.Country = value;
                OnPropertyChanged(nameof(Country));
                Validate();
            }
        }
        [Required(ErrorMessage = "Producer must have Manufactures")]
        [Range(0,int.MaxValue, ErrorMessage =">0")]
        public int Manufactures
        {
            get => _producer.Manufactures;
            set
            {
                _producer.Manufactures = value;
                OnPropertyChanged(nameof(Manufactures));
                Validate();
            }
        }
        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);
            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    OnErrorChanged(kv.Key);
                }
            }

            var q = from e in validationResults
                    from m in e.MemberNames
                    group e by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);
                OnErrorChanged(prop.Key);
            }
        
        }
    }
}
