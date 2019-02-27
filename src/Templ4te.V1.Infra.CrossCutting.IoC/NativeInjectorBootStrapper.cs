﻿using Microsoft.Extensions.DependencyInjection;
using Templ4te.V1.Data;
using Templ4te.V1.Data.Context;
using Templ4te.V1.Data.UoW;
using Templ4te.V1.Domain.Interfaces;
using Templ4te.V1.Domain.Usuarios.Interfaces;
using Templ4te.V1.Domain.Usuarios.Servicos;

namespace Templ4te.V1.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Application

            #endregion


            #region Domain
            services.AddScoped<IUsuarioService, UsuarioServico>();

            #endregion

            #region Infra
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ContextEFC>();
            #endregion
        }
    }
}
