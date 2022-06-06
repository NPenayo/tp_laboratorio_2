using System;
using System.Collections.Generic;
using System.Text;

namespace Controladores.Entidades
{
    public abstract class Usuario
    {
        private string _id;
        private string _nombre;
        private string _apellido;
        private string _dni;
        private string _email;
        private string _telefono;
        private string _direccion;
        private static List<Usuario> _usuarios;
        static Usuario()
        {
            _usuarios = new List<Usuario>();
        }
        public Usuario()
        {

        }
        public Usuario(string nombre, string apellido, string dni, string email, string telefono, string direccion)
        {
            try
            {
                Nombre = nombre;
                Apellido = apellido;
                Dni = dni;
                Email = email;
                Telefono = telefono;
                Direccion = direccion;
                Id = GenerarID();
            }
            catch (Exception)
            {

                throw new FormatException($"Error al crear la instancia de {this}");
            }
        }
        #region Propiedades
        public string Id { get { return _id; } protected set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Dni { get { return _dni; } set { if (Seguridad.Dni(value)) { _dni = value; } else { throw new FormatException("Formato de DNI invalido"); } } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        #endregion
        protected string GenerarID()
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{Nombre[0]}{Apellido[0]}{Dni.Substring(4, 4)}");
                return sb.ToString().Trim();
            }
            catch (Exception)
            {

                throw new FormatException();
            }
        }
    }
}
