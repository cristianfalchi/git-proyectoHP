using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesoreria.Modelo.Clases
{
    public class EfectivoModelo
    {
        private DateTime hora;
        private short b1000;

        private short b500;
        private short b200;
        private short b100;
        private short b50;
        private short b20;
        private short b10;
        private short m10;

        private short m5;
        private short m2;
        private short m1;
        private short m050;
        private short m025;
        private short m010;
        private double totalEfectivo;

        public EfectivoModelo()
        {
            this.b1000 = 0;
            this.b500 = 0;
            this.b200 = 0;
            this.b100 = 0;
            this.b50 = 0;
            this.b20 = 0;
            this.b10 = 0;

            this.m10 = 0;
            this.m5 = 0;
            this.m2 = 0;
            this.m1 = 0;
            this.m050 = 0;
            this.m025 = 0;
            this.m010 = 0;
            this.totalEfectivo = 0.00;
        }

        public EfectivoModelo(short bmil, short bquinientos, short bdoscientos, short bcien, short bcincuenta, short bveinte, short bdiez, short mdiez, short mcinco, short mdos, short muno, short mcerocincuenta, short mceroveinticinco, short mcerodiez)
        {
            this.b1000 = bmil;
            this.b500 = bquinientos;
            this.b200 = bdoscientos;
            this.b100 = bcien;
            this.b50 = bcincuenta;
            this.b20 = bveinte;
            this.b10 = bdiez;

            this.m10 = mdiez;
            this.m5 = mcinco;
            this.m2 = mdos;
            this.m1 = muno;
            this.m050 = mcerocincuenta;
            this.m025 = mceroveinticinco;
            this.m010 = mcerodiez;
            this.totalEfectivo = b1000*1000+ b500 * 500 + b200 * 200 + b100 * 100 + b50 * 50 + b20 * 20 + b10 * 10 + m10 * 10 + m5 * 5 + m2 * 2 + m1 * 1 + m050 * 0.50 + m025 * 0.25 + m010 * 0.10;

        }
    }
}
