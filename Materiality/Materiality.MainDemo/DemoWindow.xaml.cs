using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Materiality.MainDemo
{
    /// <summary>
    /// Logika interakcji dla klasy DemoWindow.xaml
    /// </summary>
    public partial class DemoWindow : Window
    {
        public DemoWindow()
        {
            InitializeComponent();
       
          

           // DataContext = this;
        }





        private void sidebarToggle_Click(object sender, RoutedEventArgs e)
        {
            sidebar.IsActive = !sidebar.IsActive;
        }

        private void SectionButton_Click(object sender, RoutedEventArgs e)
        {
            SectionLbl.Content = (sender as Button).Content;
        }
    }
}
