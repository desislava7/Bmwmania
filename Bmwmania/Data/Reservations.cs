namespace Bmwmania.Data
{
    public class Reservations
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User Users { get; set; }
        public int AutomobileId { get; set; }
        public Automobile Automobiles { get; set; }
        public DateTime DateReservation { get; set; }
        public DateTime DateReg { get; set; }   

    }
}
