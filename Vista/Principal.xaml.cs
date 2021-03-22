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
using Tesoreria.Controlador;

namespace Tesoreria
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public PrincipalController controller { set; get; }
        public Principal()
        {
            InitializeComponent();

            PrincipalController ctrl = new PrincipalController(this);
            controller = ctrl;
            

        }

        









    }
}
