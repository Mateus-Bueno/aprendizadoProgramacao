using Estacionamento.Services;
using Estacionamento.Exceptions;

namespace EstacionamentoTestes;

public class EstacionamentoTests
{

    private EstacionamentoImp _es = new EstacionamentoImp(30, 15);


    [Theory]
    [InlineData("xyz5678\ne1")]
    [InlineData("MNO9876\nE3")]
    [InlineData("FLA3B74\ne2")]
    [InlineData("abc1d23\nE4")]
    public void AdicionarVeiculo_Sucesso(string input)
    {
        // Arrange
        var entrada = new StringReader(input);
        Console.SetIn(entrada);
    
        // Act      
        // Assert

        Assert.True(_es.AdicionarVeiculo());
    }

    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    public void AdicionarVeiculo_Erro_PlacaVazia(string input)
    {
        // Arrange

        var entrada = new StringReader(input);
        Console.SetIn(entrada);

        // Act
        // Assert

        Assert.Throws<PlacaVaziaException>(() => _es.AdicionarVeiculo());
    }

    [Theory]
    [InlineData("aaaaa")]
    [InlineData("ggi314@")]
    public void AdicionarVeiculo_Erro_PlacaInvalida(string input)
    {
        // Arrange
        var entrada = new StringReader(input);
        Console.SetIn(entrada);
    
        // Act      
        // Assert

        Assert.Throws<PlacaInvalidaException>(() => _es.AdicionarVeiculo());
    }

    [Theory]
    [InlineData("FLA3B74\nFLA3B74")]
    [InlineData("abc1d23\nabc1d23")]
    public void AdicionarVeiculo_Erro_CarroJaEstacionado(string input)
    {
        // Arrange
        var entrada = new StringReader(input);
        Console.SetIn(entrada);
    
        // Act
        // Assert

        Assert.False(_es.AdicionarVeiculo());
    }

    [Theory]
    [InlineData("abc1234\nabc1234\n1\n1")]
    [InlineData("xyz9w87\nxyz9w87\n1\n1")]
    public void RemoverVeiculo_Sucesso(string placa)
    {
        //Arrange
        var entrada = new StringReader(placa);
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();

         //Act
         //Assert
        Assert.True(_es.RemoverVeiculo());

    }

    [Fact]
    public void RemoverVeiculo_Erro_FormatException()
    {
        //Arrange
        var entrada = new StringReader("abc1234\nabc1234\nq");
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();

        //Act
        //Assert
        Assert.Throws<FormatException>(() => _es.RemoverVeiculo());
    }

    [Fact]
    public void RemoverVeiculo_Erro_PlacaVazia()
    {
        //Arrange
        var entrada = new StringReader("abc1234\n    ");
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();

        //Act
        //Assert
        Assert.Throws<PlacaVaziaException>(() => _es.RemoverVeiculo());
    }

    [Fact]
    public void RemoverVeiculo_Erro_PlacaInvalida()
    {
        //Arrange
        var entrada = new StringReader("xyz9w87\naaabbbb");
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();

        //Act
        //Assert
        Assert.Throws<PlacaInvalidaException>(() => _es.RemoverVeiculo());
    }

    [Fact]
    public void RemoverVeiculo_Falha()
    {
        //Arrange
        var entrada = new StringReader("xyz9w87\nabc1234");
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();

         //Act
         //Assert
        Assert.False(_es.RemoverVeiculo());

    }

    [Fact]
    public void ListarVeiculos()
    {
        // Arrange
        var entrada = new StringReader("xyz5678\ne1\nMNO9876\ne2");
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();
        _es.AdicionarVeiculo();

        var saida = new StringWriter();
        Console.SetOut(saida);

        var saidaEsperada =  @"Bloco E1
Os veículos estacionados são:
--------------------------------
XYZ-5678

Pressione qualquer tecla para continuar
Bloco E2
Os veículos estacionados são:
--------------------------------
MNO-9876

Pressione qualquer tecla para continuar
Bloco E3
--------------------------------
Não há veículos estacionados.

Pressione qualquer tecla para continuar
Bloco E4
--------------------------------
Não há veículos estacionados.

Pressione qualquer tecla para continuar
";
    
        // Act

        _es.ListarVeiculos();
        
    
        // Assert

        Assert.Equal(saidaEsperada, saida.ToString());
    }
    
}