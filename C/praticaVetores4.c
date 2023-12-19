//Imprima a string "algoritmos" caractere por caractere, porém na ordem inversa.

#include <stdio.h>

int main(void){
	char str[15] = "algoritmos";
	int i;
	
	for(i = 9; i >= 0; i--){
		printf(" %c ", str[i]);
	}
	
	return 0;
}