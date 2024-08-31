using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

namespace TodoListApp
{
    public class Task
    {
        public string Descripcion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public  bool TareaCompletada { get; set; }

        public Task(string descripcion, DateTime? fechaVencimiento = null)
        {
            Descripcion = descripcion;
            FechaVencimiento = fechaVencimiento;
            TareaCompletada = false;
        }

        public override string ToString()
        {
            return $"{Descripcion} - {(FechaVencimiento.HasValue ? FechaVencimiento.Value.ToShortDateString() : "Sin fecha limite")} {(TareaCompletada ? "Completada" : "Pendiente")}";
        }
    }
}
