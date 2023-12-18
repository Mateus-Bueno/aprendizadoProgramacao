/*Faça um programa em C que pergunte 2 números inteiros ao usuário e imprima sua soma, subtração, multiplicação e divisão, usando a mensagem "Soma=%d sub=%d mult=%d div=%d\n".*/

#include <stdio.h>
int main(){

	int n1, n2, soma, sub, mult, divi;

	printf("Digite N1: ");
	scanf("%d", &n1);

	printf("Digite N2: ");
	scanf("%d", &n2);

	soma = n1 + n2;
	sub = n1 - n2;
	mult = n1 * n2;
	divi = n1 / n2;
	
	printf("Soma=%d sub=%d mult=%d div=%d\n", soma, sub, mult, divi);
}