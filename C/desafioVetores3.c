#include <stdio.h>
#include <limits.h>

int main(){

	int sequencia[15];
	int i, j, count = -3;
	int soma_trecho = 0;
	int indice, maior_trecho = INT_MIN;
	
	for(i = 0; i < 15; i++){ 

		printf("Digite um numero: ");
		scanf("%d", &sequencia[i]);

		if (sequencia[i] == 999){
			sequencia[i] = 0;
			break;
		}
		
		count++;
	}
	
	for(i = 0; i < count; i++){
		
		for (j = i; j < (i + 4); j++)
			soma_trecho += sequencia[j];
		
		if (maior_trecho < soma_trecho){
			
			maior_trecho = soma_trecho;
			indice = i;
		}
		
		soma_trecho = 0;
	}
	
	printf("soma=%d inicio=%d", maior_trecho, indice);
	
	return 0;
}