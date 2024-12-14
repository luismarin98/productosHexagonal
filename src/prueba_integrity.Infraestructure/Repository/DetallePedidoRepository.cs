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

public class DetallePedidoRepository : IDetallePedidoContract
{
    private readonly DB _context;
    private readonly ILogger<DetallePedidoRepository> _logger;

    public DetallePedidoRepository(DB context, ILogger<DetallePedidoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateDetallePedido(DetallePedidoType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            if (proveedor is null) throw new ArgumentException("Variable sin datos");
            DetallePedidoModel? model = ParsingDetallePedido.ModelToType(proveedor);
            _context.detalle_pedido.Add(model);
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

    public async Task<bool> DeleteDetallePedido(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            DetallePedidoModel? model = await _context.detalle_pedido.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos a eliminar");
            _context.detalle_pedido.Remove(model);
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

    public async Task<List<DetallePedidoType>> GetAllDetallePedidos()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            List<DetallePedidoModel>? modelList = await _context.detalle_pedido.ToListAsync();
            if (modelList.Count is 0) throw new ArgumentException("Sin datos registrados");
            return ParsingDetallePedido.ListModelToType(modelList);
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

    public async Task<DetallePedidoType> GetDetallePedidoID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            DetallePedidoModel? model = await _context.detalle_pedido.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");
            return ParsingDetallePedido.ModelToType(model);
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

    public async Task<bool> UpdateDetallePedido(DetallePedidoType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            DetallePedidoModel? model = await _context.detalle_pedido.Where(x => x.Id == proveedor.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");
            model = ParsingDetallePedido.ModelToType(proveedor);

            _context.detalle_pedido.Update(model);
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
