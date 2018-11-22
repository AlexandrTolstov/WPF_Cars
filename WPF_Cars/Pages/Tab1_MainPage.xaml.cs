using System;
using System.Collections.Generic;
using System.IO;
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
using WPF_Cars.Pages;

namespace WPF_Cars.Pages
{
    /// <summary>
    /// Interaction logic for Tab1_MainPage.xaml
    /// </summary>
    public partial class Tab1_MainPage : Page
    {
        //public static List<CarsInfo> ListOfCars;
        //public static int TagCars = 0;

        public Tab1_MainPage()
        {
            InitializeComponent();

            DirectoryInfo dir = new DirectoryInfo(@"png");
            MainWindow.ListOfCars = new List<CarsInfo>();
            try
            {
                foreach (FileInfo files in dir.GetFiles())
                {
                    MainWindow.ListOfCars.Add(new CarsInfo(files.Name));
                }
            }
            catch (Exception ex)
            {
                Label label = new Label { Content = "Файлы не прочитаны, папку с png нужно положить рядом с exe" + ex.Message };
                WrapCatalogCars.Children.Add(label);
            }

            Grid[] grids = new Grid[MainWindow.ListOfCars.Count];
            Label[] labels = new Label[MainWindow.ListOfCars.Count];
            Image[] image = new Image[MainWindow.ListOfCars.Count];

            Run[] linkTexts = new Run[MainWindow.ListOfCars.Count];
            Hyperlink[] hyperlinks = new Hyperlink[MainWindow.ListOfCars.Count];

            int i = 0;

            foreach (CarsInfo Car in MainWindow.ListOfCars)
            {
                image[i] = new Image
                {
                    Height = 40,
                    Source = new BitmapImage(new Uri(Car.Path, UriKind.RelativeOrAbsolute))
                };

                grids[i] = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(10),
                };
                grids[i].ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grids[i].ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                grids[i].Children.Add(image[i]);

                labels[i] = new Label { Content = Car.Name, Width = 100, Target = grids[i] };

                linkTexts[i] = new Run(Car.Name);
                hyperlinks[i] = new Hyperlink(linkTexts[i]);

                labels[i].Content = hyperlinks[i];

                hyperlinks[i].Click += MainWindow_Click;
                hyperlinks[i].Tag = i;

                grids[i].Children.Add(labels[i]);

                Grid.SetColumn(grids[i], 0);
                Grid.SetColumn(labels[i], 1);

                WrapCatalogCars.Children.Add(grids[i]);

                i++;
            }
            i = 0;
        }
        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mf.Source = new Uri("Pages/Cars.xaml", UriKind.RelativeOrAbsolute);

            MainWindow.TagCars = (Int32)(((Hyperlink)sender).Tag);
        }
    }
}
