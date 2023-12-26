public class Cajado{

  public String executarPoderElemental(PedraFogo p1, PedraFogo p2){
    return "Poder de Fogo!";
  }
  
  public String executarPoderElemental(PedraAr p1, PedraAr p2){
    return "Poder de Ar!";
  }
  
  public String executarPoderElemental(PedraTerra p1, PedraTerra p2){
    return "Poder de Terra";
  }
  
  public String executarPoderElemental(PedraAgua p1, PedraAgua p2){
    return "Poder de Agua!";
  }
  
  public String executarPoderElemental(PedraFogo p1, PedraAr p2){
    return "Poder de Combustão!";
  }
  public String executarPoderElemental(PedraAr p1, PedraFogo p2){
    return "Poder de Combustão!";
  }

  
  public String executarPoderElemental(PedraFogo p1, PedraTerra p2){
    return "Poder de Magma!";
  }
  public String executarPoderElemental(PedraTerra p1, PedraFogo p2){
    return "Poder de Magma!";
  }
    
  public String executarPoderElemental(PedraAgua p1, PedraTerra p2){
    return "Poder de Planta!";
  }
  public String executarPoderElemental(PedraTerra p1, PedraAgua p2){
    return "Poder de Planta!";
  }

    
  public String executarPoderElemental(PedraAgua p1, PedraAr p2){
    return "Poder de Neve!";
  }
  public String executarPoderElemental(PedraAr p1, PedraAgua p2){
    return "Poder de Neve!";
  }

    
  public String executarPoderElemental(PedraAgua p1, PedraFogo p2){
    return "Poder não desbloqueado ainda!";
  }
  public String executarPoderElemental(PedraFogo p1, PedraAgua p2){
    return "Poder não desbloqueado ainda!";
  }
  
}