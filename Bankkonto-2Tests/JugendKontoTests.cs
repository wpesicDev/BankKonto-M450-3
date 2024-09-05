using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bankkonto_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonto_2.Tests
{
    [TestClass]
    public class BankkontoTests
    {
        [TestMethod]
        public void Privatkonto_Ueberziehung_Test()
        {
            PrivatKonto privatkonto = new PrivatKonto(1, 100);
            privatkonto.Beziehe(1100);
            Assert.AreEqual(-1000, privatkonto.Guthaben);

            Assert.ThrowsException<InvalidOperationException>(() => privatkonto.Beziehe(1));
        }

        [TestMethod]
        public void Sparkonto_NichtUeberziehbar_Test()
        {
            SparKonto sparkonto = new SparKonto(2, 100);
            Assert.ThrowsException<InvalidOperationException>(() => sparkonto.Beziehe(200));
        }

        [TestMethod]
        public void Jugendkonto_NichtUeberziehbar_Test()
        {
            JugendKonto jugendkonto = new JugendKonto(3, 100, 18);
            Assert.ThrowsException<InvalidOperationException>(() => jugendkonto.Beziehe(200));
        }

        [TestMethod]
        public void Jugendkonto_Bezugslimite_Test()
        {
            JugendKonto jugendkonto = new JugendKonto(3, 1000, 18);
            Assert.ThrowsException<InvalidOperationException>(() => jugendkonto.Beziehe(600));
        }

        [TestMethod]
        public void Jugendkonto_Vorzugszins_Test()
        {
            JugendKonto jugendkonto = new JugendKonto(3, 1000, 18);
            jugendkonto.SchreibeZinsGut(365);
            Assert.AreEqual(30, jugendkonto.ZinsGuthaben, 0.01);
        }

        [TestMethod]
        public void Privatkonto_Jahresgebuehr_Test()
        {
            PrivatKonto privatkonto = new PrivatKonto(1, 1000);
            privatkonto.SchliesseKontoAb();
            Assert.AreEqual(950, privatkonto.Guthaben);
        }

        [TestMethod]
        public void Einzahlen_Test()
        {
            PrivatKonto bankkonto = new PrivatKonto(1, 1000);
            bankkonto.ZahleEin(500);
            Assert.AreEqual(1500, bankkonto.Guthaben);
        }

        [TestMethod]
        public void Abheben_Test()
        {
            PrivatKonto bankkonto = new PrivatKonto(1, 1000);
            bankkonto.Beziehe(500);
            Assert.AreEqual(500, bankkonto.Guthaben);
        }
    }
}