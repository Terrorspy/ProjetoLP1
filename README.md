# Snakes And Ladders
## Autores: Diogo Soares, 22107218. Tomás Váz, 22102918. Rodrigo Ferreira, 22103286.
### Tomás Vaz fez o tabuleiro. (Na sua branch)
### Rodrigo Ferreira fez o dado e os jogadores. (Como não criou a sua branch mandou em privado)
### Diogo Soares corrigiu o que estava errado e adicionou as regras do jogo ao tabuleiro. (Na sua branch)

O repositório Git utiizado chama-se ProjetoLP1.\
O link do [repositório](https://github.com/Terrorspy/ProjetoLP1).\
O repositório irá ficar privado durante 24 horas depois da entrega do trabalho, onde depois irá ficar público.

## O código foi organizado desta maneira
Criou-se uma classe chamada board para o tabuleiro, fazendo um array bidimensional 5x5.\
Depois de ter sido criado, no início tinhamos ido a cada posição do array e metemos os números, claramente não podia ser assim.\
Então resolvemos mudar isso, decidimos dividir o array em par e ímpar.\
Se a linha fosse **par** ela ia: "1, 2, 3, 4, 5". Da esquerda para a direita.\
Se a linha fosse **ímpar** ela ia: "10, 9, 8, 7, 6". Da direita para a esquerda.

**Par**: Matrix[i,j] = ((i*5) + (j + 1)).ToString();\
**Ímpar**: Matrix[i,j] = ((i*5) + (5 - j)).ToString();

Depois foi feito print da board para ver se funcionava.\
Foi feito uma função que recebia valores das posições e verificava se as posições fossem fora do array\
deixava-se como vazio.\
Asseguir foi feito um gerador para gerar novas posições random para as casas especiais.\
Foi feita uma função para gerar as posições random para as casas especiais seguindo as suas restrições.\
Cada casa especial ter uma letra que a identifique.\
**Snakes = S\
Ladders = H\
Cobra = C\
Boost = B\
U-Turn = U\
ExtraDie = O\
CheatDie = Q**

Verificou-se onde se podia meter as casas especiais sabendo que havia restrições sendo na primeira e última casa do tabuleiro\
e claramente não podia estar fora do tabuleiro e dentro da mesma casa com uma casa especial já colocada.\
Foi feita uma função que aplicava os efeitos das casas especiais.

Criou-se uma classe chamado player, para os jogadores, o seu movimento e os dados.\
Foi feito getters e setters para os ID e as posições dos jogadores.\
Também foi feito getters e setters para o Extra Die e Cheat Die.\
Asseguir foi feito uma função que permite o jogador andar para a frente depois de lançar o dado.\
Também foi feito uma função que permite o jogador andar para trás.\
Depois foi feito dois randoms para o RollDice e o ExtraDice.\
Foi feito uma função que pergunta ao jogador que número quer que sai para o Cheat Dice.

Criou-se uma classe chamada SnakeAndLadders.\
Começa o jogo e criou-se um game loop até alguém ganhar.\
Também diz quem está a jogar e o número que lançou do dado.

## Referências
Debate com membros de família que percebem programação para aplicação dos efeitos das casas especiais\
e movimento dos jogadores.

## Fluxograma
![Fluxograma Snake and Ladders - Página 1](https://user-images.githubusercontent.com/92086908/161431670-529e75a4-c77a-46c4-ac3e-809edc0fbe95.png)
