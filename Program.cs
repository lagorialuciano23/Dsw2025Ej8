using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Crear una lista de cuentas bancarias
            var cuentas = new List<CuentaBancaria>();

            //Instancio 2 Cuentas de cada tipo

            //Crear caja de ahorro 1
            var cajaAhorro1 = new CajaDeAhorro("CA:001", 1000m, new[] { "Pedro Gonzalez" });
            cajaAhorro1.TasaInteres = 0.05m; // 5% de interés despues de crear la cuenta
            cuentas.Add(cajaAhorro1);

            //Crear caja de ahorro 2
            var cajaAhorro2 = new CajaDeAhorro("CA:002", 500m, new[] { "Carlos Santana", "Maria Modric" });
            cajaAhorro2.TasaInteres = 0.03m; // 3% de interés
            cuentas.Add(cajaAhorro2);

            //Crear cuenta corriente 1
            var cuentaCorriente1 = new CuentaCorriente("CC:001", 3000m, new[] { "Empresas Wayne Argentina" });
            cuentaCorriente1.LimiteDescubierto = 1000m;
            cuentaCorriente1.Comision = 0.01m; // 1% de comision
            cuentas.Add(cuentaCorriente1);

            //Crear cuenta corriente 2
            var cuentaCorriente2 = new CuentaCorriente("CC:002", 2000m, new[] { "Ashley Graham" });
            cuentaCorriente2.LimiteDescubierto = 500m;
            cuentaCorriente2.Comision = 0.02m; // 2% de comision
            cuentas.Add(cuentaCorriente2);
        }
    }
}
