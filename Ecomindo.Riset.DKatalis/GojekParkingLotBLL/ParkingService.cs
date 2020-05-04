using GojekParkingLot.DAL;
using System;
using System.Collections.Generic;

namespace GojekParkingLot.BLL
{
    public class ParkingService
    {
        private static ParkingDataService svc;

        public ParkingService()
        {
            svc = new ParkingDataService();
        }

        public string CreateParkingLot(string lotNumber)
        {
            int lot;
            try
            {
                lot = Int32.Parse(lotNumber);
            }
            catch (Exception)
            {
                return $"Error in converting number {lotNumber}\n";
            }
            svc.Initialized(lot);
            return $"Created a parking lot with {lotNumber} slots\n";
        }

        public string GetSlotNumberByRegistrationNumber(string registrationNumber)
        {
            List<ParkingDTO> tmp = svc.GetDatasByRegistrationNo(registrationNumber);
            if (tmp.Count > 0)
            {
                List<string> result = new List<string>();
                foreach (var item in tmp)
                {
                    result.Add(item.SlotNumber.ToString());
                }
                return $"{String.Join(", ", result)}\n";
            }
            else
            {
                return "Not found\n";
            }
        }

        public string GetSlotNumbersByColour(string colour)
        {
            List<ParkingDTO> tmp = svc.GetDatasByColour(colour);
            if (tmp.Count > 0)
            {
                List<string> result = new List<string>();
                foreach (var item in tmp)
                {
                    result.Add(item.SlotNumber.ToString());
                }
                return $"{String.Join(", ", result)}\n";
            }
            else
            {
                return "Not found\n";
            }
        }

        public string GetRegistrationNumbersByColour(string colour)
        {
            List<ParkingDTO> tmp = svc.GetDatasByColour(colour);
            if (tmp.Count > 0)
            {
                List<string> result = new List<string>();
                foreach (var item in tmp)
                {
                    result.Add(item.RegistrationNumber);
                }
                return $"{String.Join(", ", result)}\n";
            }
            else
            {
                return "Not found\n";
            }

        }

        public string GetStatus()
        {
            string result;
            List<ParkingDTO> tmp = svc.GetAllData();
            result = $"Slot No.\tRegistration No\t\tColour\n";
            foreach (var item in tmp)
            {
                result += $"{item.SlotNumber}\t\t{item.RegistrationNumber}\t\t{item.Colour}";
            }
            result += "\n";
            return result;
        }

        public string Leave(string slotNumber)
        {
            int no;
            try
            {
                no = Int32.Parse(slotNumber);
            }
            catch (Exception)
            {
                return $"Error in converting number {slotNumber}\n";
            }
            svc.Delete(no);
            return $"Slot number {slotNumber} is free\n";
        }

        public string Park(string registrationNumber, string colour)
        {
            int slotNo = svc.Insert(registrationNumber, colour);
            if (slotNo == -1)
            {
                return $"Sorry, parking lot is full\n";
            }
            else
            {
                return $"Allocated slot number: {slotNo}\n";
            }

        }
    }
}
