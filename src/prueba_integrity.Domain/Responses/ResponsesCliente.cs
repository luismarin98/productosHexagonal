using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponsesCliente
{
    public int TotalRegistros { get; set; }
    public List<ClienteType>? Cliente { get; set; }
}
