using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VentaDeCarrosIxen.Models
{
        public partial class DB_VENTACARROS : DbContext
        {
            public DB_VENTACARROS() : base("name=DB_VentaCarros") { }
            public virtual DbSet<Rol> rol { get; set; }
            public virtual DbSet<Archivo> archivo { get; set; }
            public virtual DbSet<Usuario> usuario { get; set; }
            public virtual DbSet<Carro> carro { get; set; }
            public virtual DbSet<Compra> compra { get; set; }

        }
}