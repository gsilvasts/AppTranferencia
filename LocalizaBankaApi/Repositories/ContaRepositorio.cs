using LocalizaBankaApi.Infra.Config;
using LocalizaBankApi.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizaBankaApi.Repositories
{
    public class ContaRepositorio
    {
        private ContextBase _context;

        public ContaRepositorio(ContextBase context)
        {
            _context = context;
        }
        public void AdicionarConta(Conta conta)
        {
            _context.Add(conta);
            _context.SaveChanges();
        }

        public IList<Conta> ListarContas()
        {
            var contas = _context.Contas.ToList();
            return contas;
        }

        public void Depositar(int id, double valorDeposito)
        {
            var conta = _context.Contas.Find(id);
            conta.Depositar(valorDeposito);
            _context.Update(conta);
            _context.SaveChanges();
        }

        public bool Sacar(int id, double valorSaque)
        {
            var conta = _context.Contas.Find(id);
            if (conta.Sacar(valorSaque))
            {
                return false;
            };

            _context.Update(conta);
            _context.SaveChanges();
            return true;
        }

        public void Transferir(int id, double valorTransferencia, Conta contaDestino)
        {
             var conta = _context.Contas.Find(id);

            if (conta.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
            _context.Update(contaDestino);
            _context.SaveChanges();
        }
    }
}
