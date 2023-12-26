public class Mercadorias{

  private int preco;

  public int getPreco(){
    return preco;
  }

  private static int estoque;

  public static int getEstoque(){
    return estoque;
  }

  public static void setEstoque(int estoque){
  }

  public static int conferirProduto(Mercadorias produto){
    
    int i = 0;
    
    if(produto instanceof CabecaAve){
      i = 1;
    }
    else if(produto instanceof MacaEnvenenada){
      i = 2;
    }
    else if(produto instanceof MacaPodre){
      i = 3;
    }
    else if(produto instanceof OssoBoi){
      i = 4;
    }
    else if(produto instanceof PataGoblin){
      i = 5;
    }
    else if(produto instanceof PresasLobo){
      i = 6;
    }

    return i;
  }
  
}