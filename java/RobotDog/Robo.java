public class Robo implements Pet{

  public void brincar(){
    System.out.println("");
  }

      public void petInfo(){
    System.out.println("");
  }

  String modelo = "";
  String numSerie = "";

  public String getModelo(){
    return this.modelo;
  }
  public String getNumSerie(){
    return this.numSerie;
  }

  public void setModelo(String newModel){
    this.modelo = newModel;
  }
  public void setNumSerie(String newSerial){
    this.numSerie = newSerial;
  }
  
}