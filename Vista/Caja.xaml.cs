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
using System.Windows.Shapes;

namespace Tesoreria
{
    /// <summary>
    /// Lógica de interacción para Caja.xaml
    /// </summary>
    public partial class Caja : Window
    {
        public Caja()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NuevoIngreso ingreso = new NuevoIngreso();
            ingreso.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TotalIngresosEgresos tIngEgr = new TotalIngresosEgresos();
            tIngEgr.Show();
        }
    }
}
    
