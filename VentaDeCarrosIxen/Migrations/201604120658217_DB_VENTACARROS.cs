namespace VentaDeCarrosIxen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_VENTACARROS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        idArchivo = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ContentType = c.String(),
                        tipo = c.Int(nullable: false),
                        contenido = c.Binary(),
                        idCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idArchivo)
                .ForeignKey("dbo.Carroes", t => t.idCarro, cascadeDelete: true)
                .Index(t => t.idCarro);
            
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        idCarro = c.Int(nullable: false, identity: true),
                        modelo = c.String(nullable: false),
                        marca = c.String(nullable: false),
                        precio = c.String(nullable: false),
                        color = c.String(),
                        combustible = c.String(),
                        kilometros = c.Int(nullable: false),
                        añoFabricacion = c.DateTime(nullable: false),
                        descripcion = c.String(),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCarro);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        idCompra = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        idCarro = c.Int(nullable: false),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCompra)
                .ForeignKey("dbo.Carroes", t => t.idCarro, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idCarro)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        contraseña = c.String(nullable: false),
                        confirmarContraseña = c.String(nullable: false),
                        idRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Rols", t => t.idRol, cascadeDelete: true)
                .Index(t => t.idRol);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "idRol", "dbo.Rols");
            DropForeignKey("dbo.Compras", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Compras", "idCarro", "dbo.Carroes");
            DropForeignKey("dbo.Archivoes", "idCarro", "dbo.Carroes");
            DropIndex("dbo.Usuarios", new[] { "idRol" });
            DropIndex("dbo.Compras", new[] { "idUsuario" });
            DropIndex("dbo.Compras", new[] { "idCarro" });
            DropIndex("dbo.Archivoes", new[] { "idCarro" });
            DropTable("dbo.Rols");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Compras");
            DropTable("dbo.Carroes");
            DropTable("dbo.Archivoes");
        }
    }
}
