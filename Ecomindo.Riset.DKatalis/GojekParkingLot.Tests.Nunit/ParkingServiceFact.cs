using GojekParkingLot.BLL;
using NUnit.Framework;

namespace GojekParkingLot.Tests
{
    public class ParkingServiceFact
    {
        [TestFixture]
        public class CreateParkingLot
        {
            [Test]
            public void SuccessfullyCreatedALot()
            {
                ParkingService svc = new ParkingService();
                string lotNumber = "6";
                Assert.Equal($"Created a parking lot with {lotNumber} slots\n", svc.CreateParkingLot(lotNumber));
            }

            [Test]
            public void InsertNonNumberValue()
            {
                ParkingService svc = new ParkingService();
                string lotNumber = "abc";
                Assert.Equal($"Error in converting number {lotNumber}\n", svc.CreateParkingLot(lotNumber));
            }
        }

        public class GetSlotNumberByRegistrationNumber
        {
            [Test]
            public void NotFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");

                Assert.Equal("Not found\n", svc.GetSlotNumberByRegistrationNumber("REG-01"));
            }

            [Test]
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
            [Test]
            public void NotFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");

                Assert.Equal("Not found\n", svc.GetSlotNumbersByColour("White"));
            }

            [Test]
            public void OneFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("2");
                svc.Park("REG-01", "White");
                svc.Park("REG-02", "Black");

                Assert.Equal("1\n", svc.GetSlotNumbersByColour("White"));
            }

            [Test]
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
            [Test]
            public void NotFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");

                Assert.Equal("Not found\n", svc.GetRegistrationNumbersByColour("White"));
            }

            [Test]
            public void OneFound()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("2");
                svc.Park("REG-01", "White");
                svc.Park("REG-02", "Black");

                Assert.Equal("REG-01\n", svc.GetRegistrationNumbersByColour("White"));
            }

            [Test]
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
            [Test]
            public void GetStatusOneData()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");
                svc.Park("1", "1");

                string result = $"Slot No.\tRegistration No\t\tColour\n";
                result += $"1\t\t1\t\t1\n";

                Assert.Equal(result, svc.GetStatus());
            }

            [Test]
            public void GetStatusNoData()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");
                Assert.Equal($"Slot No.\tRegistration No\t\tColour\n\n", svc.GetStatus());
            }
        }

        public class Leave
        {
            [Test]
            public void SuccessfullyLeave()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");
                svc.Park("1", "1");

                Assert.Equal($"Slot number 1 is free\n", svc.Leave("1"));
            }

            [Test]
            public void InsertNonNumberValue()
            {
                ParkingService svc = new ParkingService();
                string slotNumber = "abc";

                Assert.Equal($"Error in converting number {slotNumber}\n", svc.Leave(slotNumber));
            }
        }

        public class Park
        {
            [Test]
            public void SuccessfullyParked()
            {
                ParkingService svc = new ParkingService();
                svc.CreateParkingLot("1");

                Assert.Equal($"Allocated slot number: 1\n", svc.Park("1", "1"));
            }

            [Test]
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
