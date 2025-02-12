using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoSemanaUno.Data
{
    public class Inventario
    {
        //Atributo
        public List<Producto> productos = new List<Producto>();

        // Crear
        public void AgregarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto nuevo:");
            string nombreProducto = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto nuevo:");
            decimal PrecioProducto = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad disponible del producto nuevo:");
            int CantidadDisponibleProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione la categoria del producto: \n1-Hogar \n2-Moda \n3-Electronico");
            int tipoCategoria = int.Parse(Console.ReadLine());

            switch (tipoCategoria)
            {
                case 1:
                    ProductoHogar productoHogar = new ProductoHogar(nombreProducto, PrecioProducto, CantidadDisponibleProducto);
                    productos.Add(productoHogar);
                    Console.WriteLine("Producto agregado al inventario.");
                    break;
                case 2:
                    ProductoModa productoModa = new ProductoModa(nombreProducto, PrecioProducto, CantidadDisponibleProducto);
                    productos.Add(productoModa);
                    Console.WriteLine("Producto agregado al inventario.");
                    break;
                case 3:
                    ProductoElectronico productoElectronico = new ProductoElectronico(nombreProducto, PrecioProducto, CantidadDisponibleProducto);
                    productos.Add(productoElectronico);
                    Console.WriteLine("Producto agregado al inventario.");
                    break;
                default:
                    Console.WriteLine("Seleccione una categoria correcta.");
                    break;
            }



        }

        // Leer
        public void MostrarTodosLosProductos()
        {
            Console.WriteLine("Lista de productos en inventario:");
            foreach (var producto in productos)
            {
                producto.MostrarInformacion();
            }
        }
        public void MostrarProductosPorCategoria(string categoria)
        {
            Console.WriteLine($"\nProductos en la categoría {categoria}:");
            foreach (var producto in productos.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)))
            {
                producto.MostrarInformacion();
            }
        }

        // Actualizar
        public void ActualizarProducto(string nombre, decimal nuevoPrecio, int nuevaCantidad)
        {
            var producto = productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                producto.CantidadDisponible = nuevaCantidad;
                Console.WriteLine($"Producto {nombre} actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine($"Producto {nombre} no encontrado.");
            }
        }

        // Eliminar
        public void EliminarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto a eliminar:");
            string nombre = Console.ReadLine();
            var producto = productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto {nombre} eliminado del inventario.");
            }
            else
            {
                Console.WriteLine($"Producto {nombre} no encontrado.");
            }
        }

        public Producto BuscarProducto(string nombre)
        {
            return productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}