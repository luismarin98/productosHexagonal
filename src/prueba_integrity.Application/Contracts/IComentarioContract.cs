using System;
using modelo_canonico.Types;


namespace prueba_integrity.Application.Contracts;

public interface IComentarioContract
{
    public Task<List<ComentarioType>> GetComentariosPorUsuario(int id_cliente);
    public Task<List<ComentarioType>> GetComentarioProductos(int id_producto);
    public Task<List<ComentarioType>> GetAllComentarios(int cliente_id);
    public Task<ComentarioType> GetComentarioID(int comentario_id);
    public Task<bool> CrearComentario(ComentarioType comentario);
    public Task<bool> ActualizarComentario(ComentarioType comentario);
    public Task<bool> EliminarComentario(int comentario_id);
}
