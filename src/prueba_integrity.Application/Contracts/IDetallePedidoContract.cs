using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface IDetallePedidoContract
{
    public Task<DetallePedidoType> GetDetallePedidoID(int id);
    public Task<List<DetallePedidoType>> GetAllDetallePedidos();
    public Task<bool> CreateDetallePedido(DetallePedidoType proveedor);
    public Task<bool> UpdateDetallePedido(DetallePedidoType proveedor);
    public Task<bool> DeleteDetallePedido(int id);
}
