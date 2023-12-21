public class MacaPodre extends Mercadorias{
  private final int preco = 5;

  public int getPreco(){
    return this.preco;
  }

  private static int estoque = 0;

  public static int getEstoque(){
    return estoque;
  }

  public MacaPodre(){
    estoque++;
  }
  
}