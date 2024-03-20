namespace ContainerSystem.Containers;

public class RefrigeratedContainer: Container
{
    public string ProductType;
    public double Temperature;
    
    public RefrigeratedContainer(double cargoMass, double height, double tareWeight, double depth, string serialNumber, double maxLoad, string productType, double temperature)
        : base(cargoMass, height, tareWeight, depth, serialNumber, maxLoad)
    {
        ProductType = productType;
        Temperature = temperature;
        
    }
}