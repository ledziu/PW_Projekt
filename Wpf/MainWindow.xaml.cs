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
using System.Diagnostics;
using System.IO;
using Sledz.Guitars.Core;

namespace Sledz.Guitars.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       
        public MainWindow()
        {
            Sledz.Guitars.BLogic.Blogic  bl = new Sledz.Guitars.BLogic.Blogic(Sledz.Guitars.Wpf.Properties.Settings.Default.LibraryName);
            
            InitializeComponent();
            

        }

       


        
    }
}
