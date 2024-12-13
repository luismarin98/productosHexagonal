using System;
using Microsoft.Extensions.Logging;
using modelo_canonico.Types;
using prueba_integrity.Application.Contracts;
using prueba_integrity.Infraestructure.Configuration;
using prueba_integrity.Infraestructure.Context;

namespace prueba_integrity.Infraestructure.Repository;

public class DetalleOrdenCompraRepository : IDetalleOrdenCompraContract
{
    private readonly DB _context;
    private readonly ILogger<DetalleOrdenCompraRepository> _logger;

    public DetalleOrdenCompraRepository(DB context, ILogger<DetalleOrdenCompraRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<bool> CreateDetalleOrdenCompra(DetalleOrdenCompraType detalleOrdenCompra)
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

    public Task<bool> DeleteDetalleOrdenCompra(int id)
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

    public Task<List<DetalleOrdenCompraType>> GetAllDetalles()
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

    public Task<DetalleOrdenCompraType> GetDetalleOrdenCompraID(int id)
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

    public Task<bool> UpdateDetalleOrdenCompra(DetalleOrdenCompraType detalleOrdenCompra)
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
