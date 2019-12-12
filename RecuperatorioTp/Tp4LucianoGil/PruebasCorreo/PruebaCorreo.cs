using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace PruebasCorreo
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void InstanciaPaquetesNoNull()
        {
            Correo correo = new Correo();


            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void NoRepetirId()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("sarasa", "1111");
            Paquete paquete2 = new Paquete("sarasaDos", "1111");

            correo += paquete1;
            correo += paquete2;
        }
    }
}