public class Carrinho{

  private static Mercadorias[] compras = new Mercadorias[50];
  private static Cupom[] descontos = new Cupom[50];
  static int capacidade = 0;
  static int qtdCupons = 0;

  public static void adicionarItem(Mercadorias produto, int quantidade, Cupom desconto){

    int estoqueProduto = 0;
    int pedido = quantidade;

    switch(Mercadorias.conferirProduto(produto)){
      case 1:
        estoqueProduto = CabecaAve.getEstoque();
        break;
      case 2:
        estoqueProduto = MacaEnvenenada.getEstoque();
        break;
      case 3:
        estoqueProduto = MacaPodre.getEstoque();
        break;
      case 4:
        estoqueProduto = OssoBoi.getEstoque();
        break;
      case 5:
        estoqueProduto = PataGoblin.getEstoque();
        break;
      case 6:
        estoqueProduto = PresasLobo.getEstoque();
        break;
    }
    
    for(int i = 0; i < quantidade; i++){
      
      if(capacidade + pedido > 50){
        System.out.println("Essa compra não cabe no carrinho!!");
        System.out.println("Compra atual: " + quantidade + "x " + produto.getClass().getSimpleName());
        break;
      }

      else if(desconto.getDesconto() != 0 && desconto.getProduto() != produto){
        System.out.println("Cupom inválido, tente a compra novamente!!");
        break;
      }
        
      else if(estoqueProduto < pedido){
        System.out.println("O estoque do produto não suporta essa compra!!");
        System.out.println("Estoque atual de " + produto.getClass().getSimpleName() + ": " + estoqueProduto + "x");
        break;
      }

      else{
        switch(capacidade){
          case 50:
            System.out.println("não foi possível adicionar " + produto.getClass().getSimpleName() + " pois o carrinho já está cheio!");
            System.out.println("Termine a compra atual antes de adicionar mais coisas.");
            break;
          default:
            compras[capacidade] = produto;
            capacidade += 1;
            descontos[qtdCupons] = desconto;
            qtdCupons += 1;
            if(desconto.getDesconto() == 0){
              qtdCupons -= 1;
            }
            estoqueProduto -= 1;
            pedido -= 1;
            break;
        }
      }
    }

    switch(Mercadorias.conferirProduto(produto)){
      case 1:
        CabecaAve.setEstoque(estoqueProduto);
        break;
      case 2:
        MacaEnvenenada.setEstoque(estoqueProduto);
        break;
      case 3:
        MacaPodre.setEstoque(estoqueProduto);
        break;
      case 4:
        OssoBoi.setEstoque(estoqueProduto);
        break;
      case 5:
        PataGoblin.setEstoque(estoqueProduto);
        break;
      case 6:
        PresasLobo.setEstoque(estoqueProduto);
        break;
    }
  }

  public static void verCarrinho(){
    
    if (capacidade == 0){
      System.out.println("carrinho vazio!");
    }
      
    else{

      int count = 0;
      
      System.out.println("Conteúdo do carrinho: ");
      
      for(int i = 0; i < capacidade; i++){
        for(int j = 0; j < capacidade; j++){
          if(compras[i].equals(compras[j])){
            count++;
          }
        }

        boolean repetido = true;
        
        for(int j = 0; j < i; j++){
          if(compras[i].equals(compras[j])){
            repetido = false;
            break;
          }       
        }

        if(repetido){
          System.out.println(count + "x " + compras[i].getClass().getSimpleName());
        }

        count = 0;
      }
    }
  }
  
  

  public static void calcular(){
    int total = 0;
    double descontado = 0;
    
    for(int i = 0; i < capacidade; i++){
      total += compras[i].getPreco();
    }

    for(int i = 0; i < capacidade; i++){
      for(int j = 0; j < qtdCupons; j++){
        if(compras[i].equals(descontos[j].getProduto())){
          descontado += (descontos[j].getProduto().getPreco() * descontos[j].getDesconto());
          break;
        }
      }
    }
    System.out.println("$" + (total - descontado)); 
  }
  
  public static void fecharCompra(){
    for(int i = 0; i < capacidade; i++){
      compras[i] = null;
    }
    capacidade = 0;
    qtdCupons = 0;

    System.out.println("Compra realizada com sucesso");
    System.out.println(" ");
  }

  public static void removerUltimoPedido(){
  } 
}  