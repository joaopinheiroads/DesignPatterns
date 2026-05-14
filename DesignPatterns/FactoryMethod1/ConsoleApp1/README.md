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