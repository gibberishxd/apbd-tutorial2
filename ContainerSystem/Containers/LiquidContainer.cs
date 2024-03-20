using ContainerSystem.Exceptions;

namespace ContainerSystem.Containers;

public class LiquidContainer : Container, Interfaces.IHazardNotifier
{
    private bool IsHazardous;
    
    public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, string serialNumber, double maxLoad, bool isHazardous)
        : base(cargoMass, height, tareWeight, depth, serialNumber, maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double cargoWeight)
    {
        if (IsHazardous)
        {
            if (cargoWeight <= MaxLoad / 2)
            {
                CargoMass += cargoWeight;
                Console.WriteLine($"Successfully filled by {cargoWeight} kgs");
                Console.WriteLine($"Total cargo mass is: {CargoMass} kgs");
            }
            else
            {
                throw new OverfillException("Can't be filled over 50% of capacity (Hazardous cargo)");
            }
        }
        else
        {
            if (cargoWeight <= MaxLoad * 0.9)
            {
                CargoMass += cargoWeight;
            }
            else
            {
                throw new OverfillException("Can't be filled over 90% of capacity");
            }
        }
    }

    public override void Empty()
    {
        CargoMass = 0;
        Console.WriteLine("Container Emptied.");
    }
    public void HazardNotification(string serialNumber)
    {
        Console.Write($"Hazard notification! Container: {serialNumber}");
    }
}