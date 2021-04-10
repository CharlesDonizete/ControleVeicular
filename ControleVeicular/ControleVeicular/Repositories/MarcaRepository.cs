using ControleVeicular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVeicular.Repositories
{
    public interface IMarcaRepository
    {
        void SaveMarcas(List<MarcaJason> marcaJasons);
        IList<Marca> GetMarcas();
        Marca GetMarca(int Id);
    }

    public class MarcaRepository : BaseRepository<Marca>,  IMarcaRepository
    {
        public MarcaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Marca> GetMarcas()
        {
            return dbSet.ToList();
        }

        public Marca GetMarca(int Id)
        {
            return dbSet.Where(m => m.Id == Id).SingleOrDefault();
        }

        public void SaveMarcas(List<MarcaJason> marcaJasons)
        {
            foreach (var marcaJason in marcaJasons)
            {
                
                if (!dbSet.Where(m => m.Descricao == marcaJason.Nome).Any())
                {
                    dbSet.Add(new Marca(marcaJason.Nome));
                }                
            }

            contexto.SaveChanges();
        }       
    }
    public class MarcaJason
    {
        public string Nome { get; set; }
    }
}
