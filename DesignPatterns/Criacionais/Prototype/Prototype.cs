// PROTOTYPE: cria novos objetos CLONANDO um existente (em vez de construir do zero).

class Documento                                       // objeto que será clonado
{
    public string Titulo = "", Conteudo = "";

    public Documento Clonar() => (Documento)this.MemberwiseClone(); // cópia rasa de todos os campos
}

class Program
{
    static void Main()
    {
        var original = new Documento { Titulo = "Modelo", Conteudo = "..." }; // protótipo base
        var copia = original.Clonar();                 // clona em vez de "new" + reconfigurar tudo
        copia.Titulo = "Copia";                        // ajusta só o que muda

        System.Console.WriteLine($"{original.Titulo} / {copia.Titulo}"); // "Modelo / Copia" (independentes)
    }
}
