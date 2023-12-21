public class PresasLobo extends Mercadorias{
  private final int preco = 11;

  public int getPreco(){
    return this.preco;
  }

  private static int estoque = 0;

  public static int getEstoque(){
    return estoque;
  }

  public PresasLobo(){
    estoque++;
  }
}