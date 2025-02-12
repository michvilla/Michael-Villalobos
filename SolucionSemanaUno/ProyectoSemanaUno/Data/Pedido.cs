using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemanaUno.Data
{
    public class Pedido
    {
        private List<Producto> productosEnPedido = new List<Producto>();
        private Inventario inventario;
        public int IdPedido { get; set; }
        public string cliente { get; set; }

        public Pedido(Inventario inventario)
        {
            this.inventario = inventario;
        }

        public void AgregarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad del producto:");
            int cantidad = int.Parse(Console.ReadLine());

            Producto producto = inventario.BuscarProducto(nombre);

            if (producto != null && producto.EstaDisponible(cantidad))
            {
                producto.ReducirInventario(cantidad);
                productosEnPedido.Add(producto);
                Console.WriteLine($"{cantidad} unidad(es) de {nombre} agregadas al pedido.");
            }
            else
            {
                Console.WriteLine($"No hay suficiente stock de {nombre}.");
            }
        }

        public void EliminarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();

            Producto productoEnPedido = productosEnPedido.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (productoEnPedido != null)
            {
                productosEnPedido.Remove(productoEnPedido);

                Producto productoInventario = inventario.BuscarProducto(nombre);
                if (productoInventario != null)
                {
                    productoInventario.CantidadDisponible += productoEnPedido.CantidadDisponible;
                }

                Console.WriteLine($"{productoEnPedido.CantidadDisponible} unidad(es) de {nombre} eliminadas del pedido y devueltas al inventario.");
            }
            else
            {
                Console.WriteLine($"El producto {nombre} no está en el pedido.");
            }
        }

        public void MostrarPedido()
        {
            if (productosEnPedido.Count == 0)
            {
                Console.WriteLine("El pedido está vacío.");
                return;
            }

            decimal costoTotal = 0;
            Console.WriteLine("Cliente: {0}", cliente);
            Console.WriteLine("\nProductos en el pedido:");
            foreach (var producto in productosEnPedido)
            {
                Console.WriteLine($"{producto.Nombre} - {producto.CantidadDisponible} unidades - ${producto.Precio} c/u - Total: ${producto.Precio * producto.CantidadDisponible}");
                costoTotal += producto.Precio * producto.CantidadDisponible;
            }
            Console.WriteLine($"\nCosto total del pedido: ${costoTotal}");
        }

        public void EditarPedido()
        {
            Console.WriteLine("Ingrese el nombre del producto a modificar:");
            string nombre = Console.ReadLine();

            Producto productoEnPedido = productosEnPedido.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (productoEnPedido != null)
            {
                Console.WriteLine($"Cantidad actual en pedido: {productoEnPedido.CantidadDisponible}");
                Console.Write("Ingrese la nueva cantidad: ");
                int nuevaCantidad = int.Parse(Console.ReadLine());

                Producto productoInventario = inventario.BuscarProducto(nombre);
                int diferencia = nuevaCantidad - productoEnPedido.CantidadDisponible;

                if (productoInventario != null && productoInventario.EstaDisponible(diferencia))
                {
                    productoInventario.ReducirInventario(diferencia);
                    productoEnPedido.CantidadDisponible = nuevaCantidad;
                    Console.WriteLine("Pedido actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine("Cantidad insuficiente en inventario para actualizar el pedido.");
                }
            }
            else
            {
                Console.WriteLine($"El producto {nombre} no está en el pedido.");
            }
        }



    }



}