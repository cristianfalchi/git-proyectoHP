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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        PrincipalController PrincipalController;
        public Login()
        {
            InitializeComponent();

        }

        public Login(PrincipalController p)
        {
            InitializeComponent();
            PrincipalController = p;

        }


    }
}
