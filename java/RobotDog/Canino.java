public abstract class Canino extends Animal{

  public void comportamento(){
  System.out.println("se comportando como um Canino");
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