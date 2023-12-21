public class PataGoblin extends Mercadorias{
  private final int preco = 50;

  public int getPreco(){
    return this.preco;
  }

  private static int estoque = 0;

  public static int getEstoque(){
    return estoque;
  }

  public PataGoblin(){
    estoque++;
  }
  
}