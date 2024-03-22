﻿using appSebasDIego.Data;
using appSebasDIego.Model;
using Microsoft.AspNetCore.Mvc;

namespace appSebasDIego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private IProducto _producto;

        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }


        [HttpGet]
        public async Task<IActionResult> listarProducto()
        {
            return Ok(await _producto.ListarProducto());
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> MostrarProducto(String codigo)
        {
            return Ok(await _producto.MostrarProducto(codigo));
        }


        [HttpPost]
        public async Task<IActionResult> RegistrarProducto([FromBody] Producto producto)
        {
            if (producto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var registro = await _producto.RegistrarProducto(producto);
            return Created("Producto registrado...", registro);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarProducto([FromBody] Producto producto)
        {
            if (producto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var registro = await _producto.ActualizarProducto(producto);
            return Created("Producto actualizado...", registro);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarProducto(String codigo)
        {
            

            var registro = await _producto.EliminarProducto(codigo);
            return Created("Producto Eliminado...", registro);
        }


    }
}
