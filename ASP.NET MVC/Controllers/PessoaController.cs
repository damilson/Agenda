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

        public PessoaController(IPessoaNegocio pessoaNegocio)
        {
            _pessoaNegocio = pessoaNegocio;
        }

        public JsonResult Index()
        {
            var listaPessoasDTO = _pessoaNegocio.Listar();
            var PVM = new PessoaViewModel();

            PVM.Pessoas = listaPessoasDTO.Select(pessoa => new Pessoa
            {
                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Contatos = pessoa.Contatos.Where(x => x.PessoaId == pessoa.PessoaId).Select(contato => new Contato
                {
                    Nome = contato.Nome,
                    TipoContato = contato.TipoContato,
                    Agrupador = contato.Agrupador,
                    ContatoId = contato.ContatoId
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

            var pessoa = RetornaPessoaDTO(collection);

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

        // GET: Pessoa/Edit/5
        public JsonResult Edit(int id)
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public JsonResult Edit(int id, FormCollection collection)
        {
            var pessoa = RetornaPessoaDTO(collection);
            pessoa.PessoaId = id;

            try
            {
                _pessoaNegocio.Editar(pessoa);
            }catch(Exception ex)
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

        private PessoaDTO RetornaPessoaDTO(FormCollection collection)
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

            return pessoa;
        }
    }
}
