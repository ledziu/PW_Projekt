using Sledz.Guitars.InterFaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Linq;

namespace Sledz.Guitars.Wpf.ViewModels
{
    public class GuitarViewModel : ViewModelBase
    {
        private IGuitar _guitar;

        public GuitarViewModel(IGuitar guitar)
        {
            _guitar = guitar;
        }
        [Required(ErrorMessage = "Guitar must have a producer")]
        public IProducer Producer
        {
            get => _guitar.Producer;
            set
            {
                _guitar.Producer = value;
                OnPropertyChanged(nameof(Producer));
                Validate();
            }
        }
        
        public IGuitar GetGuitar()
        {
            return _guitar;
        }
        [Required(ErrorMessage = "Guitar must have a Model")]
        public string Model
        {
            get => _guitar.Model;
            set
            {
                _guitar.Model = value;
                OnPropertyChanged(nameof(Model));
                Validate();
            }
        }
        [Required(ErrorMessage = "Guitar must have strings")]
        [Range(0,int.MaxValue,ErrorMessage ="Guitar must have strings")]
        public int Strings
        {
            get => _guitar.Strings;
            set
            {
                _guitar.Strings = value;
                OnPropertyChanged(nameof(Strings));
                Validate();
            }
        }
        [Required(ErrorMessage = "Guitar must have a Color")]
        public string Color
        {
            get => _guitar.Color;
            set
            {
                _guitar.Color = value;
                OnPropertyChanged(nameof(Color));
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
