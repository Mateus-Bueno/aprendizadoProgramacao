/*
Declare um vetor de 10 posições e o preencha com os 
10 primeiros números ímpares e mostre o vetor na tela.
*/

#include <stdio.h>

int main(void){
	
	int vetor[10];
	int i, impares = 1;
	
	for(i = 0; i < 10; i++){
		vetor[i] = impares;
		impares += 2;
	}
	
	for(i = 0; i < 10; i++){
		printf("\n%d", vetor[i]);
	}

	return 0;
}