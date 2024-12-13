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

public class ComentarioRepository : IComentarioContract
{
    private readonly DB _context;
    private readonly ILogger<ComentarioRepository> _logger;

    public ComentarioRepository(DB context, ILogger<ComentarioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> ActualizarComentario(ComentarioType comentario)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository");
            ComentarioModel? model = await _context.comentario.Where(x => x.Id == comentario.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No se encontro un registro con ese id");
            model = ParsingComentario.ModelToType(comentario);
            _context.comentario.Update(model);
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

    public async Task<bool> CrearComentario(ComentarioType comentario)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository");
            ComentarioModel model = ParsingComentario.ModelToType(comentario);
            _context.comentario.Add(model);
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

    public async Task<bool> EliminarComentario(int comentario_id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository");
            ComentarioModel? model = await _context.comentario.Where(x => x.Id == comentario_id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No se encontro un comentario con ese id");
            _context.comentario.Remove(model);
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

    public async Task<List<ComentarioType>> GetAllComentarios(int cliente_id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository");
            List<ComentarioModel>? ListModel = await _context.comentario.ToListAsync();
            return ParsingComentario.ListModelToType(ListModel);
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

    public async Task<ComentarioType> GetComentarioID(int comentario_id)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository");
            ComentarioModel? model = await _context.comentario.Where(x => x.Id == comentario_id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Busqueda fallida");
            return ParsingComentario.ModelToType(model);
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

    public async Task<List<ComentarioType>> GetComentarioProductos(int id_producto)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository");
            List<ComentarioModel>? ListModel = await _context.comentario.Where(x => x.IdProducto == id_producto).ToListAsync();
            if(ListModel.Count is 0) throw new ArgumentException("Busqueda fallida");
            return ParsingComentario.ListModelToType(ListModel);
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

    public async Task<List<ComentarioType>> GetComentariosPorUsuario(int id_cliente)
    {
        try
        {
            _logger.LogInformation("Inicia metodo repository");
            List<ComentarioModel>? model = await _context.comentario.Where(x => x.IdCliente == id_cliente).ToListAsync();
            if (model is null) throw new ArgumentException("Busqueda fallida");
            return ParsingComentario.ListModelToType(model);
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
