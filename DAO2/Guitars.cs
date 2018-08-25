using System;
using Sledz.Guitars.InterFaces;

namespace Sledz.Guitars.DAO
{


    public class Guitar : IGuitar
    {
        private InterFaces.IProducer _producer;
        private string _model;
        private int _strings;
        private string _color;
        public String Model
        {
            get => _model;
            set => _model = value;
        }
        public IProducer Producer
        {
            get => _producer;
            set => _producer = value;
        }
        public int Strings
        {
            get => _strings;
            set => _strings = value;
        }
        public string Color
        {
            get => _color;
            set => _color = value;
        }
        public Guitar() { }

        public Guitar(InterFaces.IProducer _producer, string _model)
        {
            Producer = _producer;
            Model = _model;
            Strings = 0;
            Color = "Black";
        }
        
        public Guitar(InterFaces.IProducer _producer, string _model, int _strings)
        {
            Producer = _producer;
            Model = _model;
            Strings = _strings;
            Color = "Black";
        }
        public Guitar(InterFaces.IProducer _producer, string _model, int _strings,string _color)
        {
            Producer = _producer;
            Model = _model;
            Strings = _strings;
            Color = _color;
        }

        public bool Equals(IGuitar other)
        {
            if ((Producer == other.Producer) && (Model == other.Model) && (Strings == other.Strings))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return string.Format("Producer: {0,-20} Model: {1,-20} Strings: {2,-20} Color: {3,-20}", Producer.Name, Model, Strings,Color);
        }

    }
}
