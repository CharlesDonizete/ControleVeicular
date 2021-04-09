using ControleVeicular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVeicular.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly ApplicationContext contexto;

        public MarcaRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public IList<Marca> GetMarcas()
        {
            return contexto.Set<Marca>().ToList();
        }

        public void SaveMarcas(List<MarcaJason> marcaJasons)
        {
            foreach (var marcaJason in marcaJasons)
            {
                contexto.Set<Marca>().Add(new Marca(marcaJason.Nome));
            }

            contexto.SaveChanges();
        }
    }
    public class MarcaJason
    {
        public string Nome { get; set; }
    }
}
