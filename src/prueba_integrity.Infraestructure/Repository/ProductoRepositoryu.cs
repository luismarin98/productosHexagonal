using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using modelo_canonico.Models;
using modelo_canonico.Parsing;
using modelo_canonico.Types;
using prueba_integrity.Application.Contracts;
using prueba_integrity.Infraestructure.Configuration;
using prueba_integrity.Infraestructure.Context;

namespace prueba_integrity.Infraestructure.Repository;

public class ProductoRepository : IProductoContract
{
    private readonly DB _context;
    private readonly ILogger<ProductoRepository> _logger;

    public ProductoRepository(DB context, ILogger<ProductoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateProducto(ProductoType producto)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            ProductoModel? model = await _context.producto.Where(x => x.Id == producto.Id).FirstOrDefaultAsync();
            if (model is not null) throw new ArgumentException("Ya existe un producto con esos datos");
            model = ParsingProducto.ModelToType(producto);
            _context.producto.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(General.NombreApi + " - Error Metodo Repository" + ex);
            throw;
        }
        finally
        {
            _logger.LogInformation(General.NombreApi + " - Finaliza Metodo Repository");
        }
    }

    public async Task<bool> DeleteProducto(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            ProductoModel? model = await _context.producto.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No se encontro un producto con esos datos");
            _context.producto.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(General.NombreApi + " - Error Metodo Repository" + ex);
            throw;
        }
        finally
        {
            _logger.LogInformation(General.NombreApi + " - Finaliza Metodo Repository");
        }
    }

    public async Task<List<ProductoType>> GetAllProductos()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            List<ProductoModel>? listProductos = await _context.producto.ToListAsync();
            if (listProductos.Count is 0) throw new ArgumentException("Sin Resultados");
            return ParsingProducto.ModelToType(listProductos);
        }
        catch (Exception ex)
        {
            _logger.LogError(General.NombreApi + " - Error Metodo Repository" + ex);
            throw;
        }
        finally
        {
            _logger.LogInformation(General.NombreApi + " - Finaliza Metodo Repository");
        }
    }

    public async Task<ProductoType> GetProducto(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            ProductoModel? model = await _context.producto.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("SIn resultados");
            return ParsingProducto.ModelToType(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(General.NombreApi + " - Error Metodo Repository" + ex);
            throw;
        }
        finally
        {
            _logger.LogInformation(General.NombreApi + " - Finaliza Metodo Repository");
        }
    }

    public async Task<bool> UpdateProducto(ProductoType producto)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            ProductoModel? model = await _context.producto.Where(x => x.Id == producto.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin resultados");
            model = ParsingProducto.ModelToType(producto);
            _context.producto.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(General.NombreApi + " - Error Metodo Repository" + ex);
            throw;
        }
        finally
        {
            _logger.LogInformation(General.NombreApi + " - Finaliza Metodo Repository");
        }
    }
}
