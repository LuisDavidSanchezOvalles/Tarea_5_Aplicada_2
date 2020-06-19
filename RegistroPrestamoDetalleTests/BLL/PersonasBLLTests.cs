using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrestamoDetalle.BLL;
using RegistroPrestamoDetalle.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamoDetalle.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Personas personas = new Personas();
            personas.PersonaId = 0;
            personas.Nombres = "Jose";
            personas.Telefono = " 8295669999 ";
            personas.Cedula = " 0565555559 ";
            personas.Direccion = "Duarte sfm";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;
            paso = PersonasBLL.Guardar(personas);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Personas personas = new Personas();
            personas.PersonaId = 2;
            personas.Nombres = "Jose Luis";
            personas.Telefono = " 8295669999 ";
            personas.Cedula = " 0565555559 ";
            personas.Direccion = "Duarte sfm";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;
            paso = PersonasBLL.Guardar(personas);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Personas personas;
            personas = PersonasBLL.Buscar(2);

            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void GetPersonasTest()
        {
            var lista = new List<Personas>();
            lista = PersonasBLL.GetList(p => true);
            Assert.AreEqual(lista, lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PersonasBLL.Eliminar(2);
            Assert.AreEqual(paso, true);
        }
    }
}