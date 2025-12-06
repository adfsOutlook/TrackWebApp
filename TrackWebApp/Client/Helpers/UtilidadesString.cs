using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.Helpers
{
    public class UtilidadesString
    {
        public static string Enmayuscular(string valor) => valor.ToUpper();

        public static string GetRandomString(int length)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }


        public static bool ValidateCUIT(string cuit)
        {
            var mk_suma = default(int);
            bool mk_valido = false;
            cuit = cuit.Replace("-", "");

            if (cuit.Length != 11)
            {
                return false;
            }

            mk_suma = 0;
            mk_suma += int.Parse((cuit.Substring(0, 1))) * 5;
            mk_suma += int.Parse((cuit.Substring(1, 1))) * 4;
            mk_suma += int.Parse((cuit.Substring(2, 1))) * 3;
            mk_suma += int.Parse((cuit.Substring(3, 1))) * 2;
            mk_suma += int.Parse((cuit.Substring(4, 1))) * 7;
            mk_suma += int.Parse((cuit.Substring(5, 1))) * 6;
            mk_suma += int.Parse((cuit.Substring(6, 1))) * 5;
            mk_suma += int.Parse((cuit.Substring(7, 1))) * 4;
            mk_suma += int.Parse((cuit.Substring(8, 1))) * 3;
            mk_suma += int.Parse((cuit.Substring(9, 1))) * 2;
            mk_suma += int.Parse((cuit.Substring(10, 1))) * 1;


            if (Math.Round(mk_suma / (double)11, 0) == mk_suma / (double)11)
            {
                mk_valido = true;
            }
            else
            {
                mk_valido = false;
            }



            return mk_valido;
        }

        public static bool ValidateCUIT2(string cuit)
        {
            if (string.IsNullOrEmpty(cuit)) throw new ArgumentNullException(nameof(cuit));
            if (cuit.Length != 13) throw new ArgumentException(nameof(cuit));
            bool rv = false;
            int verificador;
            int resultado = 0;
            string cuit_nro = cuit.Replace("-", string.Empty);
            string codes = "6789456789";
            long cuit_long = 0;
            if (long.TryParse(cuit_nro, out cuit_long))
            {
                verificador = int.Parse(cuit_nro[cuit_nro.Length - 1].ToString());
                int x = 0;
                while (x < 10)
                {
                    int digitoValidador = int.Parse(codes.Substring((x), 1));
                    int digito = int.Parse(cuit_nro.Substring((x), 1));
                    int digitoValidacion = digitoValidador * digito;
                    resultado += digitoValidacion;
                    x++;
                }
                resultado = resultado % 11;
                rv = (resultado == verificador);
            }
            return rv;
        }


    }



   
}
