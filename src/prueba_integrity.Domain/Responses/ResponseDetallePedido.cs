using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseDetallePedido
{
    public int TotalRegistros { get; set; }
    public List<DetallePedidoType>? DetallePedido { get; set; }
}
