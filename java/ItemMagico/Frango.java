public class Frango extends Carne{
  public static int especificoFrango = 10;
  public void atributosItem(Player p1){
    p1.setForca(especificoFrango + atributoCarne + p1.getForca());
  }
}