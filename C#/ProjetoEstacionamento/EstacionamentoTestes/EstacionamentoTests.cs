using Estacionamento.Services;

namespace EstacionamentoTestes;

public class EstacionamentoTests
{

    private EstacionamentoImp _es = new EstacionamentoImp(30, 15);


    [Theory]
    [InlineData("xyz5678")]
    [InlineData("MNO9876")]
    [InlineData("FLA3B74")]
    [InlineData("abc1d23")]
    public void AdicionarVeiculo_Sucesso(string placa)
    {
        // Given
        var saida = new StringWriter();
        Console.SetOut(saida);

        var entrada = new StringReader(placa);
        Console.SetIn(entrada);

        var saidaEsperada =  @"------------------------------------------------
Digite a placa do veículo para estacionar:
------------------------------------------------
Veículo adicionado com sucesso!
";
    
        // When

        _es.AdicionarVeiculo();
        
    
        // Then

        Assert.Equal(saidaEsperada, saida.ToString());
    }

    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    public void AdicionarVeiculo_Erro_PlacaVazia(string placa)
    {
        // Given
        var saida = new StringWriter();
        Console.SetOut(saida);

        var entrada = new StringReader(placa);
        Console.SetIn(entrada);

        var saidaEsperada =  @"------------------------------------------------
Digite a placa do veículo para estacionar:
------------------------------------------------
Nenhuma placa inserida. Por favor tente novamente
";
    
        // When

        _es.AdicionarVeiculo();
        
    
        // Then

        Assert.Equal(saidaEsperada, saida.ToString());
    }

    [Theory]
    [InlineData("aaaaa")]
    [InlineData("ggi314@")]
    public void AdicionarVeiculo_Erro_PlacaInvalida(string placa)
    {
        // Given
        var saida = new StringWriter();
        Console.SetOut(saida);

        var entrada = new StringReader(placa);
        Console.SetIn(entrada);

        var saidaEsperada =  @"------------------------------------------------
Digite a placa do veículo para estacionar:
------------------------------------------------
Formato de placa inválido.
Certifique-se de atender ao padrão Mercosul ou Nacional Única
";
    
        // When

        _es.AdicionarVeiculo();
        
    
        // Then

        Assert.Equal(saidaEsperada, saida.ToString());
    }

    [Theory]
    [InlineData("FLA3B74\nFLA3B74")]
    [InlineData("abc1d23\nabc1d23")]
    public void AdicionarVeiculo_Erro_CarroJaEstacionado(string placa)
    {
        // Given
        var entrada = new StringReader(placa);
        Console.SetIn(entrada);

        _es.AdicionarVeiculo();

        var saida = new StringWriter();
        Console.SetOut(saida);

        var saidaEsperada =  @"------------------------------------------------
Digite a placa do veículo para estacionar:
------------------------------------------------
Este carro já se encontra no estacionamento.
";
    
        // When

        _es.AdicionarVeiculo();
        
    
        // Then

        Assert.Equal(saidaEsperada, saida.ToString());
    }

    [Theory]
    [InlineData("abc1234\nabc1234\n1\n1")]
    [InlineData("xyz9w87\nxyz9w87\n1\n1")]
    public void RemoverVeiculo_Sucesso(string placa)
    {
        //arrange
        var entrada = new StringReader(placa);
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();

         //act
         //assert
        Assert.True(_es.RemoverVeiculo());

    }

    [Theory]
    [InlineData("abc1234\n    ")]
    [InlineData("abc1234\nabc1234\nq")]
    [InlineData("xyz9w87\nabc1234")]
    public void RemoverVeiculo_Falha(string placa)
    {
        //arrange
        var entrada = new StringReader(placa);
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();

         //act
         //assert
        Assert.False(_es.RemoverVeiculo());

    }

    [Fact]
    public void ListarVeiculos()
    {
        // Given
        var entrada = new StringReader("xyz5678\nMNO9876");
        Console.SetIn(entrada);
        _es.AdicionarVeiculo();
        _es.AdicionarVeiculo();

        var saida = new StringWriter();
        Console.SetOut(saida);

        var saidaEsperada =  @"--------------------------------
Os veículos estacionados são:
XYZ-5678
MNO-9876
--------------------------------
";
    
        // When

        _es.ListarVeiculos();
        
    
        // Then

        Assert.Equal(saidaEsperada, saida.ToString());
    }
    
}