using System;
using System.Collections.Generic;
using System.Text;

namespace CarApp
{
    public class Trip
    {
        // Atrributes
   
        private readonly Car _car;
       

        // Properties
        public double Distance { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime TripDate { get; set; }
       

        // Konstruktøre 
        public Trip(Car car, double distance, DateTime startTime, DateTime endTime)
        {
            _car = car;
            Distance = distance;
            StartTime = startTime;
            EndTime = endTime;
            TripDate = startTime.Date;
        }
        // Metoder
        public TimeSpan CalculateDuration() 
        {
        return EndTime - StartTime;
        }

        public double CalculateFuelUsed()
        {
            return Distance / _car.KmPerLiter;
        }
        public double CalculateTripPrice(double literPrice)
        {
            return literPrice * CalculateFuelUsed();   
        }
        public string GetTripDetails()
        {
            return $"TripDate: {TripDate:yyyy-MM-dd} | Distance: {Distance} km | " +
                   $"Start: {StartTime:HH:mm} End: {EndTime:HH:mm} | " +
                   $"Duration: {CalculateDuration()} | FuelUsed: {CalculateFuelUsed():F2} L";
        }
    }
}