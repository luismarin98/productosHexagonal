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

public class CompaniaRepository : ICompaniaContract
{
    private readonly DB _context;
    private readonly ILogger<CompaniaRepository> _logger;

    public CompaniaRepository(DB context, ILogger<CompaniaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateCompania(CompaniaType compania)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            CompaniaModel? model = await _context.compania.Where(x => x.Nombre!.Contains(compania.Nombre!) && x.Email!.Contains(compania.Email!)).FirstOrDefaultAsync();
            if (model is not null) throw new ArgumentException("Ya hay una compania registrada con ese nombre");
            model = ParsingCompania.ModelToType(compania);
            _context.compania.Add(model);
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

    public async Task<bool> DeleteCompania(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            CompaniaModel? model = await _context.compania.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Ya hay una compania registrada con ese id");
            _context.compania.Remove(model);
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

    public async Task<List<CompaniaType>> GetAllCompanias()
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            List<CompaniaModel>? model = await _context.compania.ToListAsync();
            if (model.Count is 0) throw new ArgumentException("Ya hay una compania registrada con ese nombre");
            return ParsingCompania.ListModelToType(model);
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

    public async Task<CompaniaType> GetCompaniaID(int id)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            CompaniaModel? model = await _context.compania.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Ya hay una compania registrada con ese id");
            return ParsingCompania.ModelToType(model);
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

    public async Task<bool> UpdateCompania(CompaniaType compania)
    {
        try
        {
            _logger.LogInformation("Inicia Metodo Repository");
            CompaniaModel? model = await _context.compania.Where(x => x.Id == compania.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("Ya hay una compania registrada con ese id");
            model = ParsingCompania.ModelToType(compania);
            _context.compania.Update(model);
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
