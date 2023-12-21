//chamando a função a partir da interface, o contexto consegue trabalhar com qualquer tipo de equipamento independente de sua classe e tipo

public class Equipamento {

  private Arma arma;

  public void setArma(Arma arma) {
      this.arma = arma;
  }
  
  public void atacarEquipamento() {
      arma.atacar();
    }
}