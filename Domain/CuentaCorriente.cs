using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDescubierto { get; set; }
        public decimal Comision { get; set; }
        public override TipoCuenta Tipo => TipoCuenta.CuentaCorriente;

        public CuentaCorriente(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, titulares) { }

        public override void Depositar(decimal monto)
        {
            base.Depositar(monto);
            Saldo -= monto * Comision;
        }
        public override void Retirar(decimal monto)
        {
            ValidarOperacion(monto);
            if (Saldo - monto < -LimiteDescubierto)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
            }
            Saldo -= monto;
            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;
            }
        }
    }
}

