public class Peixe extends Carne{
  public static int especificoPeixe = 10;
  public void atributosItem(Player p1){
    p1.setDefFisica(especificoPeixe + atributoCarne + p1.getDefFisica());
  }
}