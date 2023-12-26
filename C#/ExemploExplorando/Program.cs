using ExemploExplorando.Models;
using System.Globalization;

Dictionary<string, string> estados = new Dictionary<string, string>();

estados.Add("SP", "São Paulo");
estados.Add("BA", "Bahia");
estados.Add("MG", "Minas Gerais");

foreach(var item in estados)
{
    Console.WriteLine($"Chave: {item.Key}, Valor do item na chave: {item.Value}");
}





















// Stack<int> pilha = new Stack<int>();

// pilha.Push(4);
// pilha.Push(6);
// pilha.Push(8);
// pilha.Push(10);

// foreach(int item in pilha)
// {
//     Console.WriteLine(item);
// }





























// Queue<int> fila = new Queue<int>();

// fila.Enqueue(2);
// fila.Enqueue(4);
// fila.Enqueue(6);
// fila.Enqueue(8);

// foreach(int item in fila)
// {
//     Console.WriteLine(item);
    
// }
// await Task.Delay(2000);
// Console.Clear();

// Console.WriteLine($"retirando o item: {fila.Dequeue()}");
// await Task.Delay(2000);
// Console.Clear();
// fila.Enqueue(10);

// foreach(int item in fila)
// {
//     Console.WriteLine(item);
// }


























// new ExemploExcecao().Metodo1();





















// Pessoa pessoa1 = new Pessoa(nome: "Jão",sobrenome:  "Valdo");

// Pessoa pessoa2 = new Pessoa(nome: "Jubiscreia",sobrenome: "Silveira");

// Curso cursoDeIngles = new Curso();
// cursoDeIngles.Nome = "Ingles";
// cursoDeIngles.Alunos = new List<Pessoa>();


// cursoDeIngles.AdicionarAluno(pessoa1);
// cursoDeIngles.AdicionarAluno(pessoa2);
// cursoDeIngles.ListarAlunos();













// try
// {
//  string[] linhas = File.ReadAllLines("Arquivos/tex_to.txt");

// foreach (string linha in linhas)
// {
//     Console.WriteLine($"{linha}");
// }   

// }

// catch (Exception ex)
// {
//     Console.WriteLine($"excessão genérica: {ex.Message}");
// }

// Console.WriteLine($"O código continuou");