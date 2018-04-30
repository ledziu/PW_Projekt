using System.Collections.Generic;
using Sledz.Guitars.DAO;
using Sledz.Guitars.InterFaces;
using System.Reflection;
using System.IO;

namespace Sledz.Guitars.BLogic
{
    public class Blogic : IDAO
    {
        private IDAO _dao;

        public Blogic()
        {
            _dao = new DAOMock();
            //DAO2\bin\Debug\netstandard2.0\DAO2.dll
            //DAO\bin\Debug\netstandard2.0\DAO.dll

            BL. Properties.Settings settings = new BL.Properties.Settings();
            string dllpath = settings.DAOLocation;
            string DAOClassname = settings.DAOClassName;
            if (!dllpath.Contains(":"))
            {
                string directory = Directory.GetParent(@"../../../").FullName;
                dllpath = Path.Combine(directory, dllpath);
            }
            try
            {
                Assembly dll = Assembly.LoadFile(dllpath);
                System.Type type = dll.GetType(DAOClassname);
                _dao = (IDAO)System.Activator.CreateInstance(type, new object[] { });
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }

        }


        public List<IGuitar> GetAllGuitars()
        {
            return _dao.GetAllGuitars();
        }
        public List<IProducer> GetAllProducers()
        {
            return _dao.GetAllProducers();
        }

        static void Main(string[] args) { }

    }
}
