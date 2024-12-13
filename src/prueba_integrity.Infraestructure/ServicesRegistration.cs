using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using prueba_integrity.Application.Contracts;
using prueba_integrity.Infraestructure.Repository;
using prueba_integrity.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using prueba_integrity.Domain.Responses;

namespace prueba_integrity.Infraestructure;

public static class ServicesRegistration
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<ICategoriaContract, CategoriaRepository>();
        service.AddScoped<IClienteContract, ClienteRepository>();
        service.AddScoped<IComentarioContract, ComentarioRepository>();
        service.AddScoped<ICompaniaContract, CompaniaRepository>();
        service.AddScoped<IDetalleOrdenCompraContract, DetalleOrdenCompraRepository>();
        service.AddScoped<IDetallePedidoContract, DetallePedidoRepository>();
        service.AddScoped<IInventarioContract, InventarioRepository>();
        service.AddScoped<IOrdenCompraContract, OrdenCompraRepository>();
        service.AddScoped<IPedidoContract, PedidoRepository>();
        service.AddScoped<IProductoContract, ProductoRepository>();
        service.AddScoped<IProveedorContract, ProveedorRepository>();
        service.AddScoped<IClienteContract, ClienteRepository>();

        service.AddDbContext<DB>(opts => opts.UseSqlServer(configuration.GetConnectionString("pruebas")));

        return service;
    }
}
