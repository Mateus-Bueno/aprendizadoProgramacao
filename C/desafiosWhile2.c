/*Faça um programa que pergunte um número real com "Digite N: " e divida-o por dois sucessivamente até que o resultado seja menor que 1. 
Mostre o resultado da última divisão e a quantidade de divisões efetuadas. Siga exatamente os exemplos.*/

#include <stdio.h>
int main(void){

	double n = 0, repeticoes = 0;

	printf("Digite N: ");
	scanf("%lf", &n);

	while (n >= 1){
		n /= 2;
		repeticoes += 1;
	}

	printf("Ultimo resultado = %g \n", n);
	printf("Foram feitas %g divisoes", repeticoes);

	return 0;
}