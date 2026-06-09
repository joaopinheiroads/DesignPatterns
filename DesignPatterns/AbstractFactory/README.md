Aplicabilidade
Use o Abstract Factory quando seu código precisa trabalhar
com diversas famílias de produtos relacionados, mas que você

não quer depender de classes concretas daqueles produtos-
eles podem ser desconhecidos de antemão ou você simples-
mente quer permitir uma futura escalabilidade.

74 this.button = factory.createButton()
75 method paint() is
76 button.paint()
77
78
79 // A aplicação seleciona o tipo de fábrica dependendo da atual
80 // configuração do ambiente e cria o widget no tempo de execução
81 // (geralmente no estágio de inicialização).
82 class ApplicationConfigurator is
83 method main() is
84 config = readApplicationConfigFile()
85
86 if (config.OS == "Windows") then
87 factory = new WinFactory()
88 else if (config.OS == "Mac") then
89 factory = new MacFactory()
90 else
91 throw new Exception("Error! Unknown operating system.")
92
93 Application app = new Application(factory)





O Abstract Factory fornece a você uma interface para a criação
de objetos de cada classe das famílias de produtos. Desde que

seu código crie objetos a partir dessa interface, você não preci-
sará se preocupar em criar uma variante errada de um produto

que não coincida com produtos já criados por sua aplicação.
• Considere implementar o Abstract Factory quando você tem

uma classe com um conjunto de métodos fábrica que desfo-
quem sua responsabilidade principal.

• Em um programa bem desenvolvido cada classe é responsável
por apenas uma coisa. Quando uma classe lida com múltiplos

tipos de produto, pode valer a pena extrair seus métodos fá-
brica em uma classe fábrica solitária ou uma implementação

plena do Abstract Factory.

Como implementar

1. Mapeie uma matriz de tipos de produtos distintos versus as va-
riantes desses produtos.

2. Declare interfaces de produto abstratas para todos os tipos de
produto. Então, faça todas as classes concretas de produtos
implementar essas interfaces.
3. Declare a interface da fábrica abstrata com um conjuntos de
métodos de criação para todos os produtos abstratos.



110 Padrões de projeto criacionais / Abstract Factory #49888



4. Implemente um conjunto de classes fábricas concretas, uma
para cada variante de produto.
5. Crie um código de inicialização da fábrica em algum lugar da

aplicação. Ele deve instanciar uma das classes fábrica concre-
tas, dependendo da configuração da aplicação ou do ambiente

atual. Passe esse objeto fábrica para todas as classes que cons-
troem produtos.

6. Escaneie o código e encontre todas as chamadas diretas para
construtores de produtos. Substitua-as por chamadas para o
método de criação apropriado no objeto fábrica.
Prós e contras
Você pode ter certeza que os produtos que você obtém de uma
fábrica são compatíveis entre si.

Você evita um vínculo forte entre produtos concretos e o có-
digo cliente.

Princípio de responsabilidade única. Você pode extrair o código
de criação do produto para um lugar, fazendo o código ser de
fácil manutenção.
Princípio aberto/fechado. Você pode introduzir novas variantes
de produtos sem quebrar o código cliente existente.
O código pode tornar-se mais complicado do que deveria ser,

uma vez que muitas novas interfaces e classes são introduzi-
das junto com o padrão.











111 Padrões de projeto criacionais / Abstract Factory #49888



Relações com outros padrões
• Muitos projetos começam usando o Factory Method (menos

complicado e mais customizável através de subclasses) e evo-
luem para o Abstract Factory, Prototype, ou Builder (mais fle-
xíveis, mas mais complicados).

• O Builder foca em construir objetos complexos passo a passo.
O Abstract Factory se especializa em criar famílias de objetos

relacionados. O Abstract Factory retorna o produto imediata-
mente, enquanto que o Builder permite que você execute algu-
mas etapas de construção antes de buscar o produto.

• Classes Abstract Factory são quase sempre baseadas em um
conjunto de métodos fábrica, mas você também pode usar o
Prototype para compor métodos dessas classes.
• O Abstract Factory pode servir como uma alternativa para o

Facade quando você precisa apenas esconder do código cli-
ente a forma com que são criados os objetos do subsistema.

• Você pode usar o Abstract Factory junto com o Bridge. Esse
pareamento é útil quando algumas abstrações definidas pelo
Bridge só podem trabalhar com implementações específicas.
Neste caso, o Abstract Factory pode encapsular essas relações
e esconder a complexidade do código cliente.
• As Fábricas Abstratas, Construtores, e Protótipos podem todos
ser implementados como Singletons.



Abstract Factory usando C#
#C#
O Abstract Factory é um padrão de projeto que permite criar famílias de objetos relacionados sem precisar especificar suas classes concretas. Ao invés disso, o código utiliza uma interface ou classe abstrata para definir a assinatura dos métodos que criam esses objetos.

Por exemplo, imagine que você esteja criando um jogo que tenha diferentes tipos de inimigos em cada fase. Utilizando o Abstract Factory, você poderia criar uma fábrica abstrata que define métodos para criar diferentes tipos de inimigos. Em seguida, você poderia criar classes concretas que implementam essa fábrica abstrata, cada uma criando um conjunto diferente de inimigos.

Veja um exemplo em código:

// Abstract Factory

public interface IEnemyFactory

{

 IEnemy CreateEnemy();

}

// Concrete Factory 1

public class GoblinFactory : IEnemyFactory

{

 public IEnemy CreateEnemy()

 {

  return new Goblin();

 }

}

// Concrete Factory 2

public class OgreFactory : IEnemyFactory

{

 public IEnemy CreateEnemy()

 {

  return new Ogre();

 }

}

// Abstract Product

public interface IEnemy

{

 void Attack();

}

// Concrete Product 1

public class Goblin : IEnemy

{

 public void Attack()

 {

  Console.WriteLine("Goblin attacks with a club.");

 }

}

// Concrete Product 2

public class Ogre : IEnemy

{

 public void Attack()

 {

  Console.WriteLine("Ogre attacks with a giant club.");

 }

}

// Client

public class Game

{

 private IEnemyFactory _enemyFactory;

 public Game(IEnemyFactory enemyFactory)

 {

  _enemyFactory = enemyFactory;

 }

 public void Start()

 {

  IEnemy enemy = _enemyFactory.CreateEnemy();

  enemy.Attack();

 }

}

// Usage

Game game1 = new Game(new GoblinFactory());

game1.Start(); // output: "Goblin attacks with a club."

Game game2 = new Game(new OgreFactory());

game2.Start(); // output: "Ogre attacks with a giant club."

Nesse exemplo, o Abstract Factory é representado pela interface IEnemyFactory, que define o método CreateEnemy() para criar diferentes tipos de inimigos. As classes concretas GoblinFactory e OgreFactory implementam essa interface, cada uma criando um tipo diferente de inimigo.

A classe Game representa o cliente do padrão, que utiliza a fábrica abstrata para criar diferentes tipos de inimigos. Ao criar uma instância da classe Game com uma fábrica específica, o jogo pode criar inimigos de acordo com a fase atual.

O padrão Abstract Factory permite que o código seja facilmente adaptado a diferentes conjuntos de objetos relacionados sem precisar alterar o código existente. Ele também ajuda a garantir que os objetos criados sejam compatíveis e funcionem bem juntos.
