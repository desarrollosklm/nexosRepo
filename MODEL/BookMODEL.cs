using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class BookMODEL
    {
        public int IdBook { get; set; }

        public string Tittle { get; set; }
        public int Year { get; set; }

        public string Gender { get; set; }

        public long NumberPages { get; set; }

        public int IdEditorial { get; set; }

        public int IdAuthor { get; set; }

    }
}
