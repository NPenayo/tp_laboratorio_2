using System;
using System.IO;


namespace Datos
{
    public static class Log
    {
        public enum ETipoLog
        {
            Error,
            Advertencia,
            Info
        }
        private static string rutaLogs = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Logs";
        private static string nombreArchivo = @$"\Log_{DateTime.Now.ToString("dd_MM_yyyy")}.txt";

        public static void Crear(int codigoError, string mensaje, ETipoLog tipoLog)
        {
            try
            {
                if (!Directory.Exists(rutaLogs))
                {
                    Directory.CreateDirectory(rutaLogs);
                }
                using (StreamWriter sw = new StreamWriter($"{rutaLogs + nombreArchivo}", true))
                {
                    sw.WriteLine($"[{DateTime.Now.ToString("H:mm:ss")}] {tipoLog.ToString()} - {mensaje} - Error: {codigoError.ToString()}");
                }
            }
            catch (Exception)
            {

                throw new Exception($"No se encontró el archivo{rutaLogs + nombreArchivo}");
            }

        }
        public static void Crear(string mensaje, ETipoLog tipoLog)
        {
            try
            {
                if (!Directory.Exists(rutaLogs))
                {
                    Directory.CreateDirectory(rutaLogs);
                }
                using (StreamWriter sw = new StreamWriter($"{rutaLogs + nombreArchivo}", true))
                {
                    sw.WriteLine($"[{DateTime.Now.ToString("H:mm:ss")}] {tipoLog.ToString()} - {mensaje}");
                }
            }
            catch (Exception)
            {

                throw new Exception($"No se encontró el archivo{rutaLogs + nombreArchivo}");
            }
        }
        public static void Crear(Exception e, ETipoLog tipoLog)
        {
            try
            {
                if (!Directory.Exists(rutaLogs))
                {
                    Directory.CreateDirectory(rutaLogs);
                }

                using (StreamWriter sw = new StreamWriter($"{rutaLogs + nombreArchivo}", true))
                {
                    sw.WriteLine($"[{DateTime.Now.ToString("H:mm:ss")}] {tipoLog.ToString()} - {e.Message}");
                }
            }
            catch (Exception)
            {

                throw new Exception($"No se encontró el archivo{rutaLogs + nombreArchivo}");
            }
        }
    }
}
