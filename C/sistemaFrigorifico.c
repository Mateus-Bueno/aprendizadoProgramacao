/*Você foi contratado para desenvolver um software para um frigorífico. O sistema deve efetuar o controle de idade e peso dos animais recebidos e quando chegar 
no final do dia um relatório com algumas informações deverá ser apresentado.

O sistema deverá possuir:
Ao iniciar o sistema o usuário deverá informar o preço da arroba do boi naquele dia.
Em seguida, deve ser mostrado, repetidamente, um menu para o usuário, com as seguintes opções:
Inserir os dados de um animal
Finalizar o lançamento
Reset (Deverá reiniciar os valores inseridos)
Sair

Se for digitada a primeira opção, as informações fornecidas de cada animal serão o número de identificação do animal, o  peso (em quilos) e a idade em meses. Atenção com o tipo de dados utilizados.

O relatório que será apresentado ao finalizar o lançamento deverá possuir as informações:
O total de peso dos animais recebidos
A identificação, o peso e a idade do animal mais pesado
A identificação, o peso e a idade do animal mais leve
A idade e peso do animal mais velho
A idade e peso do animal mais novo
A média de peso dos animais
A média de idade dos animais
O preço total do lote. 
Para exibir o preço total do lote você deverá converter o peso de quilo para arroba, lembrando que uma arroba corresponde a 15 quilos.

Utilize, na medida do possível, funções para ajudar no desenvolvimento do projeto.*/

#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

//indica que existem funções ao fim do programa
void cadastro(void);
void reset(void);
void lancamento(void);

//variáveis globais que serão modificadas dentro das funções
int count, id, idade, s_idade;
double peso, s_peso, preco_arroba;

int idade_velho, idade_jovem = INT_MAX, idade_pesado, idade_leve;
int id_pesado, id_leve;
double peso_velho, peso_jovem, peso_pesado, peso_leve = INT_MAX;

//programa principal
int main(void){
	
	int selecao = 0;
	
	printf("Informe o preco da arroba de boi hoje: ");
	scanf("%lf", &preco_arroba);
	
	printf("\n1. Inserir os dados de um animal\n2. Finalizar o lancamento\n3. Reset\n4. Sair\n\n");
	scanf("%d", &selecao);
	
	while (1){
		
		if (selecao > 0 && selecao <= 4){  //O if garante que não serão inseridos números que fogem às opções
			switch(selecao){
				case 1:
					cadastro();
					break;
					
				case 2:
					if (count == 0)   //Erro caso o lançamento ocorra sem que hajam dados inseridos
						printf("\nLancamento Invalido!!\n");
					else
						lancamento();		
					break;
					
				case 3:
					reset();
					break;
					
				case 4:
					exit(0);
					break;
					
			}
		}
		
		else
			printf("\nSelecione uma opcao listada!!\n");
		
		//repete a mensagem que aparece fora do "while" para garantir o continuamento do programa
		printf("\n1. Inserir os dados de um animal\n2. Finalizar o lancamento\n3. Reset\n4. Sair\n\n");
		scanf("%d", &selecao);
	}
	
	return 0;
}

void cadastro(void){
	
	//Pergunta e armazena valores que serão utilizados depois no lançamento
	printf("\nNumero de Identificacao: ");
	scanf("%d", &id);
	
	printf("Peso(Kg): ");
	scanf("%lf", &peso);
	
	printf("Idade(Meses): ");
	scanf("%d", &idade);
	
	s_peso += peso;
	s_idade += idade;
	count += 1;
	
	//Identifica dados referentes ao relatório
	if (idade_velho < idade){
		idade_velho = idade;
		peso_velho = peso;
	}
	
	if (idade_jovem > idade){
		idade_jovem = idade;
		peso_jovem = peso;
	}
	
	if (peso_pesado < peso){
		id_pesado = id;
		peso_pesado = peso;
		idade_pesado = idade;
	}
	
	if (peso_leve > peso){
		id_leve = id;
		peso_leve = peso;
		idade_leve = idade;
	}
	
	return;
	
}

void reset(void){   //Retorna o valor de todas as variáveis para 0
	
	id = 0;
	idade = 0;
	s_idade = 0;
	peso = 0;
	s_peso = 0;
	idade_velho = 0;
	idade_jovem = 0;
	idade_pesado = 0;
	idade_leve = 0;
	id_pesado = 0;
	id_leve = 0;
	peso_velho = 0;
	peso_jovem = 0;
	peso_pesado = 0;
	peso_leve = 0;
	count = 0;
	
	return;
}

void lancamento(void){     //exibe o relátorio
	printf("\nO total de peso recebido foi %gKg\n", s_peso);
	printf("A identificacao, peso e idade do animal mais pesado e' %d, %gKg e %d meses\n", id_pesado, peso_pesado, idade_pesado);
	printf("A identificacao, peso e idade do animal mais leve e' %d, %gKg e %d meses\n", id_leve, peso_leve, idade_leve);
	printf("A idade e o peso do animal mais velho sao %d meses e %gKg\n", idade_velho, peso_velho);
	printf("A idade e o peso do animal mais jovem sao %d meses e %gKg\n", idade_jovem, peso_jovem);
	printf("A media de peso dos animais e' %gKg\n", (s_peso / count));
	printf("A media de idade dos animais e' %g meses\n", (double)(s_idade / count));
	printf("O valor total do lote e' %g reais\n", (s_peso / 15) * preco_arroba);
	printf("\n");
	
	return;
	
}