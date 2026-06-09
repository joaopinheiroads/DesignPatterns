// STRATEGY: troca o algoritmo em tempo de execução (várias formas de fazer a mesma coisa).

interface IFrete { int Calcular(int km); }           // a "estratégia" (família de algoritmos)

class FreteNormal  : IFrete { public int Calcular(int km) => km * 1; } // algoritmo A
class FreteExpresso: IFrete { public int Calcular(int km) => km * 3; } // algoritmo B

class Pedido                                           // contexto: usa uma estratégia sem conhecer o cálculo
{
    private IFrete _frete;
    public Pedido(IFrete frete) => _frete = frete;    // recebe a estratégia escolhida
    public void TrocarFrete(IFrete f) => _frete = f;  // pode trocar em runtime
    public int Total(int km) => _frete.Calcular(km);  // delega o cálculo à estratégia atual
}

class Program
{
    static void Main()
    {
        var pedido = new Pedido(new FreteNormal());   // escolhe um algoritmo
        System.Console.WriteLine(pedido.Total(10));   // 10
        pedido.TrocarFrete(new FreteExpresso());      // troca a estratégia
        System.Console.WriteLine(pedido.Total(10));   // 30
    }
}
