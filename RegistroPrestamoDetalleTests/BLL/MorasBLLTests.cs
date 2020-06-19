using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrestamoDetalle.BLL;
using RegistroPrestamoDetalle.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamoDetalle.BLL.Tests
{
    [TestClass()]
    public class MorasBLLTests
    {
        [TestClass()]
        public class MoraBLLTests
        {
            [TestMethod()]
            public void GuardarTest()
            {
                Moras mora = new Moras();
                mora.MoraId = 0;
                mora.Fecha = DateTime.Now;
                mora.Total = 10;
                mora.MoraDetalle.Add(new MorasDetalle
                {
                    MoraDetalleId = 0,
                    MoraId = mora.MoraId,
                    PrestamoId = 1,
                    Monto = 10
                });

                Assert.IsTrue(MorasBLL.Guardar(mora));
            }

            [TestMethod()]
            public void BuscarTest()
            {
                Moras mora;
                mora = MorasBLL.Buscar(1);
                Assert.IsNotNull(mora);
            }

            [TestMethod()]
            public void GetListTest()
            {
                var lista = new List<Moras>();
                lista = MorasBLL.GetList(p => true);
                Assert.IsNotNull(lista);
            }

            [TestMethod()]
            public void ExisteTest()
            {
                bool paso = MorasBLL.Existe(1);
                Assert.AreEqual(paso, true);
            }

            [TestMethod()]
            public void EliminarTest()
            {
                bool paso;
                paso = MorasBLL.Eliminar(1);
                Assert.AreEqual(paso, true);
            }
        }
    }
}