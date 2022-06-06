using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Datos
{
    public class ArchivoJSON : IArchivo
    {
        private static readonly string ruta = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Usuarios";
        public static List<T> Abrir<T>(string nombreArchivo)
        {
            List<T> datos = default;
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                string json = File.ReadAllText(@$"{ruta}\{nombreArchivo}.json");
                datos = JsonSerializer.Deserialize<List<T>>(json);
                return datos;
            }
            catch (Exception e)
            {
                Log.Crear(e, Log.ETipoLog.Error);
                throw new Exception($"No se encontró el archivo {nombreArchivo}.json");
            }
        }
        public static void Guardar<T>(T objeto, string nombreArchivo)
        {
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                string json = JsonSerializer.Serialize(objeto);
                File.WriteAllText(@$"{ruta}\{nombreArchivo}.json",json);

            }
            catch (Exception e)
            {
                Log.Crear(e, Log.ETipoLog.Error);
                throw new Exception($"No se encontró el archivo {nombreArchivo}.json");
            }
        }
    }
}
