using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Shift Shift { get; set; }
        public string Licence { get; set; }
        public DateTime ExpiaryDateLicence { get; set; }
        public Car? AsignedCar { get; set; }

        public Driver(string firstName, string lastName, string licence, DateTime expiaryDateLicence)
        {
            FirstName = firstName;
            LastName = lastName;
            Licence = licence;
            ExpiaryDateLicence = expiaryDateLicence;
            AsignedCar = null;
        }

        public override string Print()
        {
            return $"Id: {Id} " +
                $"Name: {FirstName} {LastName} " +
                $"Shift: {Shift} " +
                $"Taxi Licence: {Licence} " +
                $"Expires: {ExpiaryDateLicence.ToString("dd, MM, yyyy")} " +
                $"Car: {(CheckCarStatus() ? AsignedCar.Model : "no car") }";
        }

        public bool CheckCarStatus()
        {
            if (AsignedCar == null)
            {
                return false;
            }

            return true;
        }
    }
}
