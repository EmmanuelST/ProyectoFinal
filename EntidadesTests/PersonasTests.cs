using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Tests
{
    [TestClass()]
    public class PersonasTests
    {
        [TestMethod()]
        public void ValidarTelefonoTest()
        {
            Assert.IsTrue(Personas.ValidarTelefono("80922410"));
        }
    }
}