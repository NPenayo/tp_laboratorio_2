using System;
using Datos;
using Controladores.Entidades;
using System.Collections.Generic;

namespace Test

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ticket ticket = new Ticket("Titulo","Esto es un ticket de prueba","FM1245","CL5465","MOG3Cel");   
            Incidente incidente = new Incidente("FM1245","Descripcion");

        }
    }
}
