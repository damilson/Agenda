using Negocio.Data;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Util;
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

            return PVM;
        }

        // GET: api/Pessoa/5
        public PessoaViewModel Get(int id)
        {
            var PVM = new PessoaViewModel();
            var pessoa = _pessoaNegocio.Buscar(id);

            var Pessoa = new Pessoa()
            {
                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Contatos = pessoa.Contatos.Select(contato => new Contato
                {
                    ContatoId = contato.ContatoId,
                    Nome = contato.Nome,
                    Agrupador = contato.Agrupador,
                    TipoContato = contato.TipoContato
                }).ToList(),
                Enderecos = pessoa.Enderecos.Select(endereco => new Endereco
                {
                    EnderecoId = endereco.EnderecoId,
                    EnderecoNome = endereco.EnderecoNome,
                    Logradouro = new Logradouro
                    {
                        Bairro = endereco.Logradouro.Bairro,
                        Cidade = endereco.Logradouro.Cidade,
                        Complemento = endereco.Logradouro.Complemento,
                        Estado = endereco.Logradouro.Estado,
                        Numero = endereco.Logradouro.Numero,
                        Tipo = endereco.Logradouro.Tipo,
                        LogradouroId = endereco.LogradouroId
                    },
                    LogradouroId = endereco.LogradouroId
                }).ToList()

            };

            PVM.Pessoa = Pessoa;
            return PVM;
        }

        // POST: api/Pessoa
        public HttpResponseMessage Post([FromBody]FormDataCollection collection)
        {
            var nome = collection.Get("Nome");
            var endereco = collection.Get("Endereco").Split(',');
            var cidade = collection.Get("Cidade").Split(',');
            var numero = collection.Get("Numero").Split(',');
            var estado = collection.Get("Estado").Split(',');
            var tipo = collection.Get("Tipo").Split(',');
            var bairro = collection.Get("Bairro").Split(',');
            var complemento = collection.Get("Complemento").Split(',');

            var listaEndereco = new List<EnderecoDTO>();

            for (int i = 0; i < endereco.Length; i++)
            {
                listaEndereco.Add(new EnderecoDTO
                {
                    EnderecoNome = endereco[i],
                    Logradouro = new LogradouroDTO
                    {
                        Numero = int.Parse(numero[i]),
                        Cidade = cidade[i],
                        Bairro = bairro[i],
                        Estado = estado[i],
                        Tipo = (TipoLogradouro)int.Parse(tipo[i]),
                        Complemento = complemento[i]
                    }
                });
            }

            var pessoa = new PessoaDTO()
            {
                Nome = nome,
                Enderecos = listaEndereco
            };

            try
            {
                _pessoaNegocio.Cadastrar(pessoa);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var Data = new
            {
                Mensagem = "Sucesso ao cadastrar"
            };
            return Request.CreateResponse(HttpStatusCode.Accepted, Data);
        }

        // PUT: api/Pessoa/5
        public HttpResponseMessage Put(int id, [FromBody]FormDataCollection collection)
        {
            var pessoaId = collection.Get("Id");
            var nome = collection.Get("Nome");
            var enderecoId = collection.Get("EnderecoId").Split(',');
            var endereco = collection.Get("Endereco").Split(',');
            var logradouroId = collection.Get("LogradouroId").Split(',');
            var cidade = collection.Get("Cidade").Split(',');
            var numero = collection.Get("Numero").Split(',');
            var estado = collection.Get("Estado").Split(',');
            var tipo = collection.Get("Tipo").Split(',');
            var bairro = collection.Get("Bairro").Split(',');
            var complemento = collection.Get("Complemento").Split(',');

            var listaEndereco = new List<EnderecoDTO>();

            for (int i = 0; i < endereco.Length; i++)
            {

                listaEndereco.Add(new EnderecoDTO
                {
                    EnderecoId = enderecoId[i].Equals("") ? 0 : int.Parse(enderecoId[i]),
                    EnderecoNome = endereco[i],
                    Logradouro = new LogradouroDTO
                    {
                        LogradouroId = logradouroId[i].Equals("") ? 0 : int.Parse(logradouroId[i]),
                        Numero = int.Parse(numero[i]),
                        Cidade = cidade[i],
                        Bairro = bairro[i],
                        Estado = estado[i],
                        Tipo = (TipoLogradouro)int.Parse(tipo[i]),
                        Complemento = complemento[i],
                        EnderecoId = enderecoId[i].Equals("") ? 0 : int.Parse(enderecoId[i])
                    },
                    PessoaId = int.Parse(pessoaId.ToString()),
                    LogradouroId = logradouroId[i].Equals("") ? 0 : int.Parse(logradouroId[i]),

                });
            }

            var pessoa = new PessoaDTO()
            {
                PessoaId = int.Parse(collection.Get("Id")),
                Nome = nome,
                Enderecos = listaEndereco
            };

            try
            {
                _pessoaNegocio.Editar(pessoa);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            var Data = new
            {
                Mensagem = "Sucesso ao editar"
            };
            return Request.CreateResponse(HttpStatusCode.Accepted, Data);
        }

        // DELETE: api/Pessoa/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
            _pessoaNegocio.Deletar(id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            var Data = new
            {
                Mensagem = "Sucesso ao deletar"
            };
            return Request.CreateResponse(HttpStatusCode.Accepted, Data);
        }
    }
}
