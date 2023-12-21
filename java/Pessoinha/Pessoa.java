public class Pessoa{
  private String nome;

  public String getNome(){
    return this.nome;
  }

  public void setNome(String newName){
    this.nome = newName;
  }

  private int idade;

  public int getIdade(){
    return this.idade;
  }

  public void setIdade(int newAge){
    this.idade = newAge;
  }

  public void dizerNome(String name){
    System.out.println(name);
  }
  
  public void dizerIdade(int age){
    System.out.println(age);
  }
}