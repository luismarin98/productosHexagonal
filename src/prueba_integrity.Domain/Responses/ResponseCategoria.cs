using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseCategoria
{
    public int TotalRegistros { get; set; }
    public List<CategoriaType>? Categoria { get; set; }
}
