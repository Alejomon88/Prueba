
using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public EscuelaEngine(Escuela escuela)
        {
            this.Escuela = escuela;

        }
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            //TODO constructor
        }
        public void Inicializar()
        {
            Escuela = new Escuela("Escuela 123", 1989, TiposEscuela.Primaria, "Colombia", "Bogota");
            CargarCursos();
            var evaluaciones = CargarEvaluaciones();
        }

        private List<Evaluacion> CargarEvaluaciones()
        {
            string[] periodos = {"Corte1","Corte2","Corte3","Final"};
            Random rnd =new Random();

            List<Evaluacion> evaluaciones = new List<Evaluacion>();
            
            foreach (var curso in Escuela.Cursos)
            {
                evaluaciones.AddRange( from alumno in curso.Alumnos
                                        from asignatura in curso.Asigaturas
                                        from periodo in periodos
                                        select new Evaluacion {Alumno=alumno,Asignatura=asignatura,Nombre=periodo,Nota=NumeroAleatorio()}                                        
                );
            }
            return evaluaciones.OrderByDescending(eval => eval.Nota ).ToList();
        }

        private float NumeroAleatorio()
        {
            Random rnd = new Random();
            return (float)(rnd.NextDouble()*rnd.Next(0,5));
        }

        private List<Alumno> CargarAlumnos()
        {
            Random rnd = new Random();
            string[] nombres = { "Alejo", "Luis", "Pepito", "Paco" };
            string[] apellidos = { "Sasa", "Rodriguez", "Alzate", "Pardo" };

            return (from nombre in nombres
                    from apellido in apellidos
                    select new Alumno { Nombre = $"{nombre} {apellido}" }
                    ).OrderBy(alu => alu.UniqueID).Take(rnd.Next(5,10)).ToList();

        }

        private List<Asignatura> CargarAsignaturas() => new List<Asignatura>
            {
                new Asignatura(){Nombre="Educacion fisica"},
                new Asignatura(){Nombre="Matematicas"},
                new Asignatura(){Nombre="Gramatica"},
                new Asignatura(){Nombre="Ingles"},
                new Asignatura(){Nombre="Quimica"}
            };

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>
            {
                new Curso(){Nombre="101",Jornada=TipoJornada.Mañana, Alumnos = CargarAlumnos(), Asigaturas= CargarAsignaturas()},
                new Curso(){Nombre="201",Jornada=TipoJornada.Mañana, Alumnos = CargarAlumnos(), Asigaturas= CargarAsignaturas()},
                new Curso(){Nombre="301",Jornada=TipoJornada.Mañana, Alumnos = CargarAlumnos(), Asigaturas= CargarAsignaturas()},
                new Curso(){Nombre="401",Jornada=TipoJornada.Tarde, Alumnos = CargarAlumnos(), Asigaturas= CargarAsignaturas()},
                new Curso(){Nombre="501",Jornada=TipoJornada.Tarde, Alumnos = CargarAlumnos(), Asigaturas= CargarAsignaturas()},
            };
        }
    }
}