using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tesoreria.DAO
{
    public class ConexionDB
    {
        protected String cadConexion = ConfigurationManager.ConnectionStrings["Tesoreria.Properties.Settings.TesoreriaConnectionString1"].ConnectionString;
        
        //protected DataClasses1DataContext dataContext;    
    }
}
