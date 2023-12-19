/*Faça um programa em C que pergunte duas notas ao usuário e imprima a sua média, usando o formato "%g". Siga exatamente o modelo do exemplo. Declare seu main como:
int main(void)
e coloque um return 0; no final.*/

#include <stdio.h>
int main(void){
	float n1, n2, media;
	printf("Digite a primeira nota: ");
	scanf("%g", &n1);
	printf("Digite a segunda nota: ");
	scanf("%g", &n2);
	media = (n1 + n2) / 2;
	printf("Media=%g", media);
	return 0;
}