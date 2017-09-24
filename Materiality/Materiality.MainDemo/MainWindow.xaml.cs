using Materiality.WPF.Layouts;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Materiality.MainDemo
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;
            demoGrid.SizeChanged += DemoGrid_SizeChanged;
        }

        private void DemoGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (demoGrid.ActualWidth > 1200) //Extra Large
            {
                this.Title = "Extra Large";
            }
            else if (demoGrid.ActualWidth > 992) //Large
            {
                this.Title = "Large";
            }
            else if (demoGrid.ActualWidth > 600) //Medium
            {
                this.Title = "Medium";
            }
            else if (demoGrid.ActualWidth <= 600)  //Small
            {
                this.Title = "Small";
              
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //Debug.WriteLine("BTN1");
            //Debug.WriteLine("COLUMN " + Grid.GetColumn(btn1));
            //Debug.WriteLine("COLUMNSPAN " +Grid.GetColumnSpan(btn1));
            //Debug.WriteLine("ROW " + Grid.GetRow(btn1));
            //Debug.WriteLine("ROWSPAN " + Grid.GetRowSpan(btn1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Opens Hardcoded Window
            MainWindow copy = new MainWindow();
            copy.Show();
        }
    }
}
