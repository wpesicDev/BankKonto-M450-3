using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonto_2
{
    public class PrivatKonto : BankKonto
    {
        private const double MaximalerÜberziehungskredit = 1000;
        private const double JahresGebühr = 50;

        public PrivatKonto(int kontoNummer, double anfangsGuthaben) : base(kontoNummer, anfangsGuthaben) { }

        public override void Beziehe(double betrag)
        {
            if (Guthaben - betrag >= -MaximalerÜberziehungskredit)
            {
                Guthaben -= betrag;
            }
            else
            {
                throw new InvalidOperationException("Überziehungslimit erreicht");
            }
        }

        public new void SchliesseKontoAb()
        {
            base.SchliesseKontoAb();
            Guthaben -= JahresGebühr;
        }
    }

}
