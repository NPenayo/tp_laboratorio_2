using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controladores.Entidades
{
    public static class Seguridad
    {
        /// <summary>
        /// Valida que el formato de la fecha sea dd/MM/yyyy
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>true | false</returns>
        public static bool Fecha(string fecha)
        {
            if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime nacimiento))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Valida que el DNI este conformado por 8 numeros
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>true | false</returns>
        public static bool Dni(string dni)
        {
            string patron = @"^(\d){8}$";
            Regex reg = new Regex(patron);
            if (reg.IsMatch(dni))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Valida que la clave tenga solo numeros, letras, al menos una mayucula y entre 6 y 15 caracteres
        /// </summary>
        /// <param name="password"></param>
        /// <returns>true | false</returns>
        public static bool FormatoPassword(string password)
        {
            string patron = @"(?=.*[A-Z])(^[a-z]|[0-9]|[A-Z])+[^\%\-\$\'\?\¿\¡\!]([\w\d]){6,15}";
            Regex reg = new Regex(patron);
            if (reg.IsMatch(password))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Valida las credenciales del usuario
        /// </summary>
        /// <param name="empleados"></param>
        /// <param name="nombreDeUsuario"></param>
        /// <param name="password"></param>
        /// <returns>true | false</returns>
        public static Empleado Credenciales(string nombreDeUsuario, string password)
        {

            foreach (Empleado item in Empleado.Listar())
            {

                if (string.Equals(item.Id, nombreDeUsuario, StringComparison.OrdinalIgnoreCase) && item.Password == password)
                {
                    return item;
                }

            }
            return null;
        }

        /// <summary>
        /// Encripta la clave de un usuario
        /// </summary>
        /// <param name="password"></param>
        /// <returns>string</returns>
        public static string EncriptarPassword(string password)
        {
            byte[] passwordEncodead = new UTF8Encoding().GetBytes(password);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(passwordEncodead);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }
    }
}
