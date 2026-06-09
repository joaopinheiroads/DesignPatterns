// ADAPTER: faz uma interface incompatível "encaixar" na que o cliente espera.

interface ITomada220 { string Ligar(); }            // interface que o cliente espera usar

class Aparelho110                                     // classe existente, incompatível (interface diferente)
{
    public string Ligar110() => "ligado em 110v";
}

class Adaptador : ITomada220                          // o ADAPTER: implementa a interface esperada
{
    private Aparelho110 _aparelho;                    // guarda o objeto incompatível (adaptado)
    public Adaptador(Aparelho110 a) => _aparelho = a;

    public string Ligar() => _aparelho.Ligar110();   // traduz a chamada esperada para a real
}

class Program
{
    static void Main()
    {
        ITomada220 tomada = new Adaptador(new Aparelho110()); // cliente usa via interface comum
        System.Console.WriteLine(tomada.Ligar());    // "ligado em 110v"
    }
}
