using ContainerSystem.Exceptions;

namespace ContainerSystem.Containers;

public class LiquidContainer(
    double cargoMass,
    double height,
    double tareWeight,
    double depth,
    string serialNumber,
    double maxLoad,
    bool isHazardous)
    : Container(cargoMass, height, tareWeight, depth, serialNumber, maxLoad), Interfaces.IHazardNotifier
{
    public override void Load(double cargoWeight)
    {
        if (isHazardous)
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