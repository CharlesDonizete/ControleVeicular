using ControleVeicular.Models;
using System.Collections.Generic;

namespace ControleVeicular.Repositories
{
    public interface IMarcaRepository
    {
        void SaveMarcas(List<MarcaJason> marcaJasons);
        IList<Marca> GetMarcas();
    }
}