// ABSTRACT FACTORY: cria FAMÍLIAS de objetos relacionados sem citar classes concretas.

interface IBotao  { string Render(); }            // produto 1 da família
interface ICheck  { string Render(); }            // produto 2 da família

class BotaoWin : IBotao { public string Render() => "[botao Windows]"; } // variante Windows
class CheckWin : ICheck { public string Render() => "[check Windows]"; }
class BotaoMac : IBotao { public string Render() => "(botao Mac)"; }     // variante Mac
class CheckMac : ICheck { public string Render() => "(check Mac)"; }

interface IUIFactory                               // a fábrica abstrata: cria a família inteira
{
    IBotao CriarBotao();
    ICheck CriarCheck();
}

class WinFactory : IUIFactory                       // fábrica concreta -> só produtos Windows
{
    public IBotao CriarBotao() => new BotaoWin();
    public ICheck CriarCheck() => new CheckWin();
}
class MacFactory : IUIFactory                        // fábrica concreta -> só produtos Mac
{
    public IBotao CriarBotao() => new BotaoMac();
    public ICheck CriarCheck() => new CheckMac();
}

class Program
{
    static void Main()
    {
        IUIFactory f = new MacFactory();            // troca aqui = troca a família toda
        System.Console.WriteLine(f.CriarBotao().Render() + f.CriarCheck().Render()); // produtos combinam entre si
    }
}
