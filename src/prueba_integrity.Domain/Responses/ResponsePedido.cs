using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponsePedido
{
    public int TotalRegistros { get; set; }
    public List<PedidoType>? Pedido { get; set; }
}
