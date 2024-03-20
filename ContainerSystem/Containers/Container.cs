using ContainerSystem.Exceptions;

namespace ContainerSystem.Containers;

public abstract class Container 
{
    public double CargoMass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxLoad { get; set; }

    protected Container(double cargoMass, double height, double tareWeight, double depth, string serialNumber,
        double maxLoad)
    {
        CargoMass = cargoMass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxLoad = maxLoad;


    }

    public abstract void Load(double cargoWeight);

    public abstract void Empty();

}