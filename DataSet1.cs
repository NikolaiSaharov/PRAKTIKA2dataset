using System;

namespace PRAKTIKA_1._2
{


    partial class DataSet1
    {
    }
}

namespace PRAKTIKA_1._2.DataSet1TableAdapters {


    public partial class FlightsTableAdapter
    {
        internal void DeleteQuery(int originalFlightId, string originalFlightNumber, string originalDepartureAirport, string originalArrivalAirport, DateTime originalDepartureTime, DateTime originalArrivalTime, int flightId)
        {
            throw new NotImplementedException();
        }

        internal void DeleteQuery(int flightId)
        {
            throw new NotImplementedException();
        }

        internal void InsertQuery(int flightId, string flightNumber, string departureAirport, string arrivalAirport, DateTime departureTime, DateTime arrivalTime)
        {
            throw new NotImplementedException();
        }

        internal void UpdateQuery(int flightId1, string flightNumber, string departureAirport, string arrivalAirport, DateTime departureTime, DateTime arrivalTime, int flightId2)
        {
            throw new NotImplementedException();
        }

        internal void UpdateQuery(string newFlightNumber, string newDepartureAirport, string newArrivalAirport, DateTime newDepartureTime, DateTime newArrivalTime, int flightId)
        {
            throw new NotImplementedException();
        }
    }
}
