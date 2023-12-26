class Main {
  public static void main(String[] args) {

    Mercadorias[] estoqueCabecas = new CabecaAve[100];
    
    for (int i = 0; i < 100; i++) {
        estoqueCabecas[i] = new CabecaAve();
    }

    Mercadorias[] estoqueMacaEnv = new MacaEnvenenada[100];
  
    for (int i = 0; i < 100; i++) {
      estoqueMacaEnv[i] = new MacaEnvenenada();
    }
    

    Mercadorias[] estoqueMacaPodre = new MacaPodre[100];
  
      for (int i = 0; i < 100; i++) {
        estoqueMacaPodre[i] = new MacaPodre();
      }
  
  
  Mercadorias[] estoqueOssos = new OssoBoi[100];

    for (int i = 0; i < 100; i++) {
        estoqueOssos[i] = new OssoBoi();
    }
  
  Mercadorias[] estoquePatas = new PataGoblin[100];
  
    for (int i = 0; i < 100; i++) {
      estoquePatas[i] = new PataGoblin();
    }
  
    Mercadorias[] estoquePresas = new PresasLobo[100];
  
    for (int i = 0; i < 100; i++) {
      estoquePresas[i] = new PresasLobo();
    }

    Cupom MacaEnv5 = new Cupom(5, estoqueMacaEnv[1]);
    Cupom MacaEnv50 = new Cupom(50, estoqueMacaEnv[1]);
    Cupom Osso5 = new Cupom(5, estoqueOssos[1]);
    Cupom Osso40 = new Cupom(40, estoqueOssos[1]);
    Cupom Pata9 = new Cupom(9, estoquePatas[1]);
    Cupom Cabeca30 = new Cupom(30, estoqueCabecas[1]);
    Cupom Nenhum = new Cupom(0);

    Carrinho.adicionarItem(estoquePresas[1], 3, Nenhum);
    Carrinho.adicionarItem(estoqueMacaEnv[1], 5, MacaEnv5);
    Carrinho.adicionarItem(estoqueCabecas[1], 9, Nenhum);
    Carrinho.verCarrinho();
    Carrinho.calcular();
    Carrinho.fecharCompra();

    Carrinho.adicionarItem(estoqueOssos[1], 15, Osso5);
    Carrinho.adicionarItem(estoquePatas[1], 6, Pata9);
    Carrinho.adicionarItem(estoqueMacaPodre[1], 11, Nenhum);
    Carrinho.adicionarItem(estoqueMacaEnv[1], 8, Nenhum);
    Carrinho.verCarrinho();
    Carrinho.calcular();
    Carrinho.fecharCompra();

    Carrinho.adicionarItem(estoqueOssos[1], 2, Osso40);
    Carrinho.adicionarItem(estoquePatas[1], 3, Nenhum);
    Carrinho.adicionarItem(estoqueCabecas[1], 5, Cabeca30);
    Carrinho.adicionarItem(estoquePresas[1], 4, Nenhum);
    Carrinho.adicionarItem(estoqueMacaEnv[1], 15, MacaEnv50);
    Carrinho.adicionarItem(estoqueMacaPodre[1], 11, Nenhum);
    Carrinho.verCarrinho();
    Carrinho.calcular();
    Carrinho.fecharCompra();
  }
}