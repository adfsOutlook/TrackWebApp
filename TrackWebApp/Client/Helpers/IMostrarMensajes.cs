using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public interface IMostrarMensajes
    {

        Task MostrarMensajeError(string mensaje);
        Task MostrarMensajeExitoso(string mensaje);
        Task MostrarMensajeBase(string titulo, string mensaje, string tipoMensaje);

        Task<bool> MostrarMensajeConfimacion(string titulo, string mensaje, string tipoMensaje);

        Task MostrarMensajeConImagen( string mensaje);
    }
}
