// VISITOR: adiciona novas operações a uma hierarquia sem alterar suas classes.

interface IVisitante { int Visitar(Livro l); int Visitar(Fruta f); } // operações para cada tipo

interface IItem { int Aceitar(IVisitante v); }       // elemento aceita um visitante

class Livro : IItem                                    // elemento concreto A
{
    public int Preco = 50;
    public int Aceitar(IVisitante v) => v.Visitar(this); // "double dispatch": chama a sobrecarga certa
}
class Fruta : IItem                                    // elemento concreto B
{
    public int Peso = 4;
    public int Aceitar(IVisitante v) => v.Visitar(this);
}

class VisitanteImposto : IVisitante                    // nova operação criada SEM mexer em Livro/Fruta
{
    public int Visitar(Livro l) => l.Preco / 10;      // regra específica para livro
    public int Visitar(Fruta f) => f.Peso * 2;        // regra específica para fruta
}

class Program
{
    static void Main()
    {
        IItem item = new Livro();
        System.Console.WriteLine(item.Aceitar(new VisitanteImposto())); // 5
    }
}
