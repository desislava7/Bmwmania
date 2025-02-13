namespace Bmwmania.Data
{
    public class Automobile
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public int ModelId { get; set; }//fk  M:1
        public Model Models { get; set; }//table M:1
        public string Type { get; set; }
        public int FuelId { get; set; }
        public Fuel Fuels { get; set; } 
        public int EqExteriorId { get; set; }
        public EqExterior EqExteriors { get; set; }
        public int EqInteriorsId { get; set; }
        public EqInterior EqInteriors { get; set; }
        public int EqDigitId { get; set; }
        public EqDigit EqDigits { get; set; }
        public int EqLightId { get; set; }
        public EqLight EqLights { get; set; }
        public int Power { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public DateTime DateReg { get; set; }

        public ICollection<Reservations> Reservations { get; set; }
    }
}
