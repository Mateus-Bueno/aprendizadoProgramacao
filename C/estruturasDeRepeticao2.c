#include <stdio.h>

/*Dado um país A, com 5.000.000 de habitantes e uma taxa de natalidade de 3% ao ano,
e um país B com 7.000.000 de habitantes e uma taxa de natalidade de 2% ao ano. 
Escreva um algoritmo que seja capaz de calcular e mostrar o tempo necessário para que
a população do país A ultrapasse a população do país B. Utilize uma estrutura de 
repetição para realizar o cálculo.*/

int main(void){
	
	int habitantes_A = 5000000, habitantes_B = 7000000, tempo = 0;
	
	while(habitantes_A < habitantes_B){
		habitantes_A = habitantes_A * 1.03;
		habitantes_B = habitantes_B * 1.02;
		tempo += 1;
	}
	
	printf("A populacao do pais A ultrapassara a populacao do pais B em %d anos.", tempo);
	
	return 0;
	
}