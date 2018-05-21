using System;
using Sledz.Guitars.InterFaces;

namespace Sledz.Guitars.DAO
{


    public class Guitar : IGuitar
    {
        private InterFaces.IProducer _producer;
        private string _model;
        private int _strings;
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


        public Guitar(InterFaces.IProducer _producer, string _model)
        {
            Producer = _producer;
            Model = _model;
            Strings = 0;
        }
        public Guitar(InterFaces.IProducer _producer, string _model,int _strings)
        {
            Producer = _producer;
            Model = _model;
            Strings = _strings;
        }


        public override string ToString()
        {
            return string.Format("Producer: {0,-20} Model: {1,-20} Strings: {0,-20}", Producer.Name, Model,Strings);
        }

    }
}
