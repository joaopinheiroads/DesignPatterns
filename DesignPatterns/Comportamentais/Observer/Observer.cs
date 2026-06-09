// OBSERVER: quando um objeto muda, todos os interessados são avisados automaticamente.

using System.Collections.Generic;

interface IObservador { void Atualizar(string noticia); } // quem quer ser notificado

class Jornal                                           // o "sujeito" observado
{
    private List<IObservador> _inscritos = new();     // lista de observadores

    public void Inscrever(IObservador o) => _inscritos.Add(o); // observador se registra
    public void Publicar(string noticia)
    {
        foreach (var o in _inscritos)                 // ao mudar, notifica TODOS os inscritos
            o.Atualizar(noticia);
    }
}

class Leitor : IObservador                              // observador concreto
{
    public string Nome;
    public Leitor(string nome) => Nome = nome;
    public void Atualizar(string noticia) => System.Console.WriteLine($"{Nome}: {noticia}"); // reage
}

class Program
{
    static void Main()
    {
        var jornal = new Jornal();
        jornal.Inscrever(new Leitor("Ana"));          // Ana passa a observar
        jornal.Publicar("ediçao nova");               // Ana é avisada automaticamente
    }
}
