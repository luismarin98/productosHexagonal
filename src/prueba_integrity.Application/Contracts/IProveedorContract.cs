using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface IProveedorContract
{
    public Task<ProveedorType> GetProveedorID(int id);
    public Task<List<ProveedorType>> GetAllProveedores();
    public Task<bool> CreateProveedor(ProveedorType proveedor);
    public Task<bool> UpdateProveedor(ProveedorType proveedor);
    public Task<bool> DeleteProveedor(int id);
}
