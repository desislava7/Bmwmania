namespace Bmwmania.Data
{
    public class Fuel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateReg { get; set; }


        public ICollection<Automobile> Automobiles { get; set; }

    }
}
