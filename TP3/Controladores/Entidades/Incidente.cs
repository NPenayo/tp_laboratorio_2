using Controladores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.Entidades
{
    public class Incidente : ICRUD<Incidente>
    {
        public enum EEstadoIncidente
        {
            Abierto,
            Pendiente,
            Cerrado
        }
        private string _id;
        private string _idAsignado;
        private DateTime _fechaCreado;
        private DateTime _fechaActualizado;
        private DateTime _fechaCerrado;
        private string _descripcion;
        private EEstadoIncidente _estadoIncidente;
        private static List<Incidente> _incidentes;
        private static int _ultimoNumeroIncidente = 0;

        static Incidente()
        {
            _incidentes = new List<Incidente>();
            _ultimoNumeroIncidente++;
        }

        public Incidente()
        {

        }
        public Incidente(string idAsignado,string descripcion) 
        {
            try
            {
                IdAsignado = idAsignado;
                FechaCreado = DateTime.Now;
                Descripcion = descripcion;
                EstadoIncidente = EEstadoIncidente.Abierto;
                Id = GenerarId();

            }
            catch (Exception)
            {

                throw new FormatException($"Error al crear la instancia de {this}");

            }

        }
        #region Propiedades
        public string Id { get { return _id; } private set { _id = value; } }
        public string IdAsignado { get { return _idAsignado; } set { _idAsignado = value; } }
        public DateTime FechaCreado { get { return _fechaCreado; } set { _fechaCreado = value; } }
        public DateTime FechaActualizado { get { return _fechaActualizado; } set { _fechaActualizado = value; } }
        public DateTime FechaCerrado { get { return _fechaCerrado; } set { _fechaCerrado = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public EEstadoIncidente EstadoIncidente { get { return _estadoIncidente; } set { _estadoIncidente = value; } }
        #endregion
        #region CRUD
        public Incidente Crear(Incidente objeto)
        {
            throw new NotImplementedException();
        }

        public static List<Incidente> Listar()
        {
            return _incidentes;
        }
        public Incidente Mostrar(string Id)
        {
            throw new NotImplementedException();
        }

        public Incidente Eliminar(string Id)
        {
            throw new NotImplementedException();
        }

        public Incidente Actualizar<K, V>(string id, Dictionary<K, V> parametros)
        {
            throw new NotImplementedException();
        }
        #endregion
        /// <summary>
        /// Generar Id de incidente
        /// </summary>
        /// <returns>Id de incidente</returns>
        /// <exception cref="FormatException"></exception>
        private string GenerarId()
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"IM{_ultimoNumeroIncidente.ToString("00000.##")}");
                return sb.ToString().Trim();
            }
            catch (Exception)
            {

                throw new FormatException();
            }
        }
    }
}
