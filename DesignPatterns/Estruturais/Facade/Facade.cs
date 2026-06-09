// FACADE: oferece uma interface simples para um subsistema complexo.

class CPU    { public string Carregar() => "CPU ok"; }      // subsistemas complicados/separados
class Disco  { public string Ler()      => "disco ok"; }
class Memoria{ public string Limpar()   => "memoria ok"; }

class Computador                                       // a FACHADA: esconde a complexidade
{
    private CPU _cpu = new CPU();                      // cria/coordena os subsistemas internamente
    private Disco _disco = new Disco();
    private Memoria _mem = new Memoria();

    public string Ligar()                              // um método simples faz o trabalho todo
        => $"{_mem.Limpar()}, {_cpu.Carregar()}, {_disco.Ler()}";
}

class Program
{
    static void Main()
    {
        var pc = new Computador();                     // cliente nem conhece CPU/Disco/Memoria
        System.Console.WriteLine(pc.Ligar());          // uma chamada, tudo coordenado
    }
}
