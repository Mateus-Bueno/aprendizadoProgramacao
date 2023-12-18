#include <stdio.h>

/*
Escreva um programa que leia um número inteiro positivo n e, em seguida imprima n linhas do chamado Triângulo de Floyd. Para n = 6 teríamos;

1
2  3
4  5  6
7  8  9 10
11 12 13 14 15
16 17 18 19 20 21
*/

int main(void){
	int n = 0, m = 0, i = 1, contagem = 1;
	
	printf("Digite N: ");
	scanf("%d", &n);

	while(n > 0){

		for(m = 0; m != i; m++){

			printf("%d ", contagem);
			contagem += 1;
		}

	i += 1;
	n -= 1;
	
	printf("\n");
	}
	return 0;
}