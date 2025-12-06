using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public class MostrarMensajes : IMostrarMensajes
    {
        private readonly IJSRuntime js;

        public MostrarMensajes(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task MostrarMensajeError(string mensaje)
        {
            await MostrarMensaje("Error", mensaje, "error");
        }

        public async Task MostrarMensajeExitoso(string mensaje)
        {
            await MostrarMensaje("Exitoso", mensaje, "success");
        }

        private async ValueTask MostrarMensaje(string titulo, string mensaje, string tipoMensaje)
        {
            await js.InvokeVoidAsync("Swal.fire", titulo, mensaje, tipoMensaje);
        }
        public async Task MostrarMensajeBase(string titulo, string mensaje, string tipoMensaje)
        {
            await js.InvokeVoidAsync("Swal.fire", titulo, mensaje, tipoMensaje);
        }


        public async Task<bool> MostrarMensajeConfimacion(string titulo, string mensaje, string tipoMensaje)
        {
            //ASOSA TODO MEJORAR ELIMINAR LE JS Utils.js
            var confirmacion = await js.InvokeAsync<bool>("confirmar", titulo, mensaje, tipoMensaje);
           
      //      var confirmacion = await js.InvokeAsync<bool>(
      //" return new Promise(resolve => { Swal.fire({ title: " + titulo + ", text: " + mensaje + ", icon: " + tipoMensaje + ", showCancelButton: true, confirmButtonColor: '#3085d6', cancelButtonColor: '#d33', confirmButtonText: 'Confirmar!' }).then((result) => { resolve(result.isConfirmed); }); }) ");



            return confirmacion;
        }
        

        public async Task MostrarMensajeConImagen(string mensaje)
        {
          await js.InvokeVoidAsync("Swal.fire({title: 'Sweet!',text: 'Modal with a custom image.',imageUrl: '/images/Coberturas/a.png',imageWidth: 400,imageHeight: 200,imageAlt: 'Custom image',})");
        }

       
    }
}
