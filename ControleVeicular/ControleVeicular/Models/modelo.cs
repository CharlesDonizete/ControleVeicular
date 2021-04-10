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

    [DataContract]
    public class Marca : BaseModel    {        
        public Marca() { }
        
        [Required]
        [DataMember]
        [StringLength(100)]
        public string Descricao { get; private set; }

        [DataMember]
        public List<Modelo> Modelos { get; private set; } = new List<Modelo>();

        [DataMember]
        public List<Anuncio> Anuncios { get; private set; } = new List<Anuncio>();                

        public Marca(string descricao)
        {
            this.Descricao = descricao;
        }
    }

    [DataContract]
    public class Modelo : BaseModel
    {
        public Modelo() { }        

        [Required]
        [DataMember]
        public string Descricao { get; private set; }

        [Required]
        [DataMember]
        public Marca Marca { get; private set; }

        public List<Anuncio> Anuncios { get; private set; } = new List<Anuncio>();        

        public Modelo(string descricao, Marca marca)
        {
            this.Descricao = descricao;
            this.Marca = marca;
        }
    }

    [DataContract]
    public class Anuncio : BaseModel
    {        
        public Anuncio() { }

        [DataMember]
        public Modelo Modelo { get; private set; }

        [DataMember]
        public Marca Marca { get; private set; }

        [Required]
        [DataMember]
        public string Ano { get; private set; }

        [Required]
        [DataMember]
        public decimal ValorCompra { get; private set; }

        [Required]
        [DataMember]
        public decimal ValorVenda { get; private set; }

        [Required]
        [DataMember]
        public string Cor { get; private set; }

        [Required]
        [DataMember]
        public string TipoCombustivel { get; private set; }

        [Required]
        [DataMember]
        public DateTime DataVenda { get; private set; }

        public Anuncio(Modelo modelo, Marca marca,string ano, decimal valorCompra, decimal valorVenda, string cor, string tipoCombustivel, DateTime dataVenda)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.Ano = ano;
            this.ValorCompra = valorCompra;
            this.ValorVenda = valorVenda;
            this.Cor = cor;
            this.TipoCombustivel = tipoCombustivel;
            this.DataVenda = dataVenda;
        }
    }
    
}
