using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sledz.Guitars.BLogic;
using Sledz.Guitars.InterFaces;
using System.Configuration;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<IGuitar> list_guitars;
        public List<IProducer> list_producers;
        public MainWindow()
        {
            InitializeComponent();
            IDAO bl = new Blogic(Properties.Settings.Default.LibraryName);
           // list_guitars = bl.GetAllGuitars();
           // list_producers = bl.GetAllProducers();





        }
    }
}
