using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agenda.Model;
using Agenda.Repositorio;
using Negocio.DTO;

namespace Negocio.Negocio
{
    public class PessoaServico : IPessoaServico
    {
        private readonly IRepositorio _repositorio;

        public PessoaServico()
        {
            _repositorio = new Repositorio();
        }
        public List<PessoaDTO> Listar()
        {
            var pessoasLista = new List<PessoaDTO>();

            var pessoas = _repositorio.List<Pessoa>().ToList();

            foreach (var pessoa in pessoas)
            {
                var contatosLista = new List<ContatoDTO>();
                var enderecosLista = new List<EnderecoDTO>();
                foreach (var endereco in pessoa.EnderecoLista)
                {
                    enderecosLista.Add(new EnderecoDTO()
                    {
                        EnderecoDTOId = endereco.EnderecoId,
                        EnderecoNome = endereco.EnderecoNome,
                        LogradouroId = endereco.LogradouroId,
                        PessoaId = pessoa.PessoaId
                    });
                }
                foreach (var contato in pessoa.ListaContatos)
                {
                    contatosLista.Add(new ContatoDTO()
                    {
                        PessoaId = contato.PessoaId,
                        Celular = contato.Celular,
                        ContatoDTOId = contato.ContatoId,
                        Email = contato.Email,
                        IM = contato.IM,
                        Site = contato.Site,
                        TelefoneComercial = contato.TelefoneComercial,
                        TelefoneResidencial = contato.TelefoneResidencial,
                        TipoContato = contato.TipoContato
                    });
                }
                pessoasLista.Add(new PessoaDTO()
                {
                    PessoaDTOId = pessoa.PessoaId,
                    Nome = pessoa.Nome,
                    EnderecoLista = enderecosLista,
                    ListaContatos = contatosLista,
                    });
            }

            return pessoasLista;
        }
    }
}