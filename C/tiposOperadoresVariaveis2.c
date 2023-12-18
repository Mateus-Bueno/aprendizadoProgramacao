/*Elabore um programa em C que efetue a apresentação do valor da conversão em real (R$) de um valor lido em dólar (US$). O programa deverá solicitar o valor da cotação do dólar e também a quantidade de dólares disponíveis com o usuário. Pergunte "Valor do dolar: " e "Quantidade de dolares: " e imprima "R$ " seguido do valor em reais, em formato %g.*/

#include <stdio.h>
int main(){
	float val_dolar, qtd_dolar, qtd_real;
	printf("Valor do dolar: ");
	scanf("%g", &val_dolar);
	printf("Quantidade de dolares: ");
	scanf("%g", &qtd_dolar);
	qtd_real = val_dolar * qtd_dolar;
	printf("R$ %g", qtd_real);
}