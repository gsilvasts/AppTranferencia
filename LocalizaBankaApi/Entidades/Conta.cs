using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizaBankApi.Entidades
{
    public class Conta
    {
        public int Id { get; set; }
        public TipoConta TipoConta { get; set; }
        public double Saldo { get; set; }
        public double Credito { get; set; }
        public string Nome { get; set; }

        public Conta()
        {

        }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo -valorSaque < (this.Credito * -1))
            {          
                return false;
            }

            this.Saldo -= valorSaque;
            
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

    }
}
