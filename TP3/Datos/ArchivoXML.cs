using System;
using System.Collections.Generic;
using System.IO;

namespace Datos
{
    public class ArchivoXML : IArchivo
    {
        private static readonly string ruta = @$"{AppDomain.CurrentDomain.BaseDirectory}\Tickets";
        public List<T> Abrir<T>(string nombreArchivo) 
        {
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
            }
            catch (Exception)
            {
                Log.Crear(new Exception($"No se encontró el archivo {nombreArchivo}"), Log.ETipoLog.Error);
                throw new Exception();
            }
            return new List<T>();
        }
        public static void Guardar<T>(T objeto, string nombreArchivo) { }
    }
}
