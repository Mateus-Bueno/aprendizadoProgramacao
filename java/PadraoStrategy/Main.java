class Main {
  public static void main(String[] args) {


    //São criados objetos que irão definir o equipamento de cada personagem
    Equipamento armaBobo = new Equipamento();
    Equipamento armaRainha = new Equipamento();
    Equipamento armaRei = new Equipamento();
    Equipamento armaTroll = new Equipamento();

    //São criados objetos para cada personagem
    Personagens bobo = new Bobo();
    Personagens rainha = new Rainha();
    Personagens rei = new Rei();
    Personagens troll = new Troll();

    //Teste das funcionalidades, sendo 2 testes para cada personagem
    armaBobo.setArma(new Faca());
    Personagens.executarAtaque(bobo, armaBobo);
    armaBobo.setArma(new Machado());
    Personagens.executarAtaque(bobo, armaBobo);

    armaRainha.setArma(new Espada());
    Personagens.executarAtaque(rainha, armaRainha);
    armaRainha.setArma(new Cajado());
    Personagens.executarAtaque(rainha, armaRainha);

    armaRei.setArma(new Espada());
    Personagens.executarAtaque(rei, armaRei);
    armaRei.setArma(new Machado());
    Personagens.executarAtaque(rei, armaRei);

    armaTroll.setArma(new Cajado());
    Personagens.executarAtaque(troll, armaTroll);
    armaTroll.setArma(new Machado());
    Personagens.executarAtaque(troll, armaTroll);
    
  }
}