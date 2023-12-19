/*Construa um programa que pergunte a idade e altura de uma turma de alunos, terminando quando for digitada uma idade igual a zero. Use alturas em metros. O programa deve imprimir três frases em linhas distintas:
a)      "A classe tem %d alunos"
b)      "A idade media dos alunos com menos de 1,70m de altura e' %g". Se não houver alunos nessa condição, deverá ser impresso "Nao ha' alunos com menos de 1,70m de altura".
c)       "A altura media dos alunos com mais de 20 anos e' %g". Se não houver alunos nessa condição, deverá ser impresso "Nao ha' alunos com mais de 20 anos".

Dica: guarde as somas e quantidades e deixe para calcular as médias no final. Confira os exemplos.*/

#include <stdio.h>
int main(void){
	
	int idade = 0, qtd_alunos = 0, s_idade = 0, qtd_i = 0, qtd_a = 0;
	double altura = 0, alt_media = 0, idade_media = 0, s_altura = 0;

	printf("Idade: ");
	scanf("%d", &idade);

	while (idade != 0){

		printf("Altura: ");
		scanf("%lf", &altura);

		if (idade > 20){
			qtd_a += 1;
			s_altura = s_altura + altura;
		}

		if (altura < 1.70){
			qtd_i += 1;
			s_idade = s_idade + idade;
		}

		printf("Idade: ");
		scanf("%d", &idade);

		qtd_alunos += 1;
	}

	printf("A classe tem %d alunos \n", qtd_alunos

	);
	
	if (qtd_i > 0){
		idade_media = (s_idade / qtd_i);
		printf("A idade media dos alunos com menos de 1,70m de altura e' %.2f \n", idade_media);
	}

	else
		printf("Nao ha' alunos com menos de 1,70m de altura \n");

	if (qtd_a > 0){
		alt_media = (s_altura / qtd_a);
		printf("A altura media dos alunos com mais de 20 anos e' %.2f", alt_media);
	}

	else
		printf("Nao ha' alunos com mais de 20 anos");
		
	return 0;
}