public class Cupom{  
  private double desconto;

  public double getDesconto(){
    return this.desconto;
  }
  
  private Mercadorias produto;

  public Mercadorias getProduto(){
    return this.produto;
  }

  public Cupom(int desconto){
    this.desconto = desconto / 100.0;
  }

  public Cupom(int desconto, Mercadorias produto){
    this.desconto = desconto / 100.0;
    this.produto = produto;
  }
}