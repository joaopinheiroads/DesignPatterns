// FLYWEIGHT: compartilha objetos iguais para economizar memória.

using System.Collections.Generic;

class Arvore                                           // estado INTRÍNSECO (compartilhável): repete muito
{
    public string Especie;
    public Arvore(string e) => Especie = e;
}

class FabricaArvores                                   // garante reutilização dos flyweights
{
    private static Dictionary<string, Arvore> _cache = new(); // pool de objetos já criados

    public static Arvore Obter(string especie)
    {
        if (!_cache.ContainsKey(especie))             // só cria se ainda não existe...
            _cache[especie] = new Arvore(especie);
        return _cache[especie];                        // ...senão devolve o já existente (mesma instância)
    }
}

class Program
{
    static void Main()
    {
        var a = FabricaArvores.Obter("pinheiro");      // estado extrínseco (x,y) ficaria fora, por árvore
        var b = FabricaArvores.Obter("pinheiro");
        System.Console.WriteLine(ReferenceEquals(a, b)); // True: mesma instância reutilizada
    }
}
