Use o Factory Method quando não souber de antemão os tipos
e dependências exatas dos objetos com os quais seu código
deve funcionar.
O Factory Method separa o código de construção do produto
do código que realmente usa o produto. Portanto, é mais fácil

estender o código de construção do produto independente-
mente do restante do código.

Por exemplo, para adicionar um novo tipo de produto à apli-
cação, só será necessário criar uma nova subclasse criadora e

substituir o método fábrica nela.

Use o Factory Method quando desejar fornecer aos usuários
da sua biblioteca ou framework uma maneira de estender seus
componentes internos.
Herança é provavelmente a maneira mais fácil de estender o
comportamento padrão de uma biblioteca ou framework. Mas
como o framework reconheceria que sua subclasse deve ser
usada em vez de um componente padrão?

A solução é reduzir o código que constrói componentes no fra-
mework em um único método fábrica e permitir que qualquer

pessoa sobrescreva esse método, além de estender o próprio
componente.


Como implementar
1. Faça todos os produtos implementarem a mesma interface.
Essa interface deve declarar métodos que fazem sentido em
todos os produtos.

93 Padrões de projeto criacionais / Factory Method #49888

endrickgb97@gmail.com (#49888)

2. Adicione um método fábrica vazio dentro da classe criadora.
O tipo de retorno do método deve corresponder à interface
comum do produto.
3. No código da classe criadora, encontre todas as referências aos

construtores de produtos. Um por um, substitua-os por chama-
das ao método fábrica, enquanto extrai o código de criação do

produto para o método fábrica.
Pode ser necessário adicionar um parâmetro temporário ao
método fábrica para controlar o tipo de produto retornado.

Neste ponto, o código do método fábrica pode parecer bas-
tante feio. Pode ter um grande operador switch que escolhe

qual classe de produto instanciar. Mas não se preocupe, resol-
veremos isso em breve.

4. Agora, crie um conjunto de subclasses criadoras para cada tipo
de produto listado no método fábrica. Sobrescreva o método

fábrica nas subclasses e extraia os pedaços apropriados do có-
digo de construção do método base.

5. Se houver muitos tipos de produtos e não fizer sentido criar
subclasses para todos eles, você poderá reutilizar o parâmetro
de controle da classe base nas subclasses.
Por exemplo, imagine que você tenha a seguinte hierarquia
de classes: a classe base Correio com algumas subclasses:
CorreioAéreo e CorreioTerrestre ; as classes Transporte
94 Padrões de projeto criacionais / Factory Method #49888

endrickgb97@gmail.com (#49888)

são Avião , Caminhão e Trem . Enquanto a classe
CorreioAéreo usa apenas objetos Avião , o
CorreioTerrestre pode funcionar com os objetos Caminhão
e Trem . Você pode criar uma nova subclasse (por exemplo,
CorreioFerroviário ) para lidar com os dois casos, mas há
outra opção. O código do cliente pode passar um argumento

para o método fábrica da classe CorreioTerrestre para con-
trolar qual produto ele deseja receber.

6. Se, após todas as extrações, o método fábrica base ficar vazio,

você poderá torná-lo abstrato. Se sobrar algo, você pode tor-
nar isso em um comportamento padrão do método.

Prós e contras
Você evita acoplamentos firmes entre o criador e os produtos
concretos.
Princípio de responsabilidade única. Você pode mover o código

de criação do produto para um único local do programa, facili-
tando a manutenção do código.

Princípio aberto/fechado. Você pode introduzir novos tipos de
produtos no programa sem quebrar o código cliente existente.

O código pode se tornar mais complicado, pois você precisa in-
troduzir muitas subclasses novas para implementar o padrão.

O melhor cenário é quando você está introduzindo o padrão
em uma hierarquia existente de classes criadoras.