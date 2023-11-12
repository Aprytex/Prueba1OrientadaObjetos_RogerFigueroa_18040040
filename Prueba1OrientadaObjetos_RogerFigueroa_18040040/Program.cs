using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Empleado;

class Program
{
    static List<Empleado> empleados = new List<Empleado>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Agregar empleado");
            Console.WriteLine("2. Calcular salario de empleado por cédula");
            Console.WriteLine("3. Mostrar información de empleado por cédula");
            Console.WriteLine("4. Mostrar todos los empleados");
            Console.WriteLine("5. Salir");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    CalcularSalarioPorCedula();
                    break;
                case 3:
                    MostrarInformacionPorCedula();
                    break;
                case 4:
                    MostrarTodosLosEmpleados();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    static void AgregarEmpleado()
    {
        Console.WriteLine("Seleccione el tipo de empleado:");
        Console.WriteLine("1. Asalariado");
        Console.WriteLine("2. Por Hora");
        Console.WriteLine("3. Por Comisión");

        int tipoEmpleado = int.Parse(Console.ReadLine());

        Console.Write("Cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Activo (Si (Escribalo tal cual como se ve aqui) o No): ");
        bool activo = Console.ReadLine().Equals("Si", StringComparison.OrdinalIgnoreCase);

        switch (tipoEmpleado)
        {
            case 1:
                Console.Write("Salario Mensual: ");
                double salarioMensual = double.Parse(Console.ReadLine());
                empleados.Add(new EmpleadoAsalariado(cedula, nombre, activo, salarioMensual));
                break;
            case 2:
                Console.Write("Precio por Hora: ");
                double precioHora = double.Parse(Console.ReadLine());
                Console.Write("Horas Trabajadas: ");
                int horasTrabajadas = int.Parse(Console.ReadLine());
                empleados.Add(new EmpleadoPorHora(cedula, nombre, activo, precioHora, horasTrabajadas));
                break;
            case 3:
                Console.Write("Ventas Mensuales: ");
                double ventasMensuales = double.Parse(Console.ReadLine());
                Console.Write("Porcentaje de Comisión: ");
                double porcentajeComision = double.Parse(Console.ReadLine());
                empleados.Add(new EmpleadoPorComision(cedula, nombre, activo, ventasMensuales, porcentajeComision));
                break;
            default:
                Console.WriteLine("Tipo de empleado no válido.");
                break;
        }

        Console.WriteLine("Empleado agregado con éxito.");
    }

    static void CalcularSalarioPorCedula()
    {
        Console.Write("Ingrese la cédula del empleado: ");
        string cedula = Console.ReadLine();

        foreach (var empleado in empleados)
        {
            if (empleado.Cedula == cedula)
            {
                Console.WriteLine($"Salario de {empleado.Nombre}: {empleado.CalcularSalario():C}");
                return;
            }
        }

        Console.WriteLine("Empleado no encontrado.");
    }

    static void MostrarInformacionPorCedula()
    {
        Console.Write("Ingrese la cédula del empleado: ");
        string cedula = Console.ReadLine();

        foreach (var empleado in empleados)
        {
            if (empleado.Cedula == cedula)
            {
                Console.WriteLine(empleado);
                return;
            }
        }

        Console.WriteLine("Empleado no encontrado.");
    }

    static void MostrarTodosLosEmpleados()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
        }
        else
        {
            Console.WriteLine("Lista de Empleados:");
            foreach (var empleado in empleados)
            {
                Console.WriteLine(empleado);
            }
        }
    }
}