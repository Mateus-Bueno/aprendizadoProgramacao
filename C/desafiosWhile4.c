#include <stdio.h>
int main(void){
	
	int n = 0, i = 0, a1 = 0, a2 = 1, soma = 0;
	
	printf("Digite N: ");
	scanf("%d", &n);

	while(n != i){

		printf("%d ", a1);

		soma = a1 + a2;
		a1 = a2;
		a2 = soma;
		i += 1;
	}
	
	return 0;
}