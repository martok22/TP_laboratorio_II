using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using System.Text;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testea si el dni es numérico
        /// </summary>
        [TestMethod]
        public void DniEsNumerico()
        {
            Alumno a1 = new Alumno(1, "German", "1234", "35233452", 
                Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            bool condicion = true;
            foreach (Char a in a1.Apellido)
            {
                if (!Char.IsDigit(a))
                    condicion = false;
            }
            Assert.IsTrue(condicion);
        }
        /// <summary>
        /// Testea si al agregar un alumno repetido lanza excepción de tipo AlumnoRepetidoExcepcion
        /// </summary>
        [TestMethod]
        public void AlumnoRepetidoExcepcion()
        {
            Alumno a1 = new Alumno(1, "Jorge", "Gonzalez", "353535", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(1, "Jorge", "Gonzalez", "353535", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Universidad u1 = new Universidad();
            u1 += a1;

            try
            {
                u1 += a2;
                Assert.Fail("No debería llegar acá");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
            }

        }
        /// <summary>
        /// Testea que los atributos nombre y apellido de un objeto Alumno no sean null.
        /// </summary>
        [TestMethod]
        public void AtributosNoSonNull()
        {
            try
            {
                Alumno a1 = new Alumno(55, null, null, "3333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
            }
        }
        /// <summary>
        /// Testea si un dni negativo lanza la excepción DniInvalidoExcepcion
        /// </summary>
        [TestMethod]
        public void DniInvalidoExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(1, "German", "Garmendia", "-1234", Persona.ENacionalidad.Argentino,
                Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

    }
}
