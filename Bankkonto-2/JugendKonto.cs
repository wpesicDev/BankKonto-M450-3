using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonto_2
{
    public class JugendKonto : BankKonto
    {
        private const double Bezugslimite = 500;
        private const double Vorzugszins = 0.03;
        private const int MaxAlter = 20;


        public JugendKonto(int kontoNummer, double anfangsGuthaben, int alter) : base(kontoNummer, anfangsGuthaben)
        {
            if (alter >= MaxAlter)
            {
                throw new InvalidOperationException("Alter über 20 Jahre");
            }
        }

        public override void Beziehe(double betrag)
        {
            if (betrag > Bezugslimite)
            {
                throw new InvalidOperationException("Bezugslimite überschritten");
            }

            if (Guthaben >= betrag)
            {
                Guthaben -= betrag;
            }
            else
            {
                throw new InvalidOperationException("Nicht genügend Guthaben");
            }
        }

        public new void SchreibeZinsGut(int anzTage)
        {
            ZinsGuthaben += Guthaben * Vorzugszins / 365 * anzTage;
        }
    }
}
