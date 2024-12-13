using System;
using Microsoft.Extensions.Logging;
using modelo_canonico.Types;
using prueba_integrity.Application.Contracts;
using prueba_integrity.Infraestructure.Configuration;
using prueba_integrity.Infraestructure.Context;

namespace prueba_integrity.Infraestructure.Repository;

public class DetallePedidoRepository : IDetallePedidoContract
{
    private readonly DB _context;
    private readonly ILogger<DetallePedidoRepository> _logger;

    public DetallePedidoRepository(DB context, ILogger<DetallePedidoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<bool> CreateDetallePedido(DetallePedidoType proveedor)
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

    public Task<bool> DeleteDetallePedido(int id)
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

    public Task<List<DetallePedidoType>> GetAllDetallePedidos()
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

    public Task<DetallePedidoType> GetDetallePedidoID(int id)
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

    public Task<bool> UpdateDetallePedido(DetallePedidoType proveedor)
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
