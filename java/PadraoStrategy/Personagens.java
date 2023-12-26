//A classe mãe "personagens" define um método que pode ser aplicado a todos os objetos criados a partir dela.

public class Personagens {

  public static void executarAtaque(Personagens character, Equipamento equipment){
      System.out.println(character.getClass().getSimpleName() + " Atacou");
      equipment.atacarEquipamento();
      System.out.println();
    }
}