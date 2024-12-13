using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface IOrdenCompraContract
{
    public Task<OrdenCompraType> GetOrdenCompraID(int id);
    public Task<List<OrdenCompraType>> GetAllOrdenCompra();
    public Task<bool> CreateOrdenCompra(OrdenCompraType proveedor);
    public Task<bool> UpdateOrdenCompra(OrdenCompraType proveedor);
    public Task<bool> DeleteOrdenCompra(int id);
}
