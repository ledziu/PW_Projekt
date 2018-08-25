using System.Collections.Generic;

namespace Sledz.Guitars.InterFaces
{
    public interface IDAO 
    {
        List<IGuitar> GetAllGuitars();
        List<IProducer> GetAllProducers();

        bool AddGuitar(string producent, string model, string strings,string color);
        bool AddGuitar(IGuitar guitar);
        bool AddProducer(IProducer producer);
        bool AddProducer(string producer, string country, string manufactures);


        bool DeleteGuitar(string producent, string model, string strings);
        bool DeleteGuitar(IGuitar guitar);
        bool DeleteProducer(string producer);
        bool DeleteProducer(IProducer producer);


        bool UpdateGuitar(IProducer producer, string model, int strings, string color);
        bool UpdateGuitar(IGuitar guitar);
        bool UpdateProducer(string name, string country, int manufactures);
        bool UpdateProducer(IProducer producer);


        
        IGuitar NewGuitar();
        IProducer NewProducer();

    }
}

