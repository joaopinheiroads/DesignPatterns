// COMMAND: transforma uma ação em objeto (permite enfileirar, desfazer, etc).

interface IComando { void Executar(); }              // a interface do comando

class Luz { public void Acender() => System.Console.WriteLine("luz acesa"); } // receptor (quem faz o trabalho)

class ComandoAcender : IComando                        // comando concreto: encapsula ação + receptor
{
    private Luz _luz;
    public ComandoAcender(Luz luz) => _luz = luz;     // guarda quem vai receber a ação
    public void Executar() => _luz.Acender();         // o "o que fazer" vira um objeto
}

class Controle                                         // invocador: dispara comandos sem saber o que fazem
{
    private IComando _comando;
    public void Configurar(IComando c) => _comando = c;
    public void Apertar() => _comando.Executar();     // só chama Executar, desacoplado do receptor
}

class Program
{
    static void Main()
    {
        var controle = new Controle();
        controle.Configurar(new ComandoAcender(new Luz())); // injeta o comando
        controle.Apertar();                            // "luz acesa"
    }
}
