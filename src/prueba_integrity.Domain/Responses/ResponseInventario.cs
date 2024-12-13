using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseInventario
{
    public int TotalRegistros { get; set; }
    public List<InventarioType>? Inventario { get; set; }
}
