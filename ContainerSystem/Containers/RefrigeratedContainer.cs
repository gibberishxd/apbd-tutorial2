using ContainerSystem.Exceptions;
using System;
using System.Collections.Generic;

namespace ContainerSystem.Containers
{
    public class RefrigeratedContainer(
        double cargoMass,
        double height,
        double tareWeight,
        double depth,
        string serialNumber,
        double maxLoad,
        string productType,
        double temperature)
        : Container(cargoMass, height, tareWeight, depth, serialNumber, maxLoad)
    {
        public string ProductType { get; private set; } = productType;
        public double Temperature { get; private set; } = temperature;

        public override void Load(double cargoWeight)
        {
            if (Temperature < RefrigeratedProducts.Products[ProductType])
            {
                throw new ArgumentException($"Temperature of the container is lower than required for {ProductType}");
            }
            else
            {
                CargoMass += cargoWeight;    
            }
            
        }

        public override void Empty()
        {
            CargoMass = 0;
            Console.WriteLine($"Successfully emptied the container: {SerialNumber}");
        }
    }
    
    public static class RefrigeratedProducts
    {
        public static Dictionary<string, double> Products = new Dictionary<string, double>()
        {
            {"Bananas", 13.3},
            {"Chocolate", 18},
            {"Fish", 2},
            {"Ice cream", -18},
            {"Milk", 4},
            {"Yogurt", 4},
            {"Cheese", 7.2},
            {"Sausages", 5}
        };
    }
}