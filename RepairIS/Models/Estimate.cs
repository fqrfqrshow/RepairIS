namespace RepairIS.Models
{
    public class Estimate
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public float WorkCost { get; set; }
        public float PartsCost { get; set; }
        public float LogisticsCost { get; set; }
        public float ExtraCost { get; set; }
        public float TotalCost => WorkCost + PartsCost + LogisticsCost + ExtraCost;
        public bool IsConfirmed { get; set; }
    }
}