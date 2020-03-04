namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Ingatlan állapot modell
    /// </summary>
    public class IngatlanAllapot
    {
        public string Elnevezes { get; set; }

        public override string ToString()
        {
            return $"{Elnevezes}";
        }
    }
}
