// Cambio en mastervv
using System;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueID { get; private set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }
    }
}