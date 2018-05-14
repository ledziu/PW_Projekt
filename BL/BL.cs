using System.Collections.Generic;
using Sledz.Guitars.DAO;
using Sledz.Guitars.InterFaces;
using System.Reflection;
using System.IO;
using System.Configuration;


namespace Sledz.Guitars.BLogic
{
    public class Blogic : IDAO
    {
        private IDAO _dao;

        /*public Blogic()
        {
            _dao = new DAOMock();
            //DAO2\bin\Debug\netstandard2.0\DAO2.dll
            //DAO\bin\Debug\netstandard2.0\DAO.dll

           /* BL.Properties.Settings settings = new BL.Properties.Settings();
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

        }*/
        public Blogic(string DaoName)
        {
            try
            {
                var dao = Assembly.UnsafeLoadFrom(DaoName + ".dll");
                System.Type type =null;
                foreach (var t in dao.GetTypes())
                {
                    foreach (var i in t.GetInterfaces())
                    {

                    if (i.Name == "IDAO")
                        {
                            type = t;
                        }
                    }
                }
                ConstructorInfo constructorInfo = type.GetConstructor(new System.Type[] { });
                _dao = (IDAO)constructorInfo.Invoke(new System.Type[] { });
                

            }
            catch(System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
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
