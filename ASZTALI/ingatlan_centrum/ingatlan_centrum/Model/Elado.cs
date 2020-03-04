namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Eladó modell
    /// </summary>
    public class Elado
    {
        public int Id { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public int Adoszam { get; set; }
        public string Telepules { get; set; }
        public string Lakcim { get; set; }
        public string Telefonszam { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id} {Vezeteknev} {Keresztnev} {Adoszam} {Telepules} {Lakcim} {Telefonszam} {Email}";
        }
    }
}
