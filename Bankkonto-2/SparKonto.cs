using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonto_2
{
    public class SparKonto : BankKonto
    {
        public SparKonto(int kontoNummer, double anfangsGuthaben) : base(kontoNummer, anfangsGuthaben) { }

        public override void Beziehe(double betrag)
        {
            if (Guthaben >= betrag)
            {
                Guthaben -= betrag;
            }
            else
            {
                throw new InvalidOperationException("Nicht genügend Guthaben");
            }
        }
    }
}
