/*
Leia um vetor de 12 posições e em seguida ler também dois valores
x e y correspondentes a duas posições no vetor. Ao final, seu 
programa deverá escrever a soma dos valores encontrados nas 
respectivas posições x e y.
*/

#include <stdio.h>

int main(void){
	int vetor [12];
	int i, x, y;
	int resultado;
	
	for (i = 0; i < 12; i++){
		
	printf("digite um numero: ");
	scanf("%d", &vetor[i]);
	
	}
	
	printf("Agora digite duas posicoes: \n");
	scanf("%d", &x);
	scanf("%d", &y);
	
	resultado = vetor[x] + vetor[y];
	printf("A soma dos valores nessas posicoes e': %d", resultado);
	
	return 0;
	
}