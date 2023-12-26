public class CabecaAve extends Mercadorias{
  private final int preco = 40;

  public int getPreco(){
    return this.preco;
  }

  private static int estoque = 0;

  public static int getEstoque(){
    return estoque;
  }

  public static void setEstoque(int estoque){
      CabecaAve.estoque = estoque;
  }

  public CabecaAve(){
    estoque++;
  }
}
