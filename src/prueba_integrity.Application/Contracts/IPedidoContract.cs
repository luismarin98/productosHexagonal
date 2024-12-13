using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface IPedidoContract
{
    public Task<PedidoType> GetPedidoID(int id);
    public Task<List<PedidoType>> GetAllPedidos();
    public Task<bool> CreatePedido(PedidoType proveedor);
    public Task<bool> UpdatePedido(PedidoType proveedor);
    public Task<bool> DeletePedido(int id);
}
