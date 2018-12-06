namespace TapeDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Respaldos",
                c => new
                    {
                        RespaldoID = c.Int(nullable: false, identity: true),
                        Secuencia = c.String(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Ubicacion = c.String(),
                        AplicaPolitica = c.Boolean(nullable: false),
                        Comentario = c.String(),
                    })
                .PrimaryKey(t => t.RespaldoID);
            
            CreateTable(
                "dbo.Tapes",
                c => new
                    {
                        TapeID = c.Int(nullable: false, identity: true),
                        Formato = c.String(nullable: false),
                        CantidadTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CantidadEnUso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CantidadDisponible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LabelFisico = c.String(nullable: false),
                        Respaldos_RespaldoID = c.Int(),
                    })
                .PrimaryKey(t => t.TapeID)
                .ForeignKey("dbo.Respaldos", t => t.Respaldos_RespaldoID)
                .Index(t => t.Respaldos_RespaldoID);
            
            CreateTable(
                "dbo.TipoRespaldos",
                c => new
                    {
                        TipoRespaldoID = c.Int(nullable: false, identity: true),
                        TipoRespaldo = c.String(nullable: false),
                        Estatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoRespaldoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tapes", "Respaldos_RespaldoID", "dbo.Respaldos");
            DropIndex("dbo.Tapes", new[] { "Respaldos_RespaldoID" });
            DropTable("dbo.TipoRespaldos");
            DropTable("dbo.Tapes");
            DropTable("dbo.Respaldos");
        }
    }
}
