using System.Linq.Expressions;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
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

                //Operaciones para probar funcionalidad
                Console.WriteLine("=== Operaciones con Caja de Ahorro 1 ===");
                EjecutarOperacionSegura(() => cajaAhorro1.Depositar(300m)); // Depósito exitoso
                EjecutarOperacionSegura(() => cajaAhorro1.Retirar(200m));   // Retiro exitoso
                EjecutarOperacionSegura(() => cajaAhorro1.AplicarInteres()); // Aplica interés
                EjecutarOperacionSegura(() => cajaAhorro1.Retirar(2000m));  // Saldo insuficiente (debe fallar)

                Console.WriteLine("\n=== Operaciones con Caja de Ahorro 2 ===");
                EjecutarOperacionSegura(() => cajaAhorro2.Depositar(-100m)); // Monto inválido (debe fallar)
                cajaAhorro2.Estado = Estado.Suspendida;
                EjecutarOperacionSegura(() => cajaAhorro2.Depositar(200m)); // Cuenta inactiva (debe fallar)

                Console.WriteLine("\n=== Operaciones con Cuenta Corriente 1 ===");
                EjecutarOperacionSegura(() => cuentaCorriente1.Depositar(500m)); // Depósito con comisión
                EjecutarOperacionSegura(() => cuentaCorriente1.Retirar(3500m)); // Retiro dentro del límite
                EjecutarOperacionSegura(() => cuentaCorriente1.Retirar(1000m)); // Supera límite (debe fallar y suspender)

                Console.WriteLine("\n=== Operaciones con Cuenta Corriente 2 ===");
                cuentaCorriente2.Estado = Estado.Suspendida;
                EjecutarOperacionSegura(() => cuentaCorriente2.Depositar(100m)); // Cuenta suspendida (debe fallar)
                cuentaCorriente2.Estado = Estado.Activa;
                EjecutarOperacionSegura(() => cuentaCorriente2.Retirar(2400m)); // Retiro exitoso con descubierto

                // Mostrar el saldo final de cada cuenta
                Console.WriteLine("\n=== Resumen Final de Cuentas ===");
                var resumenCuentas = cuentas.Select(c => new {
                    Número = c.Numero,
                    Tipo = c.Tipo.ToString(),
                    Saldo = c.Saldo.ToString(""),
                    Estado = c.Estado.ToString(),
                    Titulares = string.Join(", ", c.Titulares)
                }).ToList();

                foreach (var cuenta in resumenCuentas)
                {
                    Console.WriteLine($"Número: {cuenta.Número}");
                    Console.WriteLine($"Tipo: {cuenta.Tipo}");
                    Console.WriteLine($"Saldo: {cuenta.Saldo}");
                    Console.WriteLine($"Estado: {cuenta.Estado}");
                    Console.WriteLine($"Titulares: {cuenta.Titulares}");
                    Console.WriteLine(new string('-', 30));
                }

            }
            catch (Exception ex) {
                Console.WriteLine($"Error Inesperado:{ex.Message}");
            }
        }
        static void EjecutarOperacionSegura(Action operacion)
        {
            try
            {
                operacion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en operación: {ex.Message}");
            }
        }
    }
}
