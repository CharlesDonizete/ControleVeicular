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
        void SaveModelos(List<ModeloInicial> modeloJasons);
        IList<Modelo> GetModelos();
        Modelo GetModelo(int Id);
    }

    public class ModeloRepository : BaseRepository<Modelo>,  IModeloRepository
    {
        private readonly IMarcaRepository marcaRepository;

        public ModeloRepository(ApplicationContext contexto, IMarcaRepository marcaRepository) : base(contexto)
        {
            this.marcaRepository = marcaRepository;
        }

        public Modelo GetModelo(int Id)
        {
            return dbSet.Where(m => m.Id == Id).SingleOrDefault();
        }

        public IList<Modelo> GetModelos()
        {
            return dbSet.ToList();
        }

        public void SaveModelos(List<ModeloInicial> modelosIniciais)
        {
            foreach (var modeloJason in modelosIniciais)
            {
                
                if (!dbSet.Where(m => m.Id == modeloJason.Id).Any())
                {                    
                    Marca marca = marcaRepository.GetMarca(modeloJason.MarcaId);
                    
                    if (marca != null)
                    {
                        dbSet.Add(new Modelo(modeloJason.Nome, marca));
                    }                    
                }                
            }

            contexto.SaveChanges();
        }
    }
    public class ModeloInicial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
    }
}
