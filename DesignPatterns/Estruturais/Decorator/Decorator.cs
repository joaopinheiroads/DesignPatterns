// DECORATOR: adiciona comportamento a um objeto "embrulhando-o" em camadas.

interface ICafe { int Preco(); string Nome(); }     // componente base

class CafeSimples : ICafe                              // objeto concreto a ser decorado
{
    public int Preco() => 5;
    public string Nome() => "cafe";
}

abstract class Adicional : ICafe                       // DECORATOR base: também é um ICafe e contém um ICafe
{
    protected ICafe _cafe;                            // o objeto embrulhado
    protected Adicional(ICafe c) => _cafe = c;
    public abstract int Preco();
    public abstract string Nome();
}

class ComLeite : Adicional                             // decorator concreto: soma sua parte ao embrulhado
{
    public ComLeite(ICafe c) : base(c) { }
    public override int Preco() => _cafe.Preco() + 2;        // delega e ADICIONA
    public override string Nome() => _cafe.Nome() + "+leite";
}

class Program
{
    static void Main()
    {
        ICafe pedido = new ComLeite(new CafeSimples()); // empilha camadas em volta do base
        System.Console.WriteLine($"{pedido.Nome()} = {pedido.Preco()}"); // "cafe+leite = 7"
    }
}
