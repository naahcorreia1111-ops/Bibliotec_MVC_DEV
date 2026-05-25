using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotec_MVC_DEV.Models
{
    public class LivroCategoria
    {

        public int LivroId { get; set; }
        [ForeignKey("LivroId")]

        public Livro Livro { get; set; } = null!;

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]

        public Categoria Categoria { get; set; } = null!;




    }
}