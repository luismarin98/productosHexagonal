using System;
using Microsoft.Extensions.Logging;
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

    public Task<bool> CreateInventario(InventarioType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
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

    public Task<bool> DeleteInventario(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
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

    public Task<List<InventarioType>> GetAllInventarios()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
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

    public Task<InventarioType> GetInventarioID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
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

    public Task<bool> UpdateInventario(InventarioType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
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
