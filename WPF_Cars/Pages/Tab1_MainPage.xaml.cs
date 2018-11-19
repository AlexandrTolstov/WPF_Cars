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

namespace WPF_Cars.Pages
{
    /// <summary>
    /// Interaction logic for Tab1_MainPage.xaml
    /// </summary>
    public partial class Tab1_MainPage : Page
    {
        public Tab1_MainPage()
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
                Label label = new Label { Content = "Файлы не прочитаны, папку с png нужно положить рядом с exe" + ex.Message };
                WrapCatalogCars.Children.Add(label);
            }

            Grid[] grids = new Grid[ListOfCars.Count];
            Label[] labels = new Label[ListOfCars.Count];
            Image[] image = new Image[ListOfCars.Count];

            Run[] linkTexts = new Run[ListOfCars.Count];
            Hyperlink[] hyperlinks = new Hyperlink[ListOfCars.Count];

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
                hyperlinks[i].Tag = Car.Name;

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
            //TextBox1.Text = "Клик " + ((Hyperlink)sender).Tag;
            MainWindow.mf.Source = new Uri("Pages/Cars.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
