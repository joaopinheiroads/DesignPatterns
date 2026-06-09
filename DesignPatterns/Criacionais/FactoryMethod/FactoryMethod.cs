// FACTORY METHOD: subclasses decidem QUAL objeto criar (esconde o "new").

interface ITransporte { string Entregar(); }    // produto que será criado

class Caminhao : ITransporte { public string Entregar() => "entrega por terra"; } // produto concreto A
class Navio    : ITransporte { public string Entregar() => "entrega por mar";   } // produto concreto B

abstract class Logistica                          // o "criador"
{
    public abstract ITransporte CriarTransporte();// FACTORY METHOD: cada subclasse define o que criar

    public string Planejar() => CriarTransporte().Entregar(); // usa o produto sem saber a classe concreta
}

class LogisticaTerrestre : Logistica { public override ITransporte CriarTransporte() => new Caminhao(); } // cria Caminhao
class LogisticaMaritima  : Logistica { public override ITransporte CriarTransporte() => new Navio();    } // cria Navio

class Program
{
    static void Main()
    {
        Logistica log = new LogisticaMaritima();  // escolhe a fábrica concreta
        System.Console.WriteLine(log.Planejar()); // "entrega por mar"
    }
}
