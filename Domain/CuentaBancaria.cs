namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    //Aqui van las propiedades que reemplazan getters y setters
    public string Numero { get; } //solo lectura
    public decimal Saldo { get; protected set; } //protected para que solo la clase y sus herederas puedan modificarlo
    public Estado Estado { get;  set; }
    public string[] Titulares { get; }
    public abstract TipoCuenta Tipo { get; } //abstract para que las clases hijas lo implementen

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
    
    //Metodo para comprobar si al cuenta sigue activa

    protected void ValidarOperacion(decimal monto)
    {
        if(monto <=0)
        {
            throw new MontoNoValidoException();
        }
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActivaException(Estado);
        }
    }

    public virtual void Depositar(decimal monto)
    {
        ValidarOperacion(monto);
        Saldo = Saldo + monto;
    }

    public virtual void Retirar(decimal monto)
    {
        ValidarOperacion(monto);
        if(Saldo < monto)
        {
            throw new SaldoInsuficienteException();
        }
        Saldo = Saldo - monto;
    }
    //Virtual permite que las clases hijas sobrescriban el comportamiento
    public virtual void AplicarInteres() { }
}
