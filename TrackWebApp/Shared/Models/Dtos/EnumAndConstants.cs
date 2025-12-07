using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Models
{


    public enum EstadoEntrega
    {
        Creando = 0,
        EnCurso = 2,
        Demorado = 4,
        Suspendido = 6,
        Cancelado = 7,
        Entregado = 9
    }
}
