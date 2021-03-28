using LocalizaBankaApi.Repositories;
using LocalizaBankApi.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocalizaBankaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private ContaRepositorio _contaRepositorio;

        public ContaController(ContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }

        //[AllowAnonymous]
        //[HttpGet("/api/ListarContas")]
        //public async Task<JsonResult> ListarContas()
        //{
        //    return Json(await _contaRepositorio.ListarContas());
        //}

        [HttpPost("/api/Depositar")]
        public void Depositar(int id, double valorDeposito)
        {
            _contaRepositorio.Depositar(id, valorDeposito);
        }

        [HttpPost("/api/Sacar")]
        public void Sacar(int id, double valorSaque)
        {
            _contaRepositorio.Sacar(id, valorSaque);
        }

        [HttpPost("/api/Transferir")]
        public void Transferir(int id, double valorTransferencia, Conta contaDeposito)
        {
            _contaRepositorio.Transferir(id, valorTransferencia, contaDeposito);
        }
    
    }
}
