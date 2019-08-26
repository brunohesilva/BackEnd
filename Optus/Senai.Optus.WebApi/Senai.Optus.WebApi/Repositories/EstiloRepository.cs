using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepository
    {
        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {           
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }

        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Atualizar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);
                EstiloBuscado.Nome = estilo.Nome;
                ctx.Estilos.Update(EstiloBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
