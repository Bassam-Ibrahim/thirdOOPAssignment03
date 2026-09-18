using System;
using ThirdOOPAssignment;

class program
{
    public static void Main(string[] args)
    {
        #region theoritical Questions
        /*
        First Overloading VS Overriding
         Overloading having multi methods with the same name but different parameters in the same class
         BUT Overriding is new implementation of a method in the derived class that is already defined in the base class.

        Second Question Sealed Classes and Methods
          a) The sealed keyword prevents a class from being inherited by another class or override a method .
          b) The sealed keyword prevents a method from being overridden in a derived class and for the class it will not be inherited.
          C) NO, sealed Methods cannot be overridden the current implementation is the final one.
        */
        #endregion

        #region testInMain

        Driver driver = new Driver(1, "Ahmed Mohamed", "01012345678");

        DeliveryCenter center = new DeliveryCenter("Cairo Center");

        center.Driver = driver;

        DeliveryAddress address1 = new DeliveryAddress(
            "Cairo",
            "Main Street",
            10
        );

        DeliveryAddress address2 = new DeliveryAddress(
            "Giza",
            "Pyramids Street",
            20
        );

        DeliveryAddress address3 = new DeliveryAddress(
            "Alexandria",
            "Sea Street",
            30
        );

        StandardShipment standardShipment = new StandardShipment(
            "SH001",
            "Laptop",
            3,
            80,
            address1
        );

        ExpressShipment expressShipment = new ExpressShipment(
            "SH002",
            "Mobile Phone",
            2,
            60,
            address2,
            30
        );

        InternationalShipment internationalShipment = new InternationalShipment(
            "SH003",
            "Television",
            8,
            120,
            address3,
            "Germany",
            100
        );

        center.AddShipment(standardShipment);
        center.AddShipment(expressShipment);
        center.AddShipment(internationalShipment);

        
        center.PrintAllShipments();

        
        Console.WriteLine();
        Console.WriteLine("Printing Using DeliveryHelper...");
        Console.WriteLine();

        DeliveryHelper.PrintShipmentDetails(standardShipment);
        Console.WriteLine("Standard Shipment Printed Successfully.");

        DeliveryHelper.PrintShipmentDetails(expressShipment);
        Console.WriteLine("Express Shipment Printed Successfully.");

        DeliveryHelper.PrintShipmentDetails(internationalShipment);
        Console.WriteLine("International Shipment Printed Successfully.");

        
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("Updating Weight...");
        Console.WriteLine();

        decimal originalWeight = standardShipment.Weight;

        standardShipment.UpdateWeight(5);

        decimal updatedWeight = standardShipment.Weight;

        standardShipment.UpdateWeight(5, 0.5m);

        decimal updatedWeightAfterPacking = standardShipment.Weight;

        Console.WriteLine($"Original Weight : {originalWeight} KG");
        Console.WriteLine($"Updated Weight : {updatedWeight} KG");
        Console.WriteLine(
            $"Updated Weight After Packing : {updatedWeightAfterPacking} KG");

        
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("Printing Using Shipment[]...");
        Console.WriteLine();

        Shipment[] shipments =
        {
            standardShipment,
            expressShipment,
            internationalShipment
        };

        foreach (Shipment shipment in shipments)
        {
            if (shipment is StandardShipment)
                Console.WriteLine("Standard Shipment...");

            else if (shipment is ExpressShipment)
                Console.WriteLine("Express Shipment...");

            else if (shipment is InternationalShipment)
                Console.WriteLine("International Shipment...");
        }

        Console.WriteLine();
        Console.WriteLine("==========================================");

        
        CompletedShipment completedShipment =
            new CompletedShipment(
                "SH004",
                "Monitor",
                4,
                90,
                address1
            );

        
        PriorityInternationalShipment priorityShipment =
            new PriorityInternationalShipment(
                "SH005",
                "Camera",
                3,
                150,
                address3,
                "France",
                120
            );

        priorityShipment.GenerateCustomsReport();

        Console.ReadKey();

        #endregion
    }
}