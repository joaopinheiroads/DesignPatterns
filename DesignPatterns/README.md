# Design Patterns em C# (GoF)

Cada pasta tem **um exemplo minimalista** com comentários linha a linha explicando a ideia do padrão.

## Criacionais — *como criar objetos*
| Pattern | Ideia em 1 linha |
|---|---|
| **Singleton** | Uma única instância global da classe. |
| **FactoryMethod** | Subclasses decidem qual objeto criar (esconde o `new`). |
| **AbstractFactory** | Cria famílias de objetos relacionados que combinam entre si. |
| **Builder** | Monta objeto complexo passo a passo (fluent). |
| **Prototype** | Cria novos objetos clonando um existente. |

## Estruturais — *como compor objetos*
| Pattern | Ideia em 1 linha |
|---|---|
| **Adapter** | Faz interface incompatível "encaixar" na esperada. |
| **Bridge** | Separa abstração da implementação (variam independentes). |
| **Composite** | Trata item individual e grupo da mesma forma (árvore). |
| **Decorator** | Adiciona comportamento embrulhando o objeto em camadas. |
| **Facade** | Interface simples para um subsistema complexo. |
| **Flyweight** | Compartilha objetos iguais para economizar memória. |
| **Proxy** | Substituto que controla acesso ao objeto real (lazy/cache). |

## Comportamentais — *como objetos interagem*
| Pattern | Ideia em 1 linha |
|---|---|
| **ChainOfResponsibility** | Passa o pedido por uma corrente até alguém tratar. |
| **Command** | Transforma uma ação em objeto (enfileirar/desfazer). |
| **Interpreter** | Define uma gramática e interpreta expressões dela. |
| **Iterator** | Percorre coleção sem expor sua estrutura interna. |
| **Mediator** | Objetos conversam por um intermediário central. |
| **Memento** | Salva/restaura estado (undo) sem expor detalhes. |
| **Observer** | Ao mudar, avisa automaticamente todos os interessados. |
| **State** | Muda de comportamento conforme o estado interno. |
| **Strategy** | Troca o algoritmo em tempo de execução. |
| **TemplateMethod** | Superclasse fixa o esqueleto; subclasse preenche passos. |
| **Visitor** | Adiciona operações à hierarquia sem alterar suas classes. |

> Cada arquivo `.cs` tem um `Main` próprio e roda isolado. Para testar um:
> ```
> dotnet run   # dentro da pasta do pattern (ou cole o .cs num projeto console)
> ```
