using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }
        public TipoJornada Jornada { get; set; }
        public List<Asignatura> Asigaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public Curso ()
        {
            UniqueID = Guid.NewGuid().ToString();
        }
    }
}