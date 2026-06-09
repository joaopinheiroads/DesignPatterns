// MEDIATOR: objetos não se falam direto; conversam por um intermediário central.

interface IMediator { void Enviar(string msg, Usuario de); } // o intermediário

class Usuario                                          // colega: só conhece o mediator, não os outros
{
    public string Nome;
    private IMediator _mediator;
    public Usuario(string nome, IMediator m) { Nome = nome; _mediator = m; }

    public void Enviar(string msg) => _mediator.Enviar(msg, this); // manda pelo mediator, não direto
    public void Receber(string msg) => System.Console.WriteLine($"{Nome} recebeu: {msg}");
}

class Chat : IMediator                                  // mediator concreto: conhece todos e distribui
{
    public System.Collections.Generic.List<Usuario> Usuarios = new();

    public void Enviar(string msg, Usuario de)
    {
        foreach (var u in Usuarios)                    // centraliza a lógica de comunicação
            if (u != de) u.Receber(msg);               // entrega a todos menos a quem enviou
    }
}

class Program
{
    static void Main()
    {
        var chat = new Chat();
        var ana = new Usuario("Ana", chat);
        var bob = new Usuario("Bob", chat);
        chat.Usuarios.Add(ana); chat.Usuarios.Add(bob); // registra os colegas no mediator
        ana.Enviar("oi");                              // "Bob recebeu: oi"
    }
}
