using System;
using System.Collections.Generic;
using Sledz.Guitars.InterFaces;
using Sledz.Guitars.BLogic;
using System.Reflection;
using System.IO;


namespace Sledz.Guitars.ConsoleUi
{
    class UI
    {
        static void Main(string[] args)
        {
            Menu();
            IDAO bl = new Blogic();


            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.WriteLine();
                    PrintGuitars(bl.GetAllGuitars());
                    break;
                case '2':
                    //Producenci
                    Console.WriteLine();
                    PrintProducers(bl.GetAllProducers());
                    break;
                default:
                    Console.WriteLine("Wrong number");
                    break;
            }
        }
        static private void Menu()
        {
            Console.Clear();
            Console.WriteLine("1 - List all Guitars");
            Console.WriteLine("2 - List all Producents");
        }

        static private void PrintGuitars(List<IGuitar> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine(i.ToString());
            }
        }
        static private void PrintProducers(List<IProducer> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine(i.ToString());
            }
        }

    }
}
