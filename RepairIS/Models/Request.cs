using System;

namespace RepairIS.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int MasterId { get; set; }
        public int ClientId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string ContactPhone { get; set; }
        public string InspectionMethod { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}