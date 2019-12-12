using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;
using Archivos;
namespace PruebaUniversidad
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ValidarExcepcionDni()
        {
            Profesor p = new Profesor(2, "Roberto", "Juarez", "-1",
             EntidadesAbstractas.Persona.ENacionalidad.Argentino);


        }
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ValidarExcepcioAlumnoRep()
        {
            Alumno a = new Alumno(2, "Roberto", "Juarez", "10",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno b = new Alumno(2, "Roberto", "Juarez", "10",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Universidad u = new Universidad();
            u += a;
            u += b;
        }
        [TestMethod]
        public void TestDniAmbosCasos()
        {
            string prueba = "10";
            Alumno b = new Alumno(2, "Roberto", "Juarez", prueba,
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreEqual(b.DNI,10);
        }
        [TestMethod]
        public void AlumnosNoNull()
        {
            Universidad u = new Universidad();

            Assert.IsNotNull(u.Alumnos);

        }


    }
}