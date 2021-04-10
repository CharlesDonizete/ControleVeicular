using ControleVeicular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVeicular.Repositories
{
    public interface IModeloRepository
    {
        void SaveModelos(List<ModeloJason> modeloJasons);
        IList<Modelo> GetModelos();
    }

    public class ModeloRepository : BaseRepository<Modelo>,  IModeloRepository
    {
        public ModeloRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Modelo> GetModelos()
        {
            return dbSet.ToList();
        }

        public void SaveModelos(List<ModeloJason> modeloJasons)
        {
            foreach (var modeloJason in modeloJasons)
            {
                
                if (!dbSet.Include(mo => mo.Marca).Where(m => m.Descricao == modeloJason.Nome).Any())
                {
                    
                    dbSet.Add(new Modelo(modeloJason.Nome,new Marca()));
                }                
            }

            contexto.SaveChanges();
        }
    }
    public class ModeloJason
    {
        public string Nome { get; set; }
        public int MarcaId { get; set; }
    }
}
