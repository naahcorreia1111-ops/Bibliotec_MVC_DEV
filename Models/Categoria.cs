using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotec_MVC_DEV.Models
{
    public class Categoria
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

                public ICollection<LivroCategoria> LivroCategorias {get; set;} = new List<LivroCategoria>();


    }
}