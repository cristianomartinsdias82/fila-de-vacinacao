O desafio

Fazer um algoritmo simples, em sua linguagem de preferência que deve resolver a seguinte questão:
Temos uma lista em formato JSON com 20 pessoas que estão na fila de vacinação.

Deve-se construir um algoritmo que organize esta lista em 4 grupos para vacinação.
Os grupos devem ser separados levando em consideração as regras:
1. Maiores de 60 anos tem prioridade;
2. Atividades essenciais tem prioridades. Elas são: Saúde, Educação Alimentícios e Segurança.

Cada grupo será vacinado um dia, seguindo a ordem: Grupo 1, 2, 3 e depois o 4.

Solução
Foi desenvolvida uma solução composta por uma API Rest que retorna a lista com a ordenação conforme o enunciado acima

Como executar a API
1. Clone o repositório
2. Navegue até a pasta do repositório baixado contendo o arquivo .sln
3. Abra a solução no Visual Studio 2019 ou posterior
4. Pressione CTRL + F5. Após a compilação, o navegador web padrão da sua máquina abrirá apontando para o Swagger da aplicação
5. Acione o endpoint de listagem de filas de vacinação
