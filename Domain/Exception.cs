using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class MontoNoValidoException : Exception
{
    //Constructor que recibe un mensaje personalizado
    public MontoNoValidoException() : base("El monto ingresado no es válido para la operación solicitada") { }
}

public class CuentaNoActivaException : Exception
{
    public CuentaNoActivaException(Estado estado)
        : base($"No se puede operar con la cuenta {estado}") { }
}

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException()
        : base("La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida.") { }
}
