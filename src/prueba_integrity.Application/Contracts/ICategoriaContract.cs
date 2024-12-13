using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface ICategoriaContract
{
    public Task<CategoriaType> GetCategoriaID(int categoria_id);
    public Task<List<CategoriaType>> GetAllCategorias();
    public Task<bool> CreateCategoria(CategoriaType categoria);
    public Task<bool> UpdateCategoria(CategoriaType categoria);
    public Task<bool> DeleteCategoria(int Categoria_id);
}
