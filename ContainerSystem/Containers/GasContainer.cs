using ContainerSystem.Exceptions;
using ContainerSystem.Interfaces;

namespace ContainerSystem.Containers;

public class GasContainer: Container, IHazardNotifier
{
    public double Pressure;
    
    public GasContainer(double cargoMass, double height, double tareWeight, double depth, string serialNumber, double maxLoad, double pressure)
        : base(cargoMass, height, tareWeight, depth, serialNumber, maxLoad)
    {
        Pressure = pressure;
    }
    
    public override void Load(double cargoWeight)
    {
        
        if (cargoWeight <= MaxLoad)
        {
            CargoMass += cargoWeight;
        }
        else
        {
            throw new OverfillException("Can't be filled over 90% of capacity");
        }
        
    }

    public override void Empty()
    {
        CargoMass = CargoMass * 0.05;
        Console.WriteLine($"Successfully emptied. Mass is now {CargoMass}");
    } 

    public void HazardNotification(string serialNumber)
    {
        Console.Write($"Hazard notification! Container: {serialNumber}");
    }
}