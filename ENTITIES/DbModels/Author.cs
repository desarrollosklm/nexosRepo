using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ENTITIES.DbModels
{
    public class Author
    {
        [Key]
        public int IdAuthor { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CityOrigin { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
