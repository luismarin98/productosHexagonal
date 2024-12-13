using System;
using Microsoft.Extensions.Logging;
using modelo_canonico.Types;
using prueba_integrity.Application.Contracts;
using prueba_integrity.Infraestructure.Configuration;
using prueba_integrity.Infraestructure.Context;

namespace prueba_integrity.Infraestructure.Repository;

public class OrdenCompraRepository : IOrdenCompraContract
{
    private readonly DB _context;
    private readonly ILogger<OrdenCompraRepository> _logger;

    public OrdenCompraRepository(DB context, ILogger<OrdenCompraRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<bool> CreateOrdenCompra(OrdenCompraType proveedor)
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

    public Task<bool> DeleteOrdenCompra(int id)
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

    public Task<List<OrdenCompraType>> GetAllOrdenCompra()
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

    public Task<OrdenCompraType> GetOrdenCompraID(int id)
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

    public Task<bool> UpdateOrdenCompra(OrdenCompraType proveedor)
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
