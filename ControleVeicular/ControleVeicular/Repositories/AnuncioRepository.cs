using ControleVeicular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVeicular.Repositories
{
    public interface IAnuncioRepository
    {
        IList<Anuncio> GetAnuncios();
    }

    public class AnuncioRepository : BaseRepository<Anuncio>,  IAnuncioRepository
    {
        public AnuncioRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Anuncio> GetAnuncios()
        {
            return dbSet.Include(m => m.Marca).Include(mo => mo.Modelo).ToList();
        }

        public void SaveAnuncios(List<Anuncio1> anuncios)
        {
            foreach (var anuncio in anuncios)
            {
                
                if (!dbSet.Where(m => m.Id == anuncio.Id).Any())
                {
                    dbSet.Add(new Anuncio());
                }                
            }

            contexto.SaveChanges();
        }
    }    

    public class Anuncio1
    {
        public int Id { get; set; }
    }
}
