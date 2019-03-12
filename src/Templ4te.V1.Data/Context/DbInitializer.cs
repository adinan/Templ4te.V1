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
            new Usuario("Adinan Silva dos Santos Junior", "026.103.931-80"),
            new Usuario("Carlos Barros", "276.066.038-98"),
            new Usuario("Dio Bueno", "884.209.875-22"),
            new Usuario("Ronann Cruz", "884.209.875-22"),
            new Usuario("Rafa Calegas", "884.209.875-22"),
            new Usuario("Livia Varela", "884.209.875-22"),
            new Usuario("Silvia Ocampos", "884.209.875-22"),
            new Usuario("Fulano De Tal", "884.209.875-22")
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
