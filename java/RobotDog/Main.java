interface Pet{
  
  void brincar();
  void petInfo();
}

class Main {
  public static void main(String[] args) {

    Cao cleiton = new Cao();
    cleiton.setNome("Cleiton");
    cleiton.setRaca("Shiba");
    Gato robson = new Gato();
    robson.setNome("Robson");
    robson.setRaca("Siâmes");
    Caotron walt = new Caotron();
    walt.setModelo("Alpha");
    walt.setNumSerie("123");
    Mechanigato disney = new Mechanigato();
    disney.setModelo("Beta");
    disney.setNumSerie("456");

    Pet[] pets = new Pet[4];

    pets[0] = cleiton;
    pets[1] = robson;
    pets[2] = walt;
    pets[3] = disney;

    for (Pet i: pets){
      i.brincar();
      i.petInfo();
    }
    
  }
}