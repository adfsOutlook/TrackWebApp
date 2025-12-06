using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public static class InputTextExtensionMethods
    {
        public static readonly IJSRuntime _js;

      
        public static async Task FocusAsync(this ElementReference elementRef, IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync(
                "JsFunctions.focusElement", elementRef);
        }



        public static async Task FocusAsyncB(string elementId, IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync(
                "JsFunctions.focusElementB", elementId);
        }

        public static async Task EnableAsyncB(string elementId,bool truefalse, IJSRuntime jsRuntime)
        {
           
            await jsRuntime.InvokeVoidAsync(
                "JsFunctions.enableElementB", elementId, truefalse);
        }








        public static async Task DisableAsync(this ElementReference elementRef, IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync(
                "JsFunctions.disableElement", elementRef);
        }


       



    }
}
