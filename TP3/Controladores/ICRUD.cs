using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public interface ICRUD<T>
    {
        T Crear();
        List<T> Mostrar();
        T Mostrar(string Id);
        T Actualizar<U>(params U[] parametros);
        T Eliminar(string Id);

    }
}
