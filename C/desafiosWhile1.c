/*Faça um programa que pergunte: "Digite N: ", calcule o fatorial de N e imprima: "O fatorial de {n} e' {fatorial}". 
Veja os exemplos. Use números inteiros. Dica: você pode calcular o fatorial tanto na ordem crescente, 1 * 2 * 3 * 4, 
quanto na ordem decrescente, 4 * 3 * 2 * 1. Multiplicar por 1 é opcional, 
mas tem que funcionar também para o fatorial de zero, que é igual a 1.*/

#include <stdio.h>

int fatorial (int n){

	int i = 0, fat = 1;

	if (n > 0){
		for (i = n; i >= 1; i--){
			fat *= i;
		}
	}
	
	return fat;
}

int main(){
	printf("%d\n", fatorial(4));
}