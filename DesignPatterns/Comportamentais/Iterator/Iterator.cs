// ITERATOR: percorre os elementos de uma coleção sem expor sua estrutura interna.

using System.Collections;
using System.Collections.Generic;

class Pilha : IEnumerable<int>                         // coleção que sabe ser percorrida
{
    private List<int> _itens = new() { 1, 2, 3 };     // estrutura interna (escondida do cliente)

    public IEnumerator<int> GetEnumerator()           // ITERATOR: fornece o "percorredor"
    {
        for (int i = _itens.Count - 1; i >= 0; i--)   // define a ORDEM (aqui: de trás pra frente)
            yield return _itens[i];                    // entrega um item por vez, mantendo a posição
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); // versão não-genérica exigida
}

class Program
{
    static void Main()
    {
        foreach (var x in new Pilha())                // foreach usa o iterator sem saber que é uma List
            System.Console.Write(x);                   // 321
    }
}
