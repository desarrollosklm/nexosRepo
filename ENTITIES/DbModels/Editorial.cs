using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ENTITIES.DbModels
{
    public class Editorial
    {
        [Key]
        public int IdEditorial { get; set; }
        
        [Column(TypeName="nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CorrespondenceAddress { get; set; }

        [Column(TypeName = "nvarchar(13)")]
        public string Phone { get; set; }
        
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "int")]
        public int MaximumBooksRegistered { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
