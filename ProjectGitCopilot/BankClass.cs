using System;

public class ContaCorrente
{
    public int Numero { get; private set; }
    public string Titular { get; private set; }
    public decimal Saldo { get; private set; }
    public bool Ativa { get; private set; }

    public ContaCorrente(int numero, string titular, decimal saldo = 0)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldo;
        Ativa = false;
    }

    public void AbrirConta()
    {
        Ativa = true;
        Console.WriteLine($"Conta {Numero} aberta com sucesso.");
    }

    public void EncerrarConta()
    {
        if (Saldo == 0)
        {
            Ativa = false;
            Console.WriteLine($"Conta {Numero} encerrada com sucesso.");
        }
        else
        {
            Console.WriteLine("A conta não pode ser encerrada. Saldo não zerado.");
        }
    }

    public void ConcederCredito(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do crédito deve ser positivo.");
            return;
        }

        if (Ativa)
        {
            Saldo += valor;
            Console.WriteLine($"Crédito de R${valor} concedido. Saldo atual: R${Saldo}.");
        }
        else
        {
            Console.WriteLine("A conta não está ativa. Não é possível conceder crédito.");
        }
    }

    public void Debitar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do débito deve ser positivo.");
            return;
        }

        if (Ativa && Saldo >= valor)
        {
            Saldo -= valor;
            Console.WriteLine($"Débito de R${valor} realizado. Saldo atual: R${Saldo}.");
        }
        else
        {
            Console.WriteLine("A conta não está ativa ou saldo insuficiente. Não é possível realizar o débito.");
        }
    }

    public void Transferir(ContaCorrente contaDestino, decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor da transferência deve ser positivo.");
            return;
        }

        if (Ativa && Saldo >= valor)
        {
            Saldo -= valor;
            contaDestino.ConcederCredito(valor);
            Console.WriteLine($"Transferência de R${valor} realizada para a conta {contaDestino.Numero}. Saldo atual: R${Saldo}.");
        }
        else
        {
            Console.WriteLine("A conta não está ativa ou saldo insuficiente. Não é possível realizar a transferência.");
        }
    }

    public decimal ObterSaldo()
    {
        return Saldo;
    }

    public decimal CalcularJuros(decimal taxa)
    {
        if (taxa < 0)
        {
            Console.WriteLine("A taxa de juros deve ser não negativa.");
            return 0;
        }

        if (Ativa)
        {
            decimal juros = Saldo * taxa;
            Console.WriteLine($"Juros calculados: R${juros}.");
            return juros;
        }
        else
        {
            Console.WriteLine("A conta não está ativa. Não é possível calcular juros.");
            return 0;
        }
    }
}