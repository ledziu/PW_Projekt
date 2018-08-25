using System;
using System.Collections.Generic;
using System.Text;
using Sledz.Guitars.InterFaces;

namespace Sledz.Guitars.InterFaces
{
    public interface IBL
    {
        List<IGuitar> GetAllGuitars();
        List<IProducer> GetAllProducers();

    }
}
