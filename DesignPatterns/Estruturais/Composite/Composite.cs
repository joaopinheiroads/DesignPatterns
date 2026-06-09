// COMPOSITE: trata objetos individuais e grupos da MESMA forma (árvore).

using System.Collections.Generic;
using System.Linq;

interface IItem { int Preco(); }                      // componente comum (folha e grupo implementam)

class Produto : IItem                                  // FOLHA: item individual
{
    private int _preco;
    public Produto(int preco) => _preco = preco;
    public int Preco() => _preco;                     // folha retorna o próprio valor
}

class Caixa : IItem                                    // COMPOSITE: contém outros itens (folhas ou caixas)
{
    private List<IItem> _itens = new List<IItem>();
    public void Add(IItem i) => _itens.Add(i);        // adiciona filhos
    public int Preco() => _itens.Sum(i => i.Preco()); // soma recursiva: trata cada filho igual
}

class Program
{
    static void Main()
    {
        var caixa = new Caixa();                      // grupo
        caixa.Add(new Produto(10));                   // folha dentro do grupo
        var sub = new Caixa(); sub.Add(new Produto(5));// grupo dentro de grupo (recursão)
        caixa.Add(sub);

        System.Console.WriteLine(caixa.Preco());      // 15: mesma chamada em folha e grupo
    }
}
