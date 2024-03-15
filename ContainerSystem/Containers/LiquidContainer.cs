namespace ContainerSystem.Containers;

public class LiquidContainer : Containers.Container
{
    public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, string serialNumber, double maxLoad) : base(cargoMass, height, tareWeight, depth, serialNumber, maxLoad)
    {
    }

    public override void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
    }
}