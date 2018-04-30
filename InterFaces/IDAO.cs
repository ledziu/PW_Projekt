using System.Collections.Generic;

namespace Sledz.Guitars.InterFaces
{
    public interface IDAO
    {
        List<IGuitar> GetAllGuitars();
        List<IProducer> GetAllProducers();
    }
}
