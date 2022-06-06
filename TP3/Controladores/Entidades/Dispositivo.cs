using Controladores.Interfaces;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores.Entidades
{
    public class Dispositivo : ICRUD<Dispositivo>
    {
        public enum ETipoDispositivo
        {
            Celular,
            Tablet,
            Notebook
        }
        private string _id;
        private string _marca;
        private string _modelo;
        private ETipoDispositivo _tipoDispositivo;
        private static List<Dispositivo> _dispositivos;
        static Dispositivo()
        {
            _dispositivos = new List<Dispositivo>(); 
        }
        public Dispositivo()
        {

        }
        public Dispositivo(string marca, string modelo, ETipoDispositivo tipoDispositivo)
        {
            Id = GenerarId();
            Marca = marca;
            Modelo = modelo;
            TipoDispositivo = tipoDispositivo;
        }
        #region Propiedades
        public string Id { get => _id; set => _id = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public ETipoDispositivo TipoDispositivo { get => _tipoDispositivo; set => _tipoDispositivo = value; }
        #endregion
        #region CRUD
        /// <summary>
        /// Generar Id de dispositivo
        /// </summary>
        /// <returns>Id de dispositivo</returns>
        /// <exception cref="FormatException"></exception>
        private string GenerarId()
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{Marca.Substring(0,2)}{Modelo.Substring(0,2)}{TipoDispositivo.ToString().Substring(0, 3)}");
                return sb.ToString().Trim();
            }
            catch (Exception)
            {

                throw new FormatException();
            }
        }
        public Dispositivo Crear(Dispositivo objeto)
        {
            Dispositivo dispositivoNuevo = objeto;
            try
            {
                dispositivoNuevo.Id = GenerarId();
                if (!_dispositivos.Contains(dispositivoNuevo))
                {
                    _dispositivos.Add(dispositivoNuevo);
                }
            }
            catch (Exception e)
            {
                Log.Crear(e, Log.ETipoLog.Error);
                throw new Exception($"No se pudo crear el dispositivo");
            }
            return dispositivoNuevo;
         
        }

        public Dispositivo Eliminar(string Id)
        {
            throw new NotImplementedException();
        }

        public Dispositivo Mostrar(string Id)
        {
            throw new NotImplementedException();
        }
        public static List<Dispositivo> Listar()
        {
            return _dispositivos;
        }

        public Dispositivo Actualizar<K, V>(string id, Dictionary<K, V> parametros)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
