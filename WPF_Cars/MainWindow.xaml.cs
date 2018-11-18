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
        public MainWindow()
        {
            InitializeComponent();

            DirectoryInfo dir = new DirectoryInfo(@"png");
            List<CarsInfo> ListOfCars = new List<CarsInfo>();
            try
            {
                foreach (FileInfo files in dir.GetFiles())
                {
                    ListOfCars.Add(new CarsInfo(files.Name));
                }
            }
            catch (Exception ex)
            {
                Label label = new Label { Content = "Файлы не прочитаны" + ex.Message };
                WrapCatalogCars.Children.Add(label);
            }

            Grid [] grids = new Grid[ListOfCars.Count];
            Label [] labels = new Label[ListOfCars.Count];
            Image [] image = new Image[ListOfCars.Count];
            int i = 0;

            foreach (CarsInfo Car in ListOfCars)
            {
                image[i] = new Image
                {
                    Height = 40,
                    Source = new BitmapImage(new Uri(Car.Path, UriKind.RelativeOrAbsolute))
                };

                grids[i] = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(10)
                };
                grids[i].ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grids[i].ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                grids[i].Children.Add(image[i]);

                labels[i] = new Label { Content = Car.Name, Width = 100, Target = grids[i] };

                grids[i].Children.Add(labels[i]);

                Grid.SetColumn(grids[i], 0);
                Grid.SetColumn(labels[i], 1);

                WrapCatalogCars.Children.Add(grids[i]);

                i++;
            }
            i = 0;  
        }
    }
}
