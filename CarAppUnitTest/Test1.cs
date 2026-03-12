using CarApp;

namespace CarAppUnitTest
{

    [TestClass]
    public sealed class CarTests
    {
        [TestMethod]
        public void GetTripsByDate_ReturnMatchingTrips()
        {
            // Arrange
            Car car = new Car("Mazda", "3", 2019, FuelType.diesel, "A", 64000, false, 19);
            Trip trip1 = new Trip(car, 100, DateTime.Now, DateTime.Now.AddHours(2));
            Trip trip2 = new Trip(car, 50, DateTime.Now, DateTime.Now.AddHours(5));
            Trip trip3 = new Trip(car, 50, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(5));

            car.ToggleEngine();
            car.Drive(trip1);
            car.Drive(trip2);
            car.Drive(trip3);


            // Act
            List<Trip> result = car.GetTripsByDate(DateTime.Now);





            // Assert
            Assert.AreEqual(2, result.Count);

        }
    }

}
