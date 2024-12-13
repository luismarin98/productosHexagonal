using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface IClienteContract
{
    public Task<ClienteType> GetClienteID(int id_cliente);
    public Task<List<ClienteType>> GetAllClientes();
    public Task<bool> CreateCliente(ClienteType cliente);
    public Task<bool> UpdateCliente(ClienteType cliente);
    public Task<bool> DeleteCliente(int cliente_id);
}
