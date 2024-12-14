using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using modelo_canonico.Models;
using modelo_canonico.Parsing;
using modelo_canonico.Types;
using prueba_integrity.Domain.Responses;
using prueba_integrity.Infraestructure.Configuration;
using prueba_integrity.Infraestructure.Context;

namespace prueba_integrity.Infraestructure.Repository;

public class InventarioRepository : IInventarioContract
{
    private readonly DB _context;
    private readonly ILogger<InventarioRepository> _logger;

    public InventarioRepository(DB context, ILogger<InventarioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateInventario(InventarioType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            if (proveedor is null) throw new ArgumentException("Sin datos en la variable");
            InventarioModel? model = ParsingInventario.ModelToType(proveedor);
            _context.inventario.Add(model);
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

    public async Task<bool> DeleteInventario(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            InventarioModel? model = await _context.inventario.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");
            _context.inventario.Remove(model);
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

    public async Task<List<InventarioType>> GetAllInventarios()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            List<InventarioModel>? model = await _context.inventario.ToListAsync();
            if (model.Count is 0) throw new ArgumentException("Sin datos registrados");
            return ParsingInventario.ListModelToType(model);
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

    public async Task<InventarioType> GetInventarioID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            InventarioModel? model = await _context.inventario.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");
            return ParsingInventario.ModelToType(model);
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

    public async Task<bool> UpdateInventario(InventarioType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            InventarioModel? model = await _context.inventario.Where(x => x.Id == proveedor.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");
            model = ParsingInventario.ModelToType(proveedor);
            _context.inventario.Update(model);
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
