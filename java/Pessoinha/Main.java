class Main {
  public static void main(String[] args) {

    Pessoa pessoa = new Pessoa();
    
    pessoa.setNome("Cleiton");
    pessoa.setIdade(21);

    pessoa.dizerNome(pessoa.getNome());
    pessoa.dizerIdade(pessoa.getIdade());
  }
}