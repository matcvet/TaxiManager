namespace TaxiManager9000.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string LicencePlate { get; set; }
        public DateTime ExpiaryDateLicencePlate { get; set; }

        public List<Driver> AssignedDrivers { get; set; }

        public Car(string model, string licencePlate, DateTime expiaryDateLicencePlate)
        {
            Model = model;
            LicencePlate = licencePlate;
            ExpiaryDateLicencePlate = expiaryDateLicencePlate;
            AssignedDrivers = new List<Driver>();
        }

        public override string Print()
        {
            return $"Id: {Id}\nModel: {Model}\nLicencePlate: {LicencePlate} - {ExpiaryDateLicencePlate}";
        }
    }
}
