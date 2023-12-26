public abstract class Felino extends Animal{

  public void comportamento(){
  System.out.println("se comportando como um Felino");
  }
  
  String nome = "";
  String raca = "";

  public String getNome(){
    return this.nome;
  }
  public String getRaca(){
    return this.raca;
  }

  public void setNome(String newName){
    this.nome = newName;
  }
  public void setRaca(String newRace){
    this.raca = newRace;
  }
  
}