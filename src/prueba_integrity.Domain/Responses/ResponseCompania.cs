using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseCompania
{
    public int TotalRegistros { get; set; }
    public List<CompaniaType>? Compania { get; set; }
}
