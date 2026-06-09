// SINGLETON: garante UMA única instância da classe em todo o app.

public sealed class Config                       // sealed: impede herança (proteção da instância única)
{
    private static readonly Config _instancia = new Config(); // a única instância, criada uma vez
    public string Valor = "padrao";              // algum estado compartilhado

    private Config() { }                          // construtor PRIVADO: ninguém cria de fora com "new"

    public static Config Instancia => _instancia; // único ponto de acesso global à instância
}

class Program
{
    static void Main()
    {
        Config.Instancia.Valor = "alterado";      // pega a instância e altera o estado
        System.Console.WriteLine(Config.Instancia.Valor); // mesma instância -> imprime "alterado"
    }
}
