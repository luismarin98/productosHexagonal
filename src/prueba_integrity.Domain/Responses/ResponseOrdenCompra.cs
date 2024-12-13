using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseOrdenCompra
{
    public int TotalRegistros { get; set; }
    public List<OrdenCompraType>? OrdenCompra { get; set; }
}
