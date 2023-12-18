#include <stdio.h>
#include <math.h>

int main(){

	double polinomio[6];
	double x;
	double p = 0;
	int i;
	
	for(i = 0; i < 6; i++){

		printf("Digie o coeficiente %d:\n", i);
		scanf("%lf", &polinomio[i]);
	}
	
	while(1){
		
		printf("Digite X: ");
		scanf("%lf", &x);
		
		if(x == 0)
			break;
		
		for(i = 0; i < 6; i++){
			p += (polinomio[i]) * (pow(x, i));
		}
		
		printf("p(%g) = %g\n", x, p);
		
		p = 0;
	}
	
	return 0;
}