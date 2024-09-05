using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonto_2
{
    public abstract class BankKonto : IKonto
    {
        public int KontoNummer { get; private set; }
        public double Guthaben { get; protected set; }
        public double ZinsGuthaben { get; protected set; }

        public static double AktivZins = 0.015;
        public static double PassivZins = 0.05;

        protected BankKonto(int kontoNummer, double anfangsGuthaben)
        {
            KontoNummer = kontoNummer;
            Guthaben = anfangsGuthaben;
        }

        public virtual void ZahleEin(double betrag)
        {
            Guthaben += betrag;
        }

        public abstract void Beziehe(double betrag);

        public void Transferiere(IKonto zielkonto, double betrag)
        {
            Beziehe(betrag);
            zielkonto.ZahleEin(betrag);
        }

        public void SchreibeZinsGut(int anzTage)
        {
            ZinsGuthaben = Guthaben * AktivZins / 365 * anzTage;
        }

        public void SchliesseKontoAb()
        {
            Guthaben += ZinsGuthaben;
        }
    }
}
