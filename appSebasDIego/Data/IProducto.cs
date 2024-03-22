using appSebasDIego.Model;

namespace appSebasDIego.Data
{
    public interface IProducto
    {

        Task<IEnumerable<Producto>> ListarProducto();
        Task<Producto> MostrarProducto(String codigo);
        Task<bool> RegistrarProducto(Producto producto);
        Task<bool> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(String codigo);

    }
}
