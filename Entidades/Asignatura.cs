using System;

namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        public string UniqueID { get; private set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }
    }
}