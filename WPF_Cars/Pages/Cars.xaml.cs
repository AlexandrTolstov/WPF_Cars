﻿using System;
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

namespace WPF_Cars.Pages
{
    /// <summary>
    /// Interaction logic for Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        public Cars()
        {
            InitializeComponent();
            LogoImage.Source = new BitmapImage(new Uri(MainWindow.ListOfCars[MainWindow.TagCars].Path, UriKind.RelativeOrAbsolute));
        }
    }
}
