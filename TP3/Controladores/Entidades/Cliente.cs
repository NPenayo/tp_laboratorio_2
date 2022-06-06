using Controladores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Controladores.Entidades
{
    public class Cliente : Usuario, ICRUD<Cliente>
    {
        private static List<Cliente> _clientes;
        public enum ETipoCliente
        {
            Garantia,
            Particular
        }
        private ETipoCliente tipoCliente;
        static Cliente()
        {
            _clientes = new List<Cliente>();
        }
        public Cliente()
        {
            
        }
        public Cliente(string nombre, string apellido, string dni, string email, string telefono, string direccion, ETipoCliente tipoCliente) : base(nombre, apellido, dni, email, telefono, direccion)
        {
            try
            {
                TipoCliente = tipoCliente;
            }
            catch (Exception)
            {

                throw new FormatException($"Error al crear la instancia de {this}");

            }
        }
        #region Propiedades
        public ETipoCliente TipoCliente { get { return tipoCliente; } set { try { tipoCliente = value; } catch (Exception) { throw new FormatException(); } } }
        #endregion
        #region CRUD
        public Cliente Crear(Cliente objeto)
        {
            try
            {
                objeto.Id = base.GenerarID();
                _clientes.Add(objeto);
            }
            catch (Exception e)
            {
                Log.Crear(e, Log.ETipoLog.Error);
                throw new Exception("No se pudo agregar el cliente a la lista");
            }
            return objeto;
        }

        public static List<Cliente> Listar()
        {
            return _clientes;
        }

        public Cliente Mostrar(string Id)
        {
            throw new NotImplementedException();
        }

        public Cliente Eliminar(string Id)
        {
            Cliente clienteBorrado = null;
            foreach (Cliente cliente in _clientes)
            {
                if(cliente.Id == Id)
                {
                    clienteBorrado = cliente;
                    _clientes.Remove(cliente);
                    break;
                }
            }
            return clienteBorrado;
        }

        public Cliente Actualizar<K, V>(string id, Dictionary<K, V> parametros)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
