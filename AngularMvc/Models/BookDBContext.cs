using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularMvc.Models
{
    public class BookDBContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}