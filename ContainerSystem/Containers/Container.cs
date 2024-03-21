using ContainerSystem.Exceptions;

namespace ContainerSystem.Containers;

public abstract class Container(
    double cargoMass,
    double height,
    double tareWeight,
    double depth,
    string serialNumber,
    double maxLoad)
{
    public double CargoMass { get; set; } = cargoMass;
    public double Height { get; set; } = height;
    public double TareWeight { get; set; } = tareWeight;
    public double Depth { get; set; } = depth;
    public string SerialNumber { get; set; } = serialNumber;
    public double MaxLoad { get; set; } = maxLoad;

    public abstract void Load(double cargoWeight);

    public abstract void Empty();

}