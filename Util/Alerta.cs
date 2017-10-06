using System;
using System.Web.Mvc;

namespace Util
{
    public class Alerta
    {
        public static JsonResult CriaMensagemErro(Exception ex)
        {
            var mensagem = ex.Message;

            return CriaMensagemErro(mensagem);
        }

        public static JsonResult CriaMensagemErro(ArgumentException ex)
        {
            var mensagem = ex.Message;
            if (!string.IsNullOrEmpty(ex.ParamName))
            {
                mensagem = ex.Message.Substring(0, ex.Message.LastIndexOf("\r\n"));
            }

            return CriaMensagemErro(mensagem, ex.ParamName);
        }

        public static JsonResult CriaMensagemErro(string mensagem, object data = null)
        {
            var retorno = new
            {
                Sucesso = false,
                Data = data,
                Mensagem = mensagem
            };

            return new JsonResult { Data = retorno };
        }

        public static JsonResult CriaMensagemSucesso(string mensagem)
        {
            var retorno = new
            {
                Sucesso = true,
                Mensagem = mensagem
            };

            return new JsonResult { Data = retorno };
        }

        public static JsonResult CriaMensagemSucesso(string mensagem, object data = null)
        {
            var retorno = new
            {
                Sucesso = true,
                Data = data, 
                Mensagem = mensagem
            };
            return new JsonResult { Data = retorno };
        }
    }
}
