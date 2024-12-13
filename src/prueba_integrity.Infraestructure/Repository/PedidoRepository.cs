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

public class PedidoRepository : IPedidoContract
{
    private readonly DB _context;
    private readonly ILogger<PedidoRepository> _logger;

    public PedidoRepository(DB context, ILogger<PedidoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreatePedido(PedidoType pedido)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            PedidoModel? model = await _context.pedido.Where(x => x.Id == pedido.Id).FirstOrDefaultAsync();
            if (model is not null) throw new ArgumentException("Ya hay un registro existente con esos datos");
            model = ParsingPedido.ModelToType(pedido);
            _context.pedido.Add(model);
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

    public async Task<bool> DeletePedido(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            PedidoModel? model = await _context.pedido.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No hay un pedido con esos datos");
            _context.pedido.Remove(model);
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

    public async Task<List<PedidoType>> GetAllPedidos()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            List<PedidoModel>? model = await _context.pedido.ToListAsync();
            if (model is null) throw new ArgumentException("Sin datos registrados");

            return ParsingPedido.ListModelToType(model);
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

    public async Task<PedidoType> GetPedidoID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            PedidoModel? model = await _context.pedido.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No hay un pedido con esos datos");
            return ParsingPedido.ModelToType(model);
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

    public async Task<bool> UpdatePedido(PedidoType pedido)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            PedidoModel? model = await _context.pedido.Where(x => x.Id == pedido.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No hay un pedido con esos datos");
            model = ParsingPedido.ModelToType(pedido);
            _context.pedido.Update(model);
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
