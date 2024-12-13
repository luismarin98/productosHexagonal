using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseProducto
{
    public int TotalRegistros { get; set; }
    public List<ProductoType>? Producto { get; set; }
}
