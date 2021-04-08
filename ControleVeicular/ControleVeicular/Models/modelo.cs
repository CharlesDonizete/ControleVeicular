using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ControleVeicular.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Marca : BaseModel
    {
        public Marca() { }
        
        [Required]
        public string Descricao { get; private set; }

        //public virtual Modelo Modelo { get; set; }

        //public virtual Anuncio Anuncio { get; private set; }

        public List<Modelo> Modelos { get; private set; } = new List<Modelo>();

        public List<Anuncio> Anuncios { get; private set; } = new List<Anuncio>();
        public Anuncio Anuncio { get; internal set; }

        public Marca(string descricao)
        {
            this.Descricao = descricao;
        }
    }

    public class Modelo : BaseModel
    {
        public Modelo() { }        

        [Required]
        public string Descricao { get; private set; }

        [Required]
        public Marca Marca { get; private set; }

        public List<Anuncio> Anuncios { get; internal set; }
        public Anuncio Anuncio { get; internal set; }

        public Modelo(string descricao, Marca marca)
        {
            this.Descricao = descricao;
            this.Marca = marca;
        }
    }

    public class Anuncio : BaseModel
    {
        public Anuncio() { }

        [Required]
        public Modelo Modelo { get; private set; }

        public int MarcaForeignKey { get; set; }
        [Required]
        public Marca Marca { get; private set; }

        [Required]
        public string Ano { get; private set; }

        [Required]
        public decimal ValorCompra { get; private set; }

        [Required]
        public decimal ValorVenda { get; private set; }

        [Required]
        public string Cor { get; private set; }

        [Required]
        public string TipoCombustivel { get; private set; }

        [Required]
        public DateTime DataVenda { get; private set; }

    }
    
}
