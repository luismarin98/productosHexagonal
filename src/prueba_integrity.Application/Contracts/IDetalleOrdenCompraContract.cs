using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface IDetalleOrdenCompraContract
{
    public Task<DetalleOrdenCompraType> GetDetalleOrdenCompraID(int id);
    public Task<List<DetalleOrdenCompraType>> GetAllDetalles();
    public Task<bool> CreateDetalleOrdenCompra(DetalleOrdenCompraType detalleOrdenCompra);
    public Task<bool> UpdateDetalleOrdenCompra(DetalleOrdenCompraType detalleOrdenCompra);
    public Task<bool> DeleteDetalleOrdenCompra(int id);
}
