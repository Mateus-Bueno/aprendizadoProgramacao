using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAvanade.Models
{
    public class Calculadora
    {
        public void Potencia (int x, int y)
        {
            double pot = Math.Pow(x, y);
            Console.WriteLine($"{x} ^ {y} = {pot}");
        }

        public void Seno(double angulo)
        {
            double radiano = angulo * Math.PI / 180;
            double seno = Math.Sin(radiano);
            Console.WriteLine($"O seno de {angulo} é {Math.Round(seno, 4)}");
        }

        public void Coseno(double angulo)
        {
            double radiano = angulo * Math.PI / 180;
            double coseno = Math.Cos(radiano);
            Console.WriteLine($"O coseno de {angulo} é {Math.Round(coseno, 4)}");
        }

        public void RaizQuadrada(double x)
        {
            double raiz = Math.Sqrt(x);
            Console.WriteLine($"A raiz de {x} é {raiz}");
        }
    }
}