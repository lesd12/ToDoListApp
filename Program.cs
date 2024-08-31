using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TodoListApp
{
    class Program
    {
        static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {
            while (true)
            {

                mostrarmenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AgregarTarea();
                        break;
                    case "2":
                        ListarTareas();
                        break;
                    case "3":
                        MarcarTareaCompletada();
                        break;
                    case "4":
                        EliminarTarea();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opcion no valida, intenta nuevamente.");
                        break;
                }
            }
        }

        static void mostrarmenu()
        {
            Console.WriteLine("\nLista de Tareas");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Listar Tareas");
            Console.WriteLine("3. Marcar Tarea Completada");
            Console.WriteLine("4. Eliminar Tarea");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Selecciona una opcion:");
        }

        static void AgregarTarea()
        {
            Console.Write("Descripcion de la tarea: ");
            string descripcion = Console.ReadLine();

            Console.Write("Feha limite (opcional, formato: dd/MM/yyyy): ");
            string fechaVencimientoString = Console.ReadLine();


            DateTime? fechaVencimiento = null;
            if (DateTime.TryParse(fechaVencimientoString, out DateTime parsedDate))
            {
                fechaVencimiento = parsedDate;
            }

            tasks.Add(new Task(descripcion, fechaVencimiento));
            Console.WriteLine("Tarea agregada exitosamente.");

        }


        static void ListarTareas()
        {
            Console.WriteLine("\nTareas Registradas:");
            if (tasks.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }

            }

        }


        static void MarcarTareaCompletada()
        {
            ListarTareas();
            Console.WriteLine("Numero de la tarea a marcar como completada");
            if (int.TryParse(Console.ReadLine(), out int numerotarea) && numerotarea <= tasks.Count)
            {
                tasks[numerotarea - 1].TareaCompletada = true;
                Console.WriteLine("Tarea marcada como completada.");
            }
            else
            {
                Console.WriteLine("Numero de tarea no valido");
            }
        }

        static void EliminarTarea()
        {
            ListarTareas();
            Console.WriteLine("Numero de la tarea a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int numerotarea) && numerotarea > 0 && numerotarea <= tasks.Count)
            {
                tasks.RemoveAt(numerotarea - 1);
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("Numero de tarea no valido.");
            }
        }
    }
}

