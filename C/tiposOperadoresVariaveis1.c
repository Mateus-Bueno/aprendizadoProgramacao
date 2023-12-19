/*Escreva um programa em C que pergunte ao usuário: "Entre com um numero inteiro: " e escreva na tela o seu antecessor, sem qualquer mensagem. Antecessor é número que vem antes, ou seja, n - 1.*/

#include <stdio.h>
int main(){
	int n, antecessor;
	printf("Entre com um numero inteiro: ");
	scanf("%d", &n);
	antecessor = n - 1;
	printf("%d", antecessor);
}