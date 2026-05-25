using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotec_MVC_DEV.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]

        public String Titulo { get; set; }

        [Required]
        [StringLength(150)]

        public String Autor { get; set; }


        public int AnoPublicacao { get; set; }

        [Required]
        [StringLength(1)]
        public String Status { get; set; }
        //D - Disponivel, E - Emprestado, I - Indisponivel

        public String? Sinopse { get; set; }


        [Required]
        [StringLength(50)]
        public String Editora { get; set; }

        public String? Imagem  {  get; set;}

        public ICollection<Reserva> Reservas {get; set;} = new List<Reserva>();

                public ICollection<LivroCategoria> LivroCategorias {get; set;} = new List<LivroCategoria>();
    }
    
    }