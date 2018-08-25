using System;
using System.Collections.Generic;
using System.Text;
using Sledz.Guitars.Core;
using Sledz.Guitars.InterFaces;


namespace Sledz.Guitars.ViewModels
{
    public class GuitarViewModel : ViewModelBase
    {
        private IGuitar _guitar;

        public GuitarViewModel(IGuitar guitar)
        {
            _guitar = guitar;
        }
        public IProducer Producer
        {
            get => _guitar.Producer;
            set
            {
                _guitar.Producer = value;
                OnPropertyChanged("Name");
            }
        }
        public IGuitar GetGuitar()
        {
            return _guitar;
        }
        public string Model
        {
            get => _guitar.Model;
            set
            {
                _guitar.Model = value;
                OnPropertyChanged("Model");
            }
        }
        public int Strings
        {
            get => _guitar.Strings;
            set
            {
                _guitar.Strings = value;
                OnPropertyChanged("Strings");
            }
        }
        public string Color
        {
            get => _guitar.Color;
            set
            {
                _guitar.Color = value;
                OnPropertyChanged("Color");
            }
        }
        public void Validate()
        {
            RemoveErrors(nameof(Producer));
            RemoveErrors(nameof(Model));
            RemoveErrors(nameof(Strings));
            RemoveErrors(nameof(Color));
        }
    }
}
