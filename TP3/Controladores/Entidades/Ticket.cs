using Controladores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.Entidades
{
    public class Ticket : ICRUD<Ticket>
    {
        public enum EEstadoTicket
        {
            Abierto,
            Pendiente,
            Cerrado
        }
        private string _id;
        private string _titulo;
        private string _descripcion;
        private string _idEmpleado;
        private string _idCliente;
        private string _idDispositivo;
        private static int _ultimonumeroTicket = 0;
        private DateTime _fechaCreado;
        private DateTime _fechaActualizado;
        private DateTime _fechaCerrado;
        private EEstadoTicket _estadoTicket;
        private List<Incidente> _incidentes;
        private static List<Ticket> _tickets;
        static Ticket()
        {
            _tickets = new List<Ticket>();
            _ultimonumeroTicket++;
        }
        public Ticket()
        {

        }
        public Ticket(string titulo, string descripcion, string idEmpleado, string idCliente, string idDispositivo)
        {
            try
            {

                Titulo = titulo;
                Descripcion = descripcion;
                IdEmpleado = idEmpleado;
                IdCliente = idCliente;
                IdDispositivo = idDispositivo;
                FechaCreado = DateTime.Now;
                EstadoTicket = EEstadoTicket.Abierto;
                _incidentes = new List<Incidente>();
                Id = GenerarId();
            }
            catch (Exception)
            {

                throw new FormatException($"Error al crear la instancia de {this}");

            }

        }
        #region Propiedades
        public string Id { get { return _id; } private set { _id = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string IdEmpleado { get { return _idEmpleado; } set { _idEmpleado = value; } }
        public string IdCliente { get { return _idCliente; } set { _idCliente = value; } }
        public string IdDispositivo { get => _idDispositivo; set => _idDispositivo = value; }
        public DateTime FechaCreado { get { return _fechaCreado; } set { _fechaCreado = value; } }
        public DateTime FechaActualizado { get { return _fechaActualizado; } set { _fechaActualizado = value; } }
        public DateTime FechaCerrado { get { return _fechaCerrado; } set { _fechaCerrado = value; } }
        public EEstadoTicket EstadoTicket { get { return _estadoTicket; } set { _estadoTicket = value; } }
        public List<Incidente> Incidentes { get { return _incidentes; } set { _incidentes = value; } }
        #endregion
        /// <summary>
        /// Generar Id de ticket
        /// </summary>
        /// <returns>Id de ticket</returns>
        /// <exception cref="FormatException"></exception>
        private string GenerarId()
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"SD{_ultimonumeroTicket.ToString("00000.##")}");
                return sb.ToString().Trim();
            }
            catch (Exception)
            {

                throw new FormatException();
            }
        }
        #region CRUD
        public Ticket Crear(Ticket objeto)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> Listar()
        {
            return _tickets;
        }

        public Ticket Mostrar(string Id)
        {
            throw new NotImplementedException();
        }

        public Ticket Eliminar(string Id)
        {
            throw new NotImplementedException();
        }

        public Ticket Actualizar<K, V>(string id, Dictionary<K, V> parametros)
        {
            throw new NotImplementedException();
        }
        #endregion CRUD

    }
}
