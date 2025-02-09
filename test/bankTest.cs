using System;
using Xunit;

/// <summary>
/// The ContaCorrenteTests class contains unit tests for the ContaCorrente class.
/// </summary>
public class ContaCorrenteTests
{
    /// <summary>
    /// Tests the AbrirConta method to ensure it activates the account.
    /// </summary>
    [Fact]
    public void AbrirConta_DeveAtivarConta()
    {
        var conta = new ContaCorrente(12345, "João Silva");
        conta.AbrirConta();
        Assert.True(conta.Ativa);
    }

    /// <summary>
    /// Tests the EncerrarConta method to ensure it deactivates the account when the balance is zero.
    /// </summary>
    [Fact]
    public void EncerrarConta_DeveDesativarConta_QuandoSaldoZerado()
    {
        var conta = new ContaCorrente(12345, "João Silva");
        conta.AbrirConta();
        conta.EncerrarConta();
        Assert.False(conta.Ativa);
    }

    /// <summary>
    /// Tests the ConcederCredito method to ensure it increases the balance when the account is active.
    /// </summary>
    [Fact]
    public void ConcederCredito_DeveAumentarSaldo_QuandoContaAtiva()
    {
        var conta = new ContaCorrente(12345, "João Silva");
        conta.AbrirConta();
        conta.ConcederCredito(1000);
        Assert.Equal(1000, conta.Saldo);
    }

    /// <summary>
    /// Tests the Debitar method to ensure it decreases the balance when the account is active and has sufficient balance.
    /// </summary>
    [Fact]
    public void Debitar_DeveDiminuirSaldo_QuandoContaAtivaESaldoSuficiente()
    {
        var conta = new ContaCorrente(12345, "João Silva");
        conta.AbrirConta();
        conta.ConcederCredito(1000);
        conta.Debitar(200);
        Assert.Equal(800, conta.Saldo);
    }

    /// <summary>
    /// Tests the Transferir method to ensure it transfers the amount to another account when the account is active and has sufficient balance.
    /// </summary>
    [Fact]
    public void Transferir_DeveTransferirValorParaOutraConta_QuandoContaAtivaESaldoSuficiente()
    {
        var contaOrigem = new ContaCorrente(12345, "João Silva");
        var contaDestino = new ContaCorrente(67890, "Maria Souza");
        contaOrigem.AbrirConta();
        contaDestino.AbrirConta();
        contaOrigem.ConcederCredito(1000);
        contaOrigem.Transferir(contaDestino, 500);
        Assert.Equal(500, contaOrigem.Saldo);
        Assert.Equal(500, contaDestino.Saldo);
    }

    /// <summary>
    /// Tests the ObterSaldo method to ensure it returns the current balance.
    /// </summary>
    [Fact]
    public void ObterSaldo_DeveRetornarSaldoAtual()
    {
        var conta = new ContaCorrente(12345, "João Silva");
        conta.AbrirConta();
        conta.ConcederCredito(1000);
        Assert.Equal(1000, conta.ObterSaldo());
    }

    /// <summary>
    /// Tests the CalcularJuros method to ensure it returns the interest amount when the account is active.
    /// </summary>
    [Fact]
    public void CalcularJuros_DeveRetornarValorDosJuros_QuandoContaAtiva()
    {
        var conta = new ContaCorrente(12345, "João Silva");
        conta.AbrirConta();
        conta.ConcederCredito(1000);
        var juros = conta.CalcularJuros(0.05m);
        Assert.Equal(50, juros);
    }
}