using System;
using System.Collections.Generic;

namespace GojekParkingLot.DAL
{
    public class ParkingDataService: IDisposable
    {
        //public  void Main(String[] args)
        //{
        //    Initialized(6);
        //    Console.WriteLine(Insert("1", "black"));
        //    Console.WriteLine(FindEmptyArrayIndex());
        //    Console.WriteLine(Insert("2", "black"));
        //    Console.WriteLine(FindEmptyArrayIndex());
        //    Console.WriteLine(Insert("3", "black"));
        //}

        private static ParkingDTO[] parkings;

        public ParkingDataService()
        {
            Reset();
        }

        public void Reset()
        {
            parkings = Array.Empty<ParkingDTO>();
        }

        public void Initialized(int no)
        {
            Array.Resize(ref parkings, no);
        }

        public int Insert(string registrationNo, string colour)
        {
            if (parkings.Length > 0)
            {
                int id = FindEmptyArrayIndex();
                if (id != -1)
                {
                    parkings[id] = new ParkingDTO { SlotNumber = id + 1, RegistrationNumber = registrationNo, Colour = colour };
                    return id + 1;
                }
                return id;
            }
            else
            {
                throw new Exception("initialized data first!");
            }
        }

        public int Delete(int slotNo)
        {
            if (slotNo > 0 && parkings.Length + 1 >= slotNo)
            {
                parkings[slotNo - 1] = null;
                return slotNo;
            }
            return -1;
        }

        public List<ParkingDTO> GetAllData()
        {
            List<ParkingDTO> result = new List<ParkingDTO>();
            foreach (var item in parkings)
            {
                if (item != null)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<ParkingDTO> GetDatasByColour(string colour)
        {
            List<ParkingDTO> result = new List<ParkingDTO>();
            foreach (var item in parkings)
            {
                if (item?.Colour == colour)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<ParkingDTO> GetDatasByRegistrationNo(string registrationNo)
        {
            List<ParkingDTO> result = new List<ParkingDTO>();
            foreach (var item in parkings)
            {
                if (item?.RegistrationNumber == registrationNo)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private int FindEmptyArrayIndex()
        {
            if (parkings.Length > 0)
            {
                int i = 0;
                foreach (var item in parkings)
                {
                    if (item == null)
                    {
                        return i;
                    }
                    i++;
                }
                return -1;
            }
            else
            {
                throw new Exception("initialized data first!");
            }
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
