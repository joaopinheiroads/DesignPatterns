// BUILDER: monta um objeto complexo passo a passo (evita construtor gigante).

class Pizza                                          // o produto final
{
    public string Massa = "", Recheio = "";         // partes a configurar
    public override string ToString() => $"Pizza {Massa} com {Recheio}";
}

class PizzaBuilder                                    // o construtor
{
    private Pizza _p = new Pizza();                   // objeto sendo montado

    public PizzaBuilder ComMassa(string m)   { _p.Massa = m; return this; }   // configura parte e retorna "this"...
    public PizzaBuilder ComRecheio(string r) { _p.Recheio = r; return this; } // ...para encadear chamadas (fluent)
    public Pizza Build() => _p;                        // entrega o objeto pronto
}

class Program
{
    static void Main()
    {
        var pizza = new PizzaBuilder()                // monta em etapas, na ordem que quiser
            .ComMassa("fina")
            .ComRecheio("queijo")
            .Build();
        System.Console.WriteLine(pizza);              // "Pizza fina com queijo"
    }
}
