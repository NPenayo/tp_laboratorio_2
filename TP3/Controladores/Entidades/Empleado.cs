using Controladores.Interfaces;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.Entidades
{
    public class Empleado : Usuario, ICRUD<Empleado>
    {
        private string _password;
        private ETipoEmpleado _tipoEmpleado;
        private static List<Empleado> _empleados;
        public enum ETipoEmpleado
        {
            Administrativo,
            Tecnico,
            Soporte
        }
        static Empleado()
        {
            _empleados = new List<Empleado>();
        }
        public Empleado()
        {
        }
        public Empleado(string nombre, string apellido, string dni, string email, string telefono, string direccion, string password, ETipoEmpleado tipoEmpleado) : base(nombre, apellido, dni, email, telefono, direccion)
        {
            try
            {
                Password = password;
                TipoEmpleado = tipoEmpleado;
            }
            catch (Exception)
            {

                throw new FormatException($"Error al crear la instancia de {this}");
            }
        }
        #region Propiedades
        public string Password { get { return _password; } set { _password = value; } }
        public ETipoEmpleado TipoEmpleado { get { return _tipoEmpleado; } set { try { _tipoEmpleado = value; } catch (Exception) { throw new FormatException(); } } }
        #endregion  
        #region CRUD
        public Empleado Crear(Empleado objeto)
        {
            try
            {
                objeto.Id = base.GenerarID();
                _empleados.Add(objeto);
            }
            catch (Exception e)
            {
                Log.Crear(e, Log.ETipoLog.Error);
                throw new Exception("No se pudo agregar el cliente a la lista");
            }
            return objeto;
        }

        public static List<Empleado> Listar()
        {
            return _empleados;
        }

        public Empleado Mostrar(string Id)
        {
            throw new NotImplementedException();
        }

        public Empleado Eliminar(string Id)
        {
            throw new NotImplementedException();
        }

        public Empleado Actualizar<K, V>(string id, Dictionary<K, V> parametros)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
