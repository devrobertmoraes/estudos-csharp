# Processador de pedidos básico

O intuito desse exercício é reforçar o aprendizado de manipulação de strings em C#, por meio de um projeto console básico que recebe os dados do pedido de um cliente numa única linha, processa as informações e exibe um resumo formatado do pedido.

## Cenário hipotético

Imagina que está recebendo dados de um sistema antigo. Este sistema envia os detalhes de um pedido como uma única string de texto, com os campos separados por vírgula. O teu trabalho é ler essa string, extrair os dados, fazer um pequeno cálculo e apresentar um recibo bem formatado para o utilizador.

### Formato da string de entrada

A string de entrada terá sempre o seguinte formato:
>nome do cliente  ,  email@dominio.com  ,  ID_DO_PRODUTO-quantidade  ,  preço unitário 

Exemplo de Entrada:
>Ana Silva  ,  ana.silva@example.com  ,  PROD001-2  ,  25.50 