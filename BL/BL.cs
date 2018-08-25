using System.Collections.Generic;
using Sledz.Guitars.InterFaces;
using System.Reflection;
using System.IO;
using System.Configuration;


namespace Sledz.Guitars.BLogic
{
    public class Blogic //: IBL
    {
        private static IDAO _dao;

       
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


        public static List<IGuitar> GetAllGuitars()
        {
            if (_dao != null)
            {
                return _dao.GetAllGuitars();
            }
            return new List<IGuitar>();
        }
        public static List<IProducer> GetAllProducers()
        {
            if (_dao != null)
            {
                return _dao.GetAllProducers();
            }
            return new List<IProducer>();
        }
        
        

        public static bool AddGuitar(string producent, string model, string strings, string color)
        {
            return _dao.AddGuitar(producent, model, strings, color);

        }
        public static bool DeleteGuitar(string producent, string model, string strings)
        {
            return _dao.DeleteGuitar(producent, model, strings);
        }
        public static bool AddProducer(string producer, string country, string manufactures)
        {
            return _dao.AddProducer(producer, country, manufactures);
        }

        public static bool AddGuitar(IGuitar guitar)
        {
            return _dao.AddGuitar(guitar);
        }
        public static bool AddProducer(IProducer producer)
        {
            return _dao.AddProducer(producer);
        }
        public static bool DeleteGuitar(IGuitar guitar)
        {
            return _dao.DeleteGuitar(guitar);
        }
        public static bool DeleteProducer(IProducer producer)
        {
            return _dao.DeleteProducer(producer);
        }
        public static bool UpdateGuitar(IGuitar guitar)
        {
            return _dao.UpdateGuitar(guitar);
        }
        public static bool UpdateProducer(IProducer producer)
        {
            return _dao.UpdateProducer(producer);
        }
        public static IGuitar NewGuitar()
        {
            return _dao.NewGuitar();
        }
        public static IProducer NewProducer()
        {
            return _dao.NewProducer();
        }
        
    }
}
