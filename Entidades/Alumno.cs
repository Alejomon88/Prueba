// Cambio en mastervv
// Esto si funciona y hay q hacer un merge
using System;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueID { get; private set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }
    }
}