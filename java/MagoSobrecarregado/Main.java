class Main {
  public static void main(String[] args) {
    
    PedraFogo pFogo = new PedraFogo();
    PedraTerra pTerra = new PedraTerra();
    PedraAr pAr = new PedraAr();
    PedraAgua pAgua = new PedraAgua();

    Cajado bastaoDasEras = new Cajado();

    System.out.println(bastaoDasEras.executarPoderElemental(pFogo, pFogo));
    System.out.println(bastaoDasEras.executarPoderElemental(pAr, pAr));
    System.out.println(bastaoDasEras.executarPoderElemental(pAgua, pAgua));
    System.out.println(bastaoDasEras.executarPoderElemental(pTerra, pTerra));
    System.out.println(bastaoDasEras.executarPoderElemental(pFogo, pTerra));
    System.out.println(bastaoDasEras.executarPoderElemental(pFogo, pAr));
    System.out.println(bastaoDasEras.executarPoderElemental(pAgua, pTerra));
    System.out.println(bastaoDasEras.executarPoderElemental(pAgua, pAr));
    System.out.println(bastaoDasEras.executarPoderElemental(pFogo, pAgua));
  }
}