using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using prueba_integrity.Application.Contracts;
using prueba_integrity.Infraestructure.Configuration;
using prueba_integrity.Infraestructure.Context;
using modelo_canonico.Models;
using modelo_canonico.Types;
using modelo_canonico.Parsing;

namespace prueba_integrity.Infraestructure.Repository;

public class CategoriaRepository : ICategoriaContract
{
    private readonly ILogger<CategoriaRepository> _logger;
    private readonly DB _context;

    public CategoriaRepository(ILogger<CategoriaRepository> logger, DB context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<bool> CreateCategoria(CategoriaType categoria)
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " - Inicia Metodo Repository");
            CategoriaModel model = ParsingCategoria.ModelToType(categoria);
            _context.categoria.Add(model);
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

    public async Task<bool> DeleteCategoria(int Categoria_id)
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " - Inicia Metodo Repository");
            CategoriaModel? model = await _context.categoria.Where(x => x.CategoriaID == Categoria_id).FirstOrDefaultAsync();
            if (model is null) return false;
            _context.categoria.Remove(model);
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

    public async Task<List<CategoriaType>> GetAllCategorias()
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " - Inicia Metodo Repository");
            List<CategoriaModel> ListaCategoria = await _context.categoria.ToListAsync();
            return ParsingCategoria.ListModelToType(ListaCategoria);
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

    public async Task<CategoriaType> GetCategoriaID(int categoria_id)
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " - Inicia Metodo Repository");
            CategoriaModel? model = await _context.categoria.Where(x => x.CategoriaID == categoria_id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Falla en la busqueda de la categoria");
            return ParsingCategoria.ModelToType(model);

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

    public async Task<bool> UpdateCategoria(CategoriaType categoria)
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " - Inicia Metodo Repository");
            CategoriaModel model = ParsingCategoria.ModelToType(categoria);
            CategoriaModel? findCategoria = await _context.categoria.Where(x => x.CategoriaID == categoria.CategoriaID).FirstOrDefaultAsync();
            if (findCategoria is null) throw new ArgumentException("No se pudo actualizar la categoria");
            findCategoria = ParsingCategoria.ModelToType(categoria);
            _context.categoria.Update(findCategoria);
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
