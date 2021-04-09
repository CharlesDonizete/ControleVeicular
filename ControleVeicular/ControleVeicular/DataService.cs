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

        public DataService(ApplicationContext contexto, IMarcaRepository marcaRepository)
        {
            this.contexto = contexto;
            this.marcaRepository = marcaRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.EnsureCreated();

            List<MarcaJason> marcas = GetMarcas();

            marcaRepository.SaveMarcas(marcas);
        }

        private static List<MarcaJason> GetMarcas()
        {
            var json = File.ReadAllText("marcas.json");

            var marcas = JsonConvert.DeserializeObject<List<MarcaJason>>(json);
            return marcas;
        }
    }

   

}
