public class CogumeloRoxo extends Fungo{
  public static int especificoCogumeloRoxo = 10;
  public void atributosItem(Player p1){
    p1.setDefMagica(especificoCogumeloRoxo + atributoFungo + p1.getDefMagica());
  }
}