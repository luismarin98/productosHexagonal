using System;
using modelo_canonico.Models;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseDetalleOrdenCompra
{
    public int TotalRegistros { get; set; }
    public List<DetalleOrdenCompraType>? DetalleOrdenCompraType { get; set; }
}
