/*Uma empresa quer verificar se um empregado está qualificado para a aposentadoria ou não. Para estar em condições, um dos seguintes requisitos deve ser satisfeito:

i)Ter no mínimo 65 anos de idade.

ii)Ter trabalhado no mínimo 30 anos.

iii)Ter no mínimo 60 anos e ter trabalhado no mínimo 25 anos.

Com base nas informações acima, faça um algoritmo que leia o ano de seu nascimento e o ano de seu ingresso na empresa. 
O programa deverá escrever a idade e o tempo de trabalho do empregado e a mensagem 'Requerer aposentadoria' ou 'Nao requerer'. 
Assuma que o ano corrente é 2021 e não se preocupe com os meses, fazendo a subtração simples dos anos. Utilize os operadores and e or*/

#include <stdio.h>
int main(){
	int nascimento, ingresso, idade, tempo;

	printf("Ano de nascimento: ");
	scanf("%d", &nascimento);

	printf("Ano de ingresso: ");
	scanf("%d", &ingresso);

	idade = 2021 - nascimento;
	tempo = 2021 - ingresso;

	printf("Idade = %d \n", idade);

	printf("Tempo de trabalho = %d \n", tempo);

	if (idade >= 65 || tempo >= 30 || (idade >=60 && tempo >= 25))
		printf("Requerer aposentadoria");
		
	else
		printf("Nao requerer");
}