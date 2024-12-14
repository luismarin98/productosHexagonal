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

public class OrdenCompraRepository : IOrdenCompraContract
{
    private readonly DB _context;
    private readonly ILogger<OrdenCompraRepository> _logger;

    public OrdenCompraRepository(DB context, ILogger<OrdenCompraRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateOrdenCompra(OrdenCompraType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            OrdenCompraModel? model = ParsingOrdenCompra.ModelToType(proveedor);
            _context.orden_compra.Add(model);
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

    public async Task<bool> DeleteOrdenCompra(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            OrdenCompraModel? model = await _context.orden_compra.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No se encontro la orden de compra especificada");
            _context.orden_compra.Remove(model);
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

    public async Task<List<OrdenCompraType>> GetAllOrdenCompra()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            List<OrdenCompraModel> ListaOrdenes = await _context.orden_compra.ToListAsync();
            if (ListaOrdenes.Count is 0) throw new ArgumentException("Sin resultados");
            return ParsingOrdenCompra.ListModelToType(ListaOrdenes);
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

    public async Task<OrdenCompraType> GetOrdenCompraID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            OrdenCompraModel? model = await _context.orden_compra.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No se encontro la orden de compra especificada");
            return ParsingOrdenCompra.ModelTotype(model);
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

    public async Task<bool> UpdateOrdenCompra(OrdenCompraType proveedor)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            OrdenCompraModel? model = await _context.orden_compra.Where(x => x.Id == proveedor.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No se encontro la orden de compra especificada");
            model = ParsingOrdenCompra.ModelToType(proveedor);
            _context.orden_compra.Update(model);
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
