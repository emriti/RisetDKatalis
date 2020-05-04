using GojekParkingLot.BLL;
using Xunit;

namespace GojekParkingLot.Tests
{
    public class ParkingServiceFact
    {
        public class CreateParkingLot
        {
            [Fact]
            public void SuccessfullyCreatedALot()
            {
                ParkingService svc = new ParkingService();
                string lotNumber = "6";
                Assert.Equal($"Created a parking lot with {lotNumber} slots\n", svc.CreateParkingLot(lotNumber));
            }

            [Fact]
            public void InsertNonNumberValue()
            {
                ParkingService svc = new ParkingService();
                string lotNumber = "abc";
                Assert.Equal($"Error in converting number {lotNumber}\n", svc.CreateParkingLot(lotNumber));
            }
        }

        public class GetSlotNumberByRegistrationNumber
        {
            [Fact]
            public void NotFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");

                Assert.Equal("Not found\n", svc.GetSlotNumberByRegistrationNumber("REG-01"));
            }

            [Fact]
            public void OneFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("2");
                svc.Park("REG-01", "White");
                svc.Park("REG-02", "Black");

                Assert.Equal("2\n", svc.GetSlotNumberByRegistrationNumber("REG-02"));
            }
        }

        public class GetSlotNumbersByColour
        {
            [Fact]
            public void NotFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");

                Assert.Equal("Not found\n", svc.GetSlotNumbersByColour("White"));
            }

            [Fact]
            public void OneFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("2");
                svc.Park("REG-01", "White");
                svc.Park("REG-02", "Black");

                Assert.Equal("1\n", svc.GetSlotNumbersByColour("White"));
            }

            [Fact]
            public void TwoDataFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("2");
                svc.Park("REG-01", "White");
                svc.Park("REG-02", "White");

                Assert.Equal("1, 2\n", svc.GetSlotNumbersByColour("White"));
            }
        }

        public class GetRegistrationNumbersByColour
        {
            [Fact]
            public void NotFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");

                Assert.Equal("Not found\n", svc.GetRegistrationNumbersByColour("White"));
            }

            [Fact]
            public void OneFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("2");
                svc.Park("REG-01", "White");
                svc.Park("REG-02", "Black");

                Assert.Equal("REG-01\n", svc.GetRegistrationNumbersByColour("White"));
            }

            [Fact]
            public void TwoDataFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("2");
                svc.Park("REG-01", "White");
                svc.Park("REG-02", "White");

                Assert.Equal("REG-01, REG-02\n", svc.GetRegistrationNumbersByColour("White"));
            }
        }

        public class GetStatus
        {
            [Fact]
            public void GetStatusOneData()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");
                svc.Park("1", "1");

                string result = $"Slot No.\tRegistration No\t\tColour\n";
                result += $"1\t\t1\t\t1\n";

                Assert.Equal(result, svc.GetStatus());
            }

            [Fact]
            public void GetStatusNoData()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");
                Assert.Equal($"Slot No.\tRegistration No\t\tColour\n\n", svc.GetStatus());
            }
        }

        public class Leave
        {
            [Fact]
            public void SuccessfullyLeave()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");
                svc.Park("1", "1");

                Assert.Equal($"Slot number 1 is free\n", svc.Leave("1"));
            }

            [Fact]
            public void InsertNonNumberValue()
            {
                ParkingService svc = new ParkingService();
                string slotNumber = "abc";

                Assert.Equal($"Error in converting number {slotNumber}\n", svc.Leave(slotNumber));
            }
        }

        public class Park
        {
            [Fact]
            public void SuccessfullyParked()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");

                Assert.Equal($"Allocated slot number: 1\n", svc.Park("1", "1"));
            }

            [Fact]
            public void ParkingFull()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");
                svc.Park("1", "1");

                Assert.Equal($"Sorry, parking lot is full\n", svc.Park("2", "2"));
            }

        }

    }
}
