using ControleVeicular.Models;
using ControleVeicular.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ControleVeicular
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IMarcaRepository marcaRepository;
        private readonly IModeloRepository modeloRepository;
        private readonly IAnuncioRepository anuncioRepository;

        public DataService(ApplicationContext contexto, IMarcaRepository marcaRepository, IModeloRepository modeloRepository, IAnuncioRepository anuncioRepository)
        {
            this.contexto = contexto;
            this.marcaRepository = marcaRepository;
            this.modeloRepository = modeloRepository;
            this.anuncioRepository = anuncioRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.EnsureCreated();

            List<MarcaJason> marcas = GetMarcas();

            marcaRepository.SaveMarcas(marcas);

            List<ModeloInicial> modeloInicials = GetModelos();

            modeloRepository.SaveModelos(modeloInicials);

            List<AnuncioInicial> anuncioInicials = GetAnuncios();

            anuncioRepository.SaveAnuncios(anuncioInicials);
        }

        private static List<MarcaJason> GetMarcas()
        {
            var json = File.ReadAllText("marcas.json");

            var marcas = JsonConvert.DeserializeObject<List<MarcaJason>>(json);
            return marcas;
        }

        private static List<ModeloInicial> GetModelos()
        {
            var json = File.ReadAllText("modelosInicial.json");

            var modelo = JsonConvert.DeserializeObject<List<ModeloInicial>>(json);
            return modelo;
        }

        private static List<AnuncioInicial> GetAnuncios()
        {
            var json = File.ReadAllText("anuncioInicial.json");

            var anuncioInicials = JsonConvert.DeserializeObject<List<AnuncioInicial>>(json);
            return anuncioInicials;
        }
    }

   

}
