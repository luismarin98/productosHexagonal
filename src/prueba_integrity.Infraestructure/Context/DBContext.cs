using System;
using Microsoft.EntityFrameworkCore;
using modelo_canonico.Models;

namespace prueba_integrity.Infraestructure.Context;

public class DB : DbContext
{
    public DB(DbContextOptions<DB> options) : base(options) { }

    public DbSet<CategoriaModel> categoria => Set<CategoriaModel>();
    public DbSet<ClienteModel> cliente => Set<ClienteModel>();
    public DbSet<ComentarioModel> comentario => Set<ComentarioModel>();
    public DbSet<CompaniaModel> compania => Set<CompaniaModel>();
    public DbSet<DetalleOrdenCompraModel> detalle_orden_compra => Set<DetalleOrdenCompraModel>();
    public DbSet<DetallePedidoModel> detalle_pedido => Set<DetallePedidoModel>();
    public DbSet<InventarioModel> inventario => Set<InventarioModel>();
    public DbSet<OrdenCompraModel> orden_compra => Set<OrdenCompraModel>();
    public DbSet<PedidoModel> pedido => Set<PedidoModel>();
    public DbSet<PrecioModel> precio => Set<PrecioModel>();
    public DbSet<ProductoModel> producto => Set<ProductoModel>();
    public DbSet<ProveedorModel> proveedor => Set<ProveedorModel>();
}
