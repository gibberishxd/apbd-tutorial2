using System.Collections.Generic;
using ContainerSystem.Exceptions;

namespace ContainerSystem.Containers
{
    public class ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        public string ShipName { get; set; } = name;
        public List<Container> Containers { get; private set; } = new();
        public double MaxSpeed { get; private set; } = maxSpeed;
        public int MaxContainers { get; private set; } = maxContainers;
        public double MaxWeight { get; private set; } = maxWeight;

        public void AddContainers(List<Container> containers)
        {
            double containersWeight = CountWeight(containers);
            
            if (containers.Count <= MaxContainers && (MaxWeight >= containersWeight)){
                Containers.AddRange(containers);
                MaxWeight -= containersWeight;
                Console.WriteLine($"Ship {ShipName} successfully loaded {containers.Count} containers");
                foreach (var container in containers)
                {
                    Console.WriteLine(container.SerialNumber);
                }
                
            }
            else if (containers.Count > MaxContainers)
            {
                throw new OverfillException("Too many containers");
            }
            else
            {
                throw new OverfillException("Too much weight");
            }
            {
                
            }
        }

        public void AddContainer(Container container)
        {
            double containerWeight = container.CargoMass + container.TareWeight;
            
            if (Containers.Count + 1 <= MaxContainers && (MaxWeight >= containerWeight)){
                Containers.Add(container);
                MaxWeight -= containerWeight;
                Console.WriteLine($"Ship {ShipName} successfully loaded {container.SerialNumber} container");
            }
            else if (Containers.Count + 1 > MaxContainers)
            {
                throw new OverfillException("Too many containers");
            }
            else
            {
                throw new OverfillException("Too much weight");
            }
        }
        
        public void UnloadContainer(Container container)
        {
            if (Containers.Contains(container))
            {
                Containers.Remove(container);
                MaxWeight += container.CargoMass + container.TareWeight;
                Console.WriteLine($"Container {container.SerialNumber} unloaded from ship {ShipName}");
            }
            else
            {
                throw new Exception($"Container {container.SerialNumber} not found on ship {ShipName}");
            }
        }
        
        private double CountWeight(List<Container> containers)
        {
            double weight = containers.Sum(container => container.CargoMass + container.TareWeight);
            return weight;
        }
    }
}