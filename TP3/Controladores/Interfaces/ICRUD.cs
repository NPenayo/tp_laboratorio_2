using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.Interfaces
{
    internal interface ICRUD<T>
    {
        /// <summary>
        /// Agregar un objeto a su correspondiente lista
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns>T la misma instancia del objeto agregado</returns>
        T Crear(T objeto);
        /// <summary>
        /// Devuelve una lista de objetos de tipo T
        /// </summary>
        /// <returns>Lista de tipo T</returns>
        static List<T> Listar()
        {
            return new List<T>();
        }
        /// <summary>
        /// Buscar un objeto por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Instancia de objeto tipo T</returns>
        T Mostrar(string Id);
        /// <summary>
        /// Actualizar parametros de un objeto
        /// </summary>
        /// <typeparam name="K">Nombre del parametro</typeparam>
        /// <typeparam name="V">Nuevo Valor</typeparam>
        /// <param name="id">Id de objeto</param>
        /// <param name="parametros">Diccionario de parametros a cambiar</param>
        /// <returns>Instancia del objeto actualizado</returns>
        T Actualizar<K,V>(string id, Dictionary<K,V> parametros);
        /// <summary>
        /// Elimina un objeto de la lista mediante su Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Intancia del objeto eliminado</returns>
        T Eliminar(string Id);

    }
}
