using System;

namespace RepairIS.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string Description { get; set; }
        public string WorkRequired { get; set; }
        public string PartsNeeded { get; set; }
        public float LaborHours { get; set; }
        public float EstimatedCost { get; set; }
        public DateTime InspectionDate { get; set; }
    }
}