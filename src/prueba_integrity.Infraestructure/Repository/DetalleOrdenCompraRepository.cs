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

public class DetalleOrdenCompraRepository : IDetalleOrdenCompraContract
{
    private readonly DB _context;
    private readonly ILogger<DetalleOrdenCompraRepository> _logger;

    public DetalleOrdenCompraRepository(DB context, ILogger<DetalleOrdenCompraRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateDetalleOrdenCompra(DetalleOrdenCompraType detalleOrdenCompra)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            if (detalleOrdenCompra is null) throw new ArgumentException("Variable sin datos");
            DetalleOrdenCompraModel? model = ParsingDetalleOrdenCompra.ModelToType(detalleOrdenCompra);
            _context.detalle_orden_compra.Add(model);
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

    public async Task<bool> DeleteDetalleOrdenCompra(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            DetalleOrdenCompraModel? model = await _context.detalle_orden_compra.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");
            _context.detalle_orden_compra.Remove(model);
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

    public async Task<List<DetalleOrdenCompraType>> GetAllDetalles()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            List<DetalleOrdenCompraModel>? ListModel = await _context.detalle_orden_compra.ToListAsync();
            if (ListModel.Count is 0) throw new ArgumentException("Sin datos registrados");
            return ParsingDetalleOrdenCompra.ListModelToType(ListModel);
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

    public async Task<DetalleOrdenCompraType> GetDetalleOrdenCompraID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            DetalleOrdenCompraModel? model = await _context.detalle_orden_compra.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");
            return ParsingDetalleOrdenCompra.ModelToType(model);
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

    public async Task<bool> UpdateDetalleOrdenCompra(DetalleOrdenCompraType detalleOrdenCompra)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            DetalleOrdenCompraModel? model = await _context.detalle_orden_compra.Where(x => x.Id == detalleOrdenCompra.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");
            model = ParsingDetalleOrdenCompra.ModelToType(detalleOrdenCompra);
            _context.detalle_orden_compra.Update(model);
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
