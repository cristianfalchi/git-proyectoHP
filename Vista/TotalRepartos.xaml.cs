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
using System.Windows.Threading;

namespace Tesoreria
{
    /// <summary>
    /// Lógica de interacción para TotalRepartos.xaml
    /// </summary>
    public partial class TotalRepartos : Window
    {
        public TotalRepartos()
        {
            InitializeComponent();
            DispatcherTimer hora = new DispatcherTimer();
            hora.Interval = TimeSpan.FromSeconds(1);
            hora.Tick += timer_Tick;
            hora.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            HorayFecha.Content = DateTime.Now.ToLongTimeString();

        }
    }
}
