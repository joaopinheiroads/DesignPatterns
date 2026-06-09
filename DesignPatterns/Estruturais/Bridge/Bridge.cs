// BRIDGE: separa a abstração da implementação para variarem independentes.

interface ICor { string Pintar(); }                  // a IMPLEMENTAÇÃO (um eixo que varia)
class Vermelho : ICor { public string Pintar() => "vermelho"; }
class Azul     : ICor { public string Pintar() => "azul"; }

abstract class Forma                                  // a ABSTRAÇÃO (outro eixo que varia)
{
    protected ICor _cor;                             // a "ponte": referência para a implementação
    protected Forma(ICor cor) => _cor = cor;
    public abstract string Desenhar();
}

class Circulo : Forma                                 // refina a abstração sem conhecer a cor concreta
{
    public Circulo(ICor cor) : base(cor) { }
    public override string Desenhar() => $"circulo {_cor.Pintar()}"; // combina os dois eixos
}

class Program
{
    static void Main()
    {
        Forma f = new Circulo(new Azul());           // combine forma x cor livremente
        System.Console.WriteLine(f.Desenhar());      // "circulo azul"
    }
}
