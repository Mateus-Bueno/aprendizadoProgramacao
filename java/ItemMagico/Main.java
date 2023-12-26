class Main {
  public static void main(String[] args) {
    Player p1 = new Player();
    p1.setForca(15);
    p1.setInteligencia(15);
    p1.setDefFisica(15);
    p1.setDefMagica(15);

    Frango frango = new Frango();
    frango.atributosItem(p1);
    
    System.out.println(p1.getForca());
    System.out.println(p1.getInteligencia());
    System.out.println(p1.getDefFisica());
    System.out.println(p1.getDefMagica());

    
  }
}
