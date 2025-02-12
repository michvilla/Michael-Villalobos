// See https://aka.ms/new-console-template for more information
using ProyectoSemanaUno.Data;

Inventario inventario = new Inventario();
List<Pedido> pedidos = new List<Pedido>();
bool salir = false;

while (!salir)
{
    try
    {
        Console.WriteLine("\n--- Menú Principal ---");
        Console.WriteLine("1. Inventario");
        Console.WriteLine("2. Pedidos");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                bool menuInventario = false;
                while (!menuInventario)
                {
                    Console.WriteLine("Administracion de Inventario");
                    Console.WriteLine("1. Agregar Producto");
                    Console.WriteLine("2. Editar Producto");
                    Console.WriteLine("3. Eliminar Producto");
                    Console.WriteLine("4. Mostrar Inventario");
                    Console.WriteLine("5. Salir");
                    int opcionInventario = int.Parse(Console.ReadLine());

                    switch (opcionInventario)
                    {
                        case 1:
                            inventario.AgregarProducto();
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el nombre del producto a editar:");
                            string nombreProducto = Console.ReadLine();

                            Console.WriteLine("Ingrese el nuevo precio del producto a editar:");
                            decimal nuevoPrecio = decimal.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese la nueva cantidad disponible del producto a editar:");
                            int nuevaCantidadDisponible = int.Parse(Console.ReadLine());

                            inventario.ActualizarProducto(nombreProducto, nuevoPrecio, nuevaCantidadDisponible);

                            break;
                        case 3:
                            inventario.EliminarProducto();
                            break;
                        case 4:
                            inventario.MostrarTodosLosProductos();
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del sistema!");
                            menuInventario = true;
                            break;
                        default:
                            Console.WriteLine("Por favor seleccionar una opcion entre 1 y 5.");
                            break;
                    }
                }

                break;
            case 2:
                AdministrarPedido();
                break;
            case 3:
                Console.WriteLine("Saliendo del sistema.");
                salir = true;
                break;
            default:
                Console.WriteLine("Por favor escoger una opcion entre 1 y 3.");
                break;
        }



    }
    catch (Exception ex)
    {

        Console.WriteLine($"Error: {ex.Message}");
    }
}

void AdministrarPedido()
{
    bool menuPedido = false;
    while (!menuPedido)
    {
        Console.WriteLine("Administracion de Pedido");
        Console.WriteLine("1. Agregar Pedido");
        Console.WriteLine("2. Editar Pedido");
        Console.WriteLine("3. Eliminar Pedido");
        Console.WriteLine("4. Mostrar Pedidos");
        Console.WriteLine("5. Salir");
        int opcionInventario = int.Parse(Console.ReadLine());

        switch (opcionInventario)
        {
            case 1:
                Pedido nuevoPedido = new Pedido(inventario);
                bool agregarProductos = true;

                while (agregarProductos)
                {
                    nuevoPedido.AgregarProducto();

                    Console.Write("¿Desea agregar otro producto a este pedido? (s/n): ");
                    agregarProductos = Console.ReadLine().Trim().ToLower() == "s";
                }
                pedidos.Add(nuevoPedido);
                break;

            case 2:

                Console.WriteLine("Ingrese el nombre del producto a editar:");
                string nombreProducto = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo precio del producto a editar:");
                decimal nuevoPrecio = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la nueva cantidad disponible del producto a editar:");
                int nuevaCantidadDisponible = int.Parse(Console.ReadLine());

                inventario.ActualizarProducto(nombreProducto, nuevoPrecio, nuevaCantidadDisponible);

                break;
            case 3:

                pedidos.Remove(inventario);

                break;
            case 4:
                foreach (var pedido in pedidos)
                {
                    pedido.MostrarPedido();
                    Console.WriteLine("-----------------------\n");
                }
                break;
            case 5:
                Console.WriteLine("Saliendo del sistema de pedidos!");
                menuPedido = true;
                break;
            default:
                Console.WriteLine("Por favor seleccionar una opcion entre 1 y 5.");
                break;
        }
    }


}


