namespace EquipmentMainteneanceTracker.Models
{
    // represents a piece of equipment in the maintenance tracking system
    // data members are public properties with getters and setters, allowing for easy data binding in the UI
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = "Operational";
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDate { get; set; }
        public string Notes { get; set; } = string.Empty; // string.Empty is used to avoid null reference issues in the UI
    }
}