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
using System.Windows.Shapes;
using RockLife.Models;
using RockLife.Repository;
using RockLife.Pages;

namespace RockLife
{
    /// <summary>
    /// Interaction logic for CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        private ProductRepository _productRepository;

        public CatalogWindow()
        {
            InitializeComponent();

            MainFrame.Content = new PageOne();
        }

       
    }
}
