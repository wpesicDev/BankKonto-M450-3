namespace Bankkonto_2
{
    public interface IKonto
    {
        int KontoNummer { get; }
        double Guthaben { get; }
        void ZahleEin(double betrag);
        void Beziehe(double betrag);
        void Transferiere(IKonto zielkonto, double betrag);
        void SchreibeZinsGut(int anzTage);
        void SchliesseKontoAb();
    }
}
