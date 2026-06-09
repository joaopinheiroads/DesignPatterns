// PROXY: um substituto controla o acesso ao objeto real (cache, lazy, segurança).

interface IImagem { string Mostrar(); }              // interface comum (real e proxy)

class ImagemReal : IImagem                             // objeto "caro" de criar
{
    public ImagemReal() => System.Console.WriteLine("carregando do disco..."); // custo no construtor
    public string Mostrar() => "imagem";
}

class ProxyImagem : IImagem                            // o PROXY: mesma interface do real
{
    private ImagemReal _real;                          // referência ao real (criada só quando precisar)

    public string Mostrar()
    {
        _real ??= new ImagemReal();                   // LAZY: só cria o real no primeiro uso
        return _real.Mostrar();                        // depois apenas delega
    }
}

class Program
{
    static void Main()
    {
        IImagem img = new ProxyImagem();               // nada carregado ainda
        System.Console.WriteLine(img.Mostrar());       // agora sim carrega e mostra
    }
}
