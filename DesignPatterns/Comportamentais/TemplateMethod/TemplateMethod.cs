// TEMPLATE METHOD: a superclasse define o ESQUELETO; subclasses preenchem os passos.

abstract class Bebida
{
    public void Preparar()                             // TEMPLATE METHOD: fixa a sequência dos passos
    {
        Ferver();                                      // passo comum (igual para todos)
        Adicionar();                                   // passo variável (cada subclasse define)
        System.Console.WriteLine("servir");            // passo comum
    }

    private void Ferver() => System.Console.WriteLine("ferver agua"); // já implementado na base
    protected abstract void Adicionar();              // "buraco" que a subclasse obrigatoriamente preenche
}

class Cha   : Bebida { protected override void Adicionar() => System.Console.WriteLine("por cha");   } // passo A
class Cafe  : Bebida { protected override void Adicionar() => System.Console.WriteLine("por po de cafe"); } // passo B

class Program
{
    static void Main()
    {
        new Cha().Preparar();                          // mesma estrutura, só o passo "Adicionar" muda
    }
}
