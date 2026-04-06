namespace RepairIS.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Manufacturer { get; set; }
        public int OwnerId { get; set; }
    }
}