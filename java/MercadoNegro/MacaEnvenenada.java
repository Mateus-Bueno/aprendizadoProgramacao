public class MacaEnvenenada extends Mercadorias{
  private final int preco = 20;

  public int getPreco(){
    return this.preco;
  }

  private static int estoque = 0;

  public static int getEstoque(){
    return estoque;
  }

  public MacaEnvenenada(){
    estoque++;
  }
}