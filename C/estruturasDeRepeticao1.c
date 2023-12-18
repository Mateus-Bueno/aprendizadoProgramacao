#include <stdio.h>

/*Escreva um algoritmo que leia 10 números inteiros, com valores positivos ou negativos, e ao final exiba os seguintes resultados:

Quantidade de números digitados maiores ou igual a 0;

Quantidade de números digitados menores que 0;

Soma de todos os números digitados maiores que zero;

Soma dos números digitados menores que zero.
*/

int main(void){
	
	int qtd_maior = 0, qtd_menor = 0, s_maior = 0, s_menor = 0, n = 0, i = 0;

	for(i = 0; i < 10; i += 1){

		printf("Digite um numero: ");
		scanf("%d", &n);

		if(n >= 0){
			qtd_maior += 1;
			s_maior = s_maior + n;
		}

		else{
			qtd_menor += 1;
			s_menor = s_menor + n;
		}
	}
	
	printf("A quantidade de numeros digitados maiores ou igual a 0 e' %d\n", qtd_maior);
	printf("A quantidade de numeros digitados menores que 0 e' %d\n", qtd_menor);
	printf("A soma de todos os numeros digitados maiores que zero e' %d\n", s_maior);
	printf("A soma dos numeros digitados menores que zero e' %d\n", s_menor);
}