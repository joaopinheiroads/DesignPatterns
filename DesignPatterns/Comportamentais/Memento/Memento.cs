// MEMENTO: salva e restaura o estado de um objeto (undo) sem expor seus detalhes.

class Memento                                          // a "foto" do estado
{
    public string Estado { get; }                     // estado guardado (somente leitura)
    public Memento(string estado) => Estado = estado;
}

class Editor                                           // originador: cria e restaura mementos
{
    public string Texto = "";

    public Memento Salvar() => new Memento(Texto);    // captura o estado atual num memento
    public void Restaurar(Memento m) => Texto = m.Estado; // volta a um estado salvo
}

class Program
{
    static void Main()
    {
        var editor = new Editor();
        editor.Texto = "v1";
        var backup = editor.Salvar();                 // guarda o ponto de restauração

        editor.Texto = "v2";                          // muda...
        editor.Restaurar(backup);                     // ...e desfaz voltando para "v1"
        System.Console.WriteLine(editor.Texto);       // "v1"
    }
}
