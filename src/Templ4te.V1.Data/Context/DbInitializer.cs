using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Templ4te.V1.Domain.Usuarios;

namespace Templ4te.V1.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(ContextEFC context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Usuarios.Any())
            {
                return;   // DB has been seeded
            }

            var random = new Random();

            

            var usuarios = new Usuario[]
            {
            new Usuario("Adinan Silva dos Santos Junior"),
            new Usuario("Carlos Barros"),
            new Usuario("Dio Bueno"),
            new Usuario("Ronann Cruz"),
            new Usuario("Rafa Calegas"),
            new Usuario("Livia Varela"),
            new Usuario("Silvia Ocampos"),
            new Usuario("Fulano De Tal")
            };
            foreach (var u in usuarios)
            {
                var endereco = new Endereco("Rua SGI", random.Next(1, 1000).ToString(), "CSIS", "Parque dos Poderes", "79290000", "Campo Grande", "MS");
                u.AtribuirEndereco(endereco);

                context.Usuarios.Add(u);
            }
            context.SaveChanges();
        }
    }
}
