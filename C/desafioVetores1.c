#include <stdio.h>

int temperaturasAbaixoMedia(int v[]){
	
	int count = 0;
	double soma = 0,media = 0;
	
	for(int i = 0; i < 7; i++){
		soma = soma + v[i];
	}
	
	media = (double)soma / 7;
	
	printf("%g %g ", soma, media);
	
	for(int i = 0; i < 7; i++){
		if (v[i] < media)
			count++;
	}
		
	return count;
}

int main(){
	int v[] = {18, 16, 41, 21, 20, 19, 35};
	printf("%d", temperaturasAbaixoMedia(v));
}