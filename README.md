# PythonCSharp
Projeto de estudo sobre Python executando em uma aplicação C#.

## Implementação realizada
Projeto exemplo para consumo de Python em um projeto C#.
O projeto faz duas execuções, a primeira chama uma função do python que lê um arquivo e devolve o conteúdo do arquivo.
A segunda interação com o python é de enviar uma imagem e o python grava a imagem no container.

## Recursos
Foi construído uma imagem docker que instala o python na composição da máquina e deixa o python disponível para uso.
No projeto tem exemplos de chamadas das funções do python via C#.
Não foi utilizado nenhuma lib de apoio para o Net consumir o Python apenas a lib System.IO para realizar o stream com os arquivos Python.
