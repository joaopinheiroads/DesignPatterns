// INTERPRETER: define uma "gramática" e interpreta expressões dela (cada regra = uma classe).

interface IExpr { int Interpretar(); }               // a expressão abstrata

class Numero : IExpr                                   // expressão TERMINAL (folha): um valor
{
    private int _valor;
    public Numero(int v) => _valor = v;
    public int Interpretar() => _valor;               // valor literal se interpreta como ele mesmo
}

class Soma : IExpr                                     // expressão NÃO-terminal: combina outras expressões
{
    private IExpr _a, _b;
    public Soma(IExpr a, IExpr b) { _a = a; _b = b; }
    public int Interpretar() => _a.Interpretar() + _b.Interpretar(); // interpreta recursivamente os filhos
}

class Program
{
    static void Main()
    {
        IExpr expr = new Soma(new Numero(3), new Numero(4)); // monta a árvore "3 + 4"
        System.Console.WriteLine(expr.Interpretar()); // 7
    }
}
