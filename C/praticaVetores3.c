/*
Declare um vetor de caracteres e inicialize com a string "algoritmos".
Então conte quantos caracteres tem esta string e imprima. Não use a função strlen().
*/

#include <stdio.h>
int main(void){
	
	char str[15] = "algoritmos";
	int i;

	while (str[i] != 0){
		i++;
	}

	printf("%d", i);
	printf("\n%d", str[14]);
	
	return 0;
}