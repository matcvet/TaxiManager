namespace TaxiManager9000.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string LicencePlate { get; set; }
        public DateTime ExpiaryDateLicencePlate { get; set; }

        public List<Driver> AsignedDrivers { get; set; }

        public Car(string model, string licencePlate, DateTime expiaryDateLicencePlate)
        {
            Model = model;
            LicencePlate = licencePlate;
            ExpiaryDateLicencePlate = expiaryDateLicencePlate;
            AsignedDrivers = new List<Driver>();
        }

        public override string Print()
        {
            return $"Id: {Id} " +
                $"Model: {Model} " +
                $"LicencePlate: {LicencePlate} " +
                $"Expires: {ExpiaryDateLicencePlate.ToString("dd/MM/yyyy")}";
        }

        public string AsignedShifts()
        {
            return $"{AsignedDrivers.Count / 3 * 100}%";
        }

        public List<Driver> GetAssignedDrivers()
        {
            return AsignedDrivers;
        }
    }
}
