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

public class ClienteRepository : IClienteContract
{
    private readonly DB _context;
    private readonly ILogger<ClienteRepository> _logger;

    public ClienteRepository(DB context, ILogger<ClienteRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateCliente(ClienteType cliente)
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " Iniciando Metodo Repository");
            ClienteModel? model = await _context.cliente.Where(x => x.Nombres == cliente.Nombres).FirstOrDefaultAsync();
            if (model is not null) throw new ArgumentException("Puede que haya un usuario con datos similares");
            ClienteModel new_cliente = ParsingCliente.ModelToType(cliente);
            _context.cliente.Add(new_cliente);
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

    public async Task<bool> DeleteCliente(int cliente_id)
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " Iniciando Metodo Repository");
            ClienteModel? model = await _context.cliente.Where(x => x.Id == cliente_id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No existe un cliente registrado con ese id");
            _context.cliente.Remove(model);
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

    public async Task<List<ClienteType>> GetAllClientes()
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " Iniciando Metodo Repository");
            List<ClienteModel>? ListaClientes = await _context.cliente.ToListAsync();
            return ParsingCliente.ListModelToType(ListaClientes);
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

    public async Task<ClienteType> GetClienteID(int id_cliente)
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " - Iniciando Metodo Repository");
            ClienteModel? model = await _context.cliente.Where(x => x.Id == id_cliente).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No existe un cliente con ese id");
            return ParsingCliente.ModelToType(model);
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

    public async Task<bool> UpdateCliente(ClienteType cliente)
    {
        try
        {
            _logger.LogInformation(General.NombreApi + " - Iniciando Metodo Repository");
            ClienteModel? model = await _context.cliente.Where(x => x.Id == cliente.Id).FirstOrDefaultAsync();
            if (model is null) throw new ArgumentException("No se contraron datos a actualizar");
            model = ParsingCliente.ModelToType(cliente);
            _context.cliente.Update(model);
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