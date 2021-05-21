using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ENTITIES.DbModels
{
    public class Book
    {
        [Key]
        public int IdBook { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Tittle { get; set; }
        public int Year { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Gender { get; set; }

        public long NumberPages { get; set; }

        public int IdEditorial { get; set; }

        [ForeignKey("IdEditorial")]
        public virtual Editorial Editorial { get; set; }

        public int IdAuthor { get; set; }

        [ForeignKey("IdAuthor")]
        public virtual Author Author { get; set; }

    }
}
