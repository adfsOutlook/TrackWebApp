using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public  class PersistenciaCotizacion
    {
        private readonly IJSRuntime js;
        public PersistenciaCotizacion(IJSRuntime js)
        {
            this.js = js;
           
        }
        public async Task Set(string oKey ,string oJson)
        {
            await js.SetInLocalStorage(oKey, oJson);
            
        }
    }
}
