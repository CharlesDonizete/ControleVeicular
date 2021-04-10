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
        void SaveAnuncios(List<AnuncioInicial> anuncioInicials);
    }

    public class AnuncioRepository : BaseRepository<Anuncio>,  IAnuncioRepository
    {
        private readonly IMarcaRepository marcaRepository;
        private readonly IModeloRepository modeloRepository;
        public AnuncioRepository(ApplicationContext contexto, IMarcaRepository marcaRepository, IModeloRepository modeloRepository) : base(contexto)
        {
            this.marcaRepository = marcaRepository;
            this.modeloRepository = modeloRepository;
        }

        public IList<Anuncio> GetAnuncios()
        {
            return dbSet.Include(m => m.Marca).Include(mo => mo.Modelo).ToList();
        }

        public void SaveAnuncios(List<AnuncioInicial> anuncioInicials)
        {
            foreach (var anuncioInicial in anuncioInicials)
            {
                
                if (!dbSet.Where(m => m.Id == anuncioInicial.Id).Any())
                {
                    Modelo modelo = modeloRepository.GetModelo(anuncioInicial.ModeloId);
                    Marca marca = marcaRepository.GetMarca(anuncioInicial.MarcaId);

                    if (modelo != null && marca != null)
                    {
                        dbSet.Add(new Anuncio(modelo,marca,anuncioInicial.Ano,anuncioInicial.ValorCompra,anuncioInicial.ValorVenda, anuncioInicial.Cor,anuncioInicial.TipoCombustivel,anuncioInicial.DataVenda ));
                    }                    
                }                
            }

            contexto.SaveChanges();
        }
    }    

    public class AnuncioInicial
    {
        public int Id { get; set; }
        public int ModeloId { get; set; }        
        public int MarcaId { get; set; }
        public string Ano { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public string Cor { get; set; }
        public string TipoCombustivel { get; set; }
        public DateTime DataVenda { get; set; }
}
}
