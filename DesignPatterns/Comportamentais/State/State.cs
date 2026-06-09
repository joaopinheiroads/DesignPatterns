// STATE: o objeto muda de comportamento conforme seu estado interno (sem ifs gigantes).

interface IEstado { IEstado Apertar(); }             // cada estado sabe para qual transitar

class Ligado : IEstado                                 // estado concreto A
{
    public IEstado Apertar()
    {
        System.Console.WriteLine("desligando...");
        return new Desligado();                        // define a próxima transição
    }
}
class Desligado : IEstado                               // estado concreto B
{
    public IEstado Apertar()
    {
        System.Console.WriteLine("ligando...");
        return new Ligado();
    }
}

class Aparelho                                          // contexto: delega o comportamento ao estado atual
{
    private IEstado _estado = new Desligado();         // estado inicial
    public void Apertar() => _estado = _estado.Apertar(); // o estado decide o que fazer e troca a si mesmo
}

class Program
{
    static void Main()
    {
        var tv = new Aparelho();
        tv.Apertar();                                  // "ligando..."
        tv.Apertar();                                  // "desligando..." (mesmo método, comportamento diferente)
    }
}
