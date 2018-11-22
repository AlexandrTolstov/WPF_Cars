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
using System.IO;
using System.Collections;

namespace WPF_Cars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame mf { get; set; }

        public static List<CarsInfo> ListOfCars;
        public static int TagCars = 0;

        public MainWindow()
        {
            InitializeComponent();
            mf = MainFrame;
            MainFrame.Source = new Uri("Pages/Tab1_MainPage.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
