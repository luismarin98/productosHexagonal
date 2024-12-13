using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseProveedor
{
    public int TotalRegistros { get; set; }
    public List<ProveedorType>? Proveedor { get; set; }
}
