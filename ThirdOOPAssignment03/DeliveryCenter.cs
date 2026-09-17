using System;
using ThirdOOPAssignment;

namespace ThirdOOPAssignment
{
    public class DeliveryCenter
    {
        public string CenterName { get; set; }

        
        public Driver Driver { get; set; }

        private Shipment[] shipments;
        private int shipmentCount;

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;

            shipments = new Shipment[20];

            shipmentCount = 0;
        }

        public void AddShipment(Shipment shipment)
        {
            if (shipmentCount < shipments.Length)
            {
                shipments[shipmentCount] = shipment;
                shipmentCount++;

                Console.WriteLine(
                    "Shipment Added Successfully.");
            }
            else
            {
                Console.WriteLine(
                    "Delivery Center is full.");
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0;
                     i < shipmentCount;
                     i++)
                {
                    if (shipments[i].TrackingCode
                        .ToLower()
                        ==
                        trackingCode.ToLower())
                    {
                        return shipments[i];
                    }
                }

                return null;
            }
        }

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 &&
                    index < shipmentCount)
                {
                    return shipments[index];
                }

                return null;
            }
        }

        public bool RemoveShipment(
            string trackingCode)
        {
            for (int i = 0;
                 i < shipmentCount;
                 i++)
            {
                if (shipments[i].TrackingCode
                    .ToLower()
                    ==
                    trackingCode.ToLower())
                {
                    for (int j = i;
                         j < shipmentCount - 1;
                         j++)
                    {
                        shipments[j] =
                            shipments[j + 1];
                    }

                    shipments[shipmentCount - 1] =
                        null;

                    shipmentCount--;

                    return true;
                }
            }

            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                "Delivery Center");

            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                $"Driver : {Driver.FullName}");

            Console.WriteLine(
                "------------------------------------------");

            for (int i = 0;
                 i < shipmentCount;
                 i++)
            {
                shipments[i].PrintShipment();
            }

            Console.WriteLine(
                "==========================================");
        }
    }
}