using appSebasDIego.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;

namespace appSebasDIego.Data
{
    public class CRUDProducto : IProducto
    {
        private Configuracion _conexion;

        public CRUDProducto(Configuracion conexion)
        {
            _conexion = conexion;
        }

        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        public async Task<IEnumerable<Producto>> ListarProducto()
        {
            var bd = Conectar();
            String cad_sql = @"select * from tb_producto";
            return await bd.QueryAsync<Producto>(cad_sql, new { });
        }

        public async Task<Producto> MostrarProducto(string codigo)
        {
            var bd = Conectar();
            String cad_sql = @"select * from tb_producto where codigo_producto = @cod";
            return await bd.QueryFirstAsync<Producto>(cad_sql, new { cod = codigo });
        }

        public async Task<bool> RegistrarProducto(Producto producto)
        {
            var bd = Conectar();
            String cad_sql = @"insert into tb_producto 
            values (@cod, @prod, @med, @stk, @prc, @cst, @cod_mar, @cod_pre)";

            int n = await bd.ExecuteAsync(cad_sql, new
            {
                cod = producto.codigo_producto,
                prod = producto.producto,
                med = producto.medida,
                stk = producto.stock_disponible,
                prc = producto.parecible,
                cst = producto.costo,
                cod_mar = producto.producto_codigo_marca,
                cod_pre = producto.producto_codigo_presentacion
            });
            return n > 0;
        }

        public async Task<bool> ActualizarProducto(Producto producto)
        {
            var bd = Conectar();
            String cad_sql = @"update tb_producto set
                    producto = @prod, medida = @med, stock_disponible = @stk,
                    parecible = @prc, costo = @cst, producto_codigo_marca = @cod_mar,
                    producto_codigo_presentacion = @cod_pre where codigo_producto = @cod";

            int n = await bd.ExecuteAsync(cad_sql, new
            {

                cod = producto.codigo_producto,
                prod = producto.producto,
                med = producto.medida,
                stk = producto.stock_disponible,
                prc = producto.parecible,
                cst = producto.costo,
                cod_mar = producto.producto_codigo_marca,
                cod_pre = producto.producto_codigo_presentacion

            });
            return n > 0;
        }

        public async Task<bool> EliminarProducto(string codigo)
        {
            var bd = Conectar();
            String cad_sql = @"delete from tb_producto
                                where codigo_producto = @cod";

            int n = await bd.ExecuteAsync(cad_sql, new { cod = codigo });

            return n > 0;
        }


    }
}
