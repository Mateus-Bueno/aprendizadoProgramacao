public class OssoBoi extends Mercadorias{
  private final int preco = 10;

  public int getPreco(){
    return this.preco;
  }

  private static int estoque = 0;

  public static int getEstoque(){
    return estoque;
  }

  public static void setEstoque(int estoque){
    OssoBoi.estoque = estoque;
  }

  public OssoBoi(){
    estoque++;
  }
}