public class CogumeloAzul extends Fungo{
  public static int especificoCogumeloAzul = 10;
  public void atributosItem(Player p1){
    p1.setInteligencia(especificoCogumeloAzul + atributoFungo + p1.getInteligencia());
  }
}