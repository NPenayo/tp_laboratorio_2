using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface IArchivo
    {
        static List<T> Abrir<T>(string nombreArchivo) { return new List<T>(); }
        static void Guardar<T>(T objeto, string nombreArchivo) { }


    }
}
