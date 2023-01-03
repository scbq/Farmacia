using ConLaFarmacia.Clases;
using ConLaFarmacia.Colection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConLaFarmacia
{
    //Felipe Aguilera Rut:1577715275
    internal class Program
    {
        static Farmacia miFarmacia = new Farmacia("Buena Salud", "productos.txt");
        static void Main(string[] args)
        {
            

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("---Farmacia---");
                Console.WriteLine("1.- Mostrar Productos");
                Console.WriteLine("2.- Mostrar Productos con Recarga de Precios");
                Console.WriteLine("3.- Lista de Productos superiores a $15.000");
                Console.WriteLine("4.- Eliminar Producto con valor menor a 1.000");
                Console.WriteLine("5.- Descuento dia Lunes");
                Console.WriteLine("6.- Mostrar Productos por codigo");
                Console.WriteLine("0.- Para Salir");
                Console.Write("Ingrese una opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine(miFarmacia.ToString());
                        Console.ReadKey();
                        break;

                    case 2:
                        miFarmacia.Recarga();
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("Numero de Productos superior a $15.000:  " + miFarmacia.ListarProductos());
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("Productos Eliminados inferior a $1.000:  " + miFarmacia.Eliminar());
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("Ingrese el dia de la Semana: ");
                        if (Console.ReadLine().ToUpper().Contains("LUNES"))
                        {
                            Console.WriteLine("Desceunto dia Lunes");
                            miFarmacia.SumarDescuento();
                        }
                        else
                        {
                            Console.WriteLine("No se aplican dctos");
                        }
                        Console.ReadKey();
                        break;

                        case 6:
                        Console.WriteLine("Ingrese el codigo del Producto:  ");
                        string codigo = Console.ReadLine();
                        miFarmacia.Mostrar(codigo);
                        Console.ReadKey();
                        break;
                }
            }
            while (opcion != 0);
        }
    }
}
