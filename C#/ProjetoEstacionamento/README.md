# Projeto Estacionamento
### Contexto e escopo do projeto

Este projeto foi desenvolvido com a tecnologia C# a partir das seguintes instruções do curso DecolaTech Avanade, da Digital Innovation One:
> Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

O projeto para entrega pode ser acessado [Aqui](https://github.com/Mateus-Bueno/Trilha.NET-Fundamentos-Desafio)


### Principais modificações
Tentando não fugir do escopo trazido pela DIO, eu alterei o sistema na tentativa de torna-lo mais robusto e informativo. Com esse intuito eu inclui:
* Registro de funcionarios do estacionamento, tendo em mente um possível calculo de comissão ou contagem de horas trabalhadas
* Relatório completo ao encerrar o programa, com informações que facilitem a contabilidade de lucros
* Verificações para validar a autenticidade de dados recebidos
* Exceptions para tratar erros e evitar o interrompimento ou mal funcionamento do programa

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Informações sobre o projeto

As duas classes principais deste projeto são "EstacionamentoImp" e "Funcionarios", nesta seção eu irei detalhar mais suas propriedades, métodos e o intuito de cada escolha

## EstacionamentoImp

### Propriedades

* Propriedades inicializadas como decimal para tratarem valores monetários:
  * **precoInicial**: É o preço cobrado para deixar seu veículo estacionado.
  * **precoPorHora**: É o preço por hora que o veículo permanecer estacionado.
  * **lucroDoDia**: É o valor total recebido durante a execução do programa.
  * **lucroNaoRegistrado**: É o valor recebido sem que algum funcionário estivesse logado.
 
* Usei dictionary's pois possibilita atrelar um valor (usei o tipo "string") a uma chave (usei o tipo decimal). Dessa forma eu consegui controlar, a fim de relatórios:
  * **lucroResponsavel**: Guarda quanto foi recebido durante o expediente de cada funcionário.
  * **formaDePagamento**: Guarda quanto foi recebido em cada forma de pagamento.
    
* Usar listas para o controle de veiculos no estacionamento traz praticidade na hora de adicionar ou remover elementos relevantes:
  * **veiculos**: Representa uma coleção de veículos estacionados, contendo apenas a placa do veículo.

### Métodos

* **AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável veiculos caso seja válida.
  
* **RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: precoInicial * precoPorHora, exibindo para o usuário e solicitando a forma de pagamento. Por fim, atualiza os dados relevantes para o relatório.
  
* **ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibie a mensagem "Não há veículos estacionados".
  
* **VerificarPlaca**: Realiza validações na placa informada, com o intuito de garantir a adequação ao padrão mercosul ou nacional único.
  
* **MenuDeUsuario**: Oferece opções de cadastro ou login aos funcionários que utilizam o sistema.
  
* **RelatorioDoDia**: Gera e informa um relatório dividido em três partes
