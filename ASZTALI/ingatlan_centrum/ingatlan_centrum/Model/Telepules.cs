namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Település modell
    /// </summary>
    public class Telepules
    {
        public string Nev { get; set; }

        public override string ToString()
        {
            return $"{Nev}";
        }
    }
}
