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

public class ProveedorRepository : IProveedorContract
{
    private readonly DB _context;
    private readonly ILogger<ProveedorRepository> _logger;

    public ProveedorRepository(DB context, ILogger<ProveedorRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateProveedor(ProveedorType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            ProveedorModel? model = await _context.proveedor.Where(x => x.Id == proveedor.Id).FirstOrDefaultAsync();
            if (model is not null) throw new ArgumentException("Ya existe un producto con esos datos");
            model = ParsingProveedor.ModelToType(proveedor);
            _context.proveedor.Add(model);
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

    public async Task<bool> DeleteProveedor(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            ProveedorModel? model = await _context.proveedor.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No existe un producto con esos datos");

            _context.proveedor.Remove(model);
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

    public async Task<List<ProveedorType>> GetAllProveedores()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            List<ProveedorModel>? model = await _context.proveedor.ToListAsync();
            if (model is null) throw new ArgumentException("No existe un producto con esos datos");
            return ParsingProveedor.ListModelToType(model);

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

    public async Task<ProveedorType> GetProveedorID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");

            ProveedorModel? model = await _context.proveedor.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No existe un producto con esos datos");
            return ParsingProveedor.ModelToType(model);
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

    public async Task<bool> UpdateProveedor(ProveedorType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");

            ProveedorModel? model = await _context.proveedor.Where(x => x.Id == proveedor.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No existe un producto con esos datos");
            model = ParsingProveedor.ModelToType(proveedor);
            _context.proveedor.Update(model);
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
