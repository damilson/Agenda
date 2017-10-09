using ASP.NET_MVC.Model;
using ASP.NET_MVC.ViewModels;
using Negocio.Data;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Util;

namespace ASP.NET_MVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaNegocio _pessoaNegocio;
        private readonly IEnderecoNegocio _enderecoNegocio;

        public PessoaController(IPessoaNegocio pessoaNegocio, IEnderecoNegocio enderecoNegocio)
        {
            _pessoaNegocio = pessoaNegocio;
            _enderecoNegocio = enderecoNegocio;
        }

        public JsonResult Index()
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

            return new JsonResult { Data = PVM, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: Pessoa/Details/5
        public JsonResult Details(int id)
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
            return new JsonResult { Data = PVM, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult Create(FormCollection collection)
        {
            var nome = collection["Nome"].ToString();
            var endereco = collection["Endereco"].ToString().Split(',');
            var cidade = collection["Cidade"].ToString().Split(',');
            var numero = collection["Numero"].ToString().Split(',');
            var estado = collection["Estado"].ToString().Split(',');
            var tipo = collection["Tipo"].ToString().Split(',');
            var bairro = collection["Bairro"].ToString().Split(',');
            var complemento = collection["Complemento"].ToString().Split(',');

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
            catch
            {
                Alerta.CriaMensagemErro("Erro ao cadastrar.");
            }
            return Alerta.CriaMensagemSucesso("Cadastrado com sucesso");

        }

        // POST: Pessoa/Edit/5
        //[HttpPost]
        public JsonResult Edit(FormCollection collection)
        {
            var pessoaId = collection["Id"].ToString();
            var nome = collection["Nome"].ToString();
            var enderecoId = collection["EnderecoId"].ToString().Split(',');
            var endereco = collection["Endereco"].ToString().Split(',');
            var logradouroId = collection["LogradouroId"].ToString().Split(',');
            var cidade = collection["Cidade"].ToString().Split(',');
            var numero = collection["Numero"].ToString().Split(',');
            var estado = collection["Estado"].ToString().Split(',');
            var tipo = collection["Tipo"].ToString().Split(',');
            var bairro = collection["Bairro"].ToString().Split(',');
            var complemento = collection["Complemento"].ToString().Split(',');

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
                PessoaId = int.Parse(collection["Id"].ToString()),
                Nome = nome,
                Enderecos = listaEndereco
            };

            try
            {
                _pessoaNegocio.Editar(pessoa);
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro(ex);
            }

            return Alerta.CriaMensagemSucesso("Sucesso ao editar.");
        }

        // GET: Pessoa/Delete/5
        public JsonResult Delete(int id)
        {
            try
            {
                _pessoaNegocio.Deletar(id);
            }
            catch (Exception)
            {
                Alerta.CriaMensagemErro("Houve um problema ao excluir a pessoa");
            }
            return Alerta.CriaMensagemSucesso("Sucesso ao excluir pessoa.");
        }

    }
}
