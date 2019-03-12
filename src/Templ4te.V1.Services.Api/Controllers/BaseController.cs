using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Templ4te.V1.Domain.Notifications;

namespace Templ4te.V1.Services.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected IDomainNotificationList Notifications;

        public BaseController(IDomainNotificationList notifications)
        {
            Notifications = notifications;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = Notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return !Notifications.GetNotifications().Any();
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(erroMsg, "ModelState");
            }
        }

        protected void NotificarErro(string mensagem, string sender = null, string codigo = null)
        {
            Notifications.Add(mensagem, sender, codigo);
        }
    }
}