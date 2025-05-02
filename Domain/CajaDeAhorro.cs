using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dsw2025Ej8.Domain
{
    //Hago herencia de la clase CuentaBancaria
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal TasaInteres { get; set; }
        public override TipoCuenta Tipo => TipoCuenta.CajaDeAhorro;

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, titulares) { }

       

        public override void AplicarInteres()
        {
            //Valido si la cuenta esta activa
            if (Estado != Estado.Activa) return;
            //Aplico el interes sobre el saldo actual
            Saldo += Saldo * TasaInteres;
        }
    }
}
