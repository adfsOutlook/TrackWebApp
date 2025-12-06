using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace Project.Client.Helpers
{
    public  class Utilidades
    {
        private readonly IJSRuntime js;
        public Utilidades(IJSRuntime js)
        {
            this.js = js;
        }
     

    }
}
