using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Model;
using Web_API.ViewModels;

namespace Web_API.Controllers
{
    public class PessoaController : ApiController
    {
        private readonly IPessoaNegocio _pessoaNegocio;
        private readonly IEnderecoNegocio _enderecoNegocio;

        public PessoaController(IPessoaNegocio pessoaNegocio, IEnderecoNegocio enderecoNegocio)
        {
            _pessoaNegocio = pessoaNegocio;
            _enderecoNegocio = enderecoNegocio;
        }

        // GET: api/Pessoa
        public PessoaViewModel Get()
        {
            var listaPessoasDTO = _pessoaNegocio.Listar();
            var PVM = new PessoaViewModel();

            PVM.Pessoas = listaPessoasDTO.Select(pessoa => new Pessoa
            {
                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Contatos = pessoa.Contatos.Where(x => x.PessoaId == pessoa.PessoaId).OrderBy(x => x.Agrupador).Select(contato => new Contato
                {
                    Nome = contato.Nome,
                    TipoContato = contato.TipoContato,
                    Agrupador = contato.Agrupador,
                    ContatoId = contato.ContatoId,
                    Tipo = contato.Tipo
                }).ToList(),
                Enderecos = pessoa.Enderecos.Where(x => x.PessoaId == pessoa.PessoaId).Select(endereco => new Endereco
                {
                    EnderecoId = endereco.EnderecoId,
                    EnderecoNome = endereco.EnderecoNome,
                    LogradouroId = endereco.LogradouroId,
                    Logradouro = new Logradouro
                    {
                        LogradouroId = endereco.Logradouro.LogradouroId,
                        Numero = endereco.Logradouro.Numero,
                        Bairro = endereco.Logradouro.Bairro,
                        Cidade = endereco.Logradouro.Cidade,
                        Complemento = endereco.Logradouro.Complemento,
                        Estado = endereco.Logradouro.Estado,
                        Tipo = endereco.Logradouro.Tipo
                    }
                }).ToList()
            }).ToList();

            //return new JsonResult { Data = PVM, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return PVM;
        }

        // GET: api/Pessoa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pessoa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pessoa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pessoa/5
        public void Delete(int id)
        {
        }
    }
}
