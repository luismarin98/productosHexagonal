using System;
using modelo_canonico.Types;

namespace prueba_integrity.Application.Contracts;

public interface IProductoContract
{
    public Task<ProductoType> GetProducto(int id);
    public Task<List<ProductoType>> GetAllProductos();
    public Task<bool> CreateProducto(ProductoType producto);
    public Task<bool> UpdateProducto(ProductoType producto);
    public Task<bool> DeleteProducto(int id);
}
