using ASP.NET_MVC.Cors;
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
        // GET: Pessoa
        //[AllowCrossSite]
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
            return Json(JsonRequestBehavior.AllowGet);
        }

        // POST: Pessoa/Create
        //[HttpPost]
        public JsonResult Create(FormCollection collection)
        {
            var nome = collection["Nome"].ToString();
            var endereco = collection["Endereco"].ToString().Split(',');
            var cidade = collection["Cidade"].ToString().Split(',');
            //var contato = collection["Contato"].ToString().Split(',');
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}

            return Json(JsonRequestBehavior.AllowGet);
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

        // POST: Pessoa/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
