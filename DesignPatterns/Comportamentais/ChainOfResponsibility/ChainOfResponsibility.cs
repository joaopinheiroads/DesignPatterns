// CHAIN OF RESPONSIBILITY: passa o pedido por uma corrente até alguém tratar.

abstract class Aprovador                               // elo da corrente
{
    protected Aprovador _proximo;                      // referência ao próximo elo
    public Aprovador Encadear(Aprovador prox) { _proximo = prox; return prox; } // monta a corrente

    public abstract void Aprovar(int valor);          // cada elo decide tratar ou repassar
}

class Gerente : Aprovador
{
    public override void Aprovar(int valor)
    {
        if (valor <= 100) System.Console.WriteLine("Gerente aprovou"); // trata se for da sua alçada
        else _proximo?.Aprovar(valor);                                 // senão repassa adiante
    }
}
class Diretor : Aprovador
{
    public override void Aprovar(int valor)
    {
        if (valor <= 1000) System.Console.WriteLine("Diretor aprovou");
        else _proximo?.Aprovar(valor);
    }
}

class Program
{
    static void Main()
    {
        var gerente = new Gerente();
        gerente.Encadear(new Diretor());              // gerente -> diretor
        gerente.Aprovar(500);                          // gerente não trata, diretor aprova
    }
}
