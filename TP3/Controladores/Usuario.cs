using System;
using System.Collections.Generic;

namespace Controladores
{
    public abstract class Usuario : ICRUD<Usuario>
    {
        private string _id;
        private string _nombre;
        private string _apellido;
        private string _dni;
        private string _email;
        private string _telefono;
        private string _direccion;
        public Usuario(string id, string nombre, string apellido, string dni, string email, string telefono, string direccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
        }
        #region Propiedades
        public string Id { get { return _id; } private set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Dni { get { return _dni; } set { _dni = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        #endregion
        #region CRUD
        public abstract Usuario Actualizar<U>(params U[] parametros);
        public abstract Usuario Crear();
        public abstract Usuario Eliminar(string Id);
        public virtual List<Usuario> Mostrar()
        {
            return Mock<Usuario>.lista;
        }
        public abstract Usuario Mostrar(string Id);
        #endregion
    }
}
