using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public interface IInventarioContract
{
    public Task<InventarioType> GetInventarioID(int id);
    public Task<List<InventarioType>> GetAllInventarios();
    public Task<bool> CreateInventario(InventarioType proveedor);
    public Task<bool> UpdateInventario(InventarioType proveedor);
    public Task<bool> DeleteInventario(int id);
}
