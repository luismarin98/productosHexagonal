using System;
using modelo_canonico.Types;

namespace prueba_integrity.Domain.Responses;

public class ResponseComentario
{
    public int TotalRegistros { get; set; }
    public List<ComentarioType>? Comentario { get; set; }
}
