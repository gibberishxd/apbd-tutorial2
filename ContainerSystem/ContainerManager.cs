using System;
using System.Collections.Generic;
using ContainerSystem.Containers;

namespace ContainerSystem
{
    public class ContainerManager
    {
        public  List<Container> AllContainers;
        public List<ContainerShip> AllShips;

        private readonly List<string> _containerTypes = ["Liquid", "Gas", "Refrigerated"];
        private  Dictionary<string, int> _containerTypeCounts = new();

        public ContainerManager()
        {
            AllContainers = new List<Container>();
            AllShips = new List<ContainerShip>();
            Console.WriteLine("Controller initialized");
        }

        public Container CreateContainer()
        {
            for (int i = 0; i < _containerTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_containerTypes[i]}");
            }

            int type = Convert.ToInt32(Console.ReadLine());

            switch (type)
            {
                case 1:
                    return CreateLiquidContainer();
                case 2:
                    return CreateGasContainer();
                case 3:
                    return CreateRefrigeratedContainer();
                default:
                    Console.WriteLine("Invalid type. Try again.");
                    return null;
            }
        }
        
        public ContainerShip CreateShip()
        {
            Console.WriteLine("Enter max speed: ");
            double maxSpeed = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter max containers: ");
            int maxContainers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter max weight: ");
            double maxWeight = Convert.ToDouble(Console.ReadLine());
            string shipName = GenerateShipName();
            ContainerShip ship = new ContainerShip(shipName, maxSpeed, maxContainers, maxWeight);
            AllShips.Add(ship);
            return ship;
        }
        
        public void LoadCargoToContainer(Container container)
        {
            Console.WriteLine("Enter cargo weight: ");
            double cargoWeight = Convert.ToDouble(Console.ReadLine());
            container.Load(cargoWeight);
        }
        
        public Container GetContainerBySerialNumber(string? serialNumber)
        {
            foreach (var container in AllContainers)
            {
                if (container.SerialNumber == serialNumber)
                {
                    return container;
                }
            }

            return null;
        }
        
        public ContainerShip GetShipByName(string? shipName)
        {
            foreach (var ship in AllShips)
            {
                if (ship.ShipName == shipName)
                {
                    return ship;
                }
            }

            return null;
        }
        
        public void LoadContainerToShip(Container container, ContainerShip ship)
        {
            ship.AddContainer(container);
        }
        
        public void LoadContainersToShip(List<Container> containers, ContainerShip ship)
        {
            ship.AddContainers(containers);
        }
        
        public void UnloadContainerFromShip(Container container, ContainerShip ship)
        {
            ship.UnloadContainer(container);
        }
        
        public void ReplaceContainerOnShip(Container container, Container new_container,ContainerShip ship)
        {
            ship.UnloadContainer(container);
            ship.AddContainer(new_container);
        }
        

        private string GenerateSerialNumber(string containerType)
        {
            string containerAbbreviation = "";
            switch (containerType)
            {
                case "Liquid":
                    containerAbbreviation = "L";
                    break;
                case "Gas":
                    containerAbbreviation = "G";
                    break;
                case "Refrigerated":
                    containerAbbreviation = "C";
                    break;
                default:
                    Console.WriteLine("Unknown container type.");
                    break;
            }

            if (!_containerTypeCounts.ContainsKey(containerAbbreviation))
            {
                _containerTypeCounts[containerAbbreviation] = 0;
            }
            _containerTypeCounts[containerAbbreviation]++;
            return $"KON-{containerAbbreviation}-{_containerTypeCounts[containerAbbreviation]}";
        }

        private string GenerateShipName()
        {
            return "Ship " + AllShips.Count;
        }


        private Container CreateLiquidContainer()
        {
            Console.WriteLine("Enter cargo mass: ");
            double cargoMass = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter tare weight: ");
            double tareWeight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter depth: ");
            double depth = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter max load: ");
            double maxLoad = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Is hazardous? (true/false): ");
            bool isHazardous = Convert.ToBoolean(Console.ReadLine());

            string serialNumber = GenerateSerialNumber("Liquid");
            LiquidContainer container = new LiquidContainer(cargoMass, height, tareWeight, depth, serialNumber, maxLoad, isHazardous);
            AllContainers.Add(container);
            Console.WriteLine("Container created successfully.");
            return container;
        }

        private Container CreateGasContainer()
        {
            Console.WriteLine("Enter cargo mass: ");
            double cargoMass = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter tare weight: ");
            double tareWeight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter depth: ");
            double depth = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter max load: ");
            double maxLoad = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter pressure: ");
            double pressure = Convert.ToDouble(Console.ReadLine());

            string serialNumber = GenerateSerialNumber("Gas");
            GasContainer container = new GasContainer(cargoMass, height, tareWeight, depth, serialNumber, maxLoad, pressure);
            AllContainers.Add(container);
            Console.WriteLine("Container created successfully.");
            return container;
        }

        private Container CreateRefrigeratedContainer()
        {
            Console.WriteLine("Enter cargo mass: ");
            double cargoMass = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter tare weight: ");
            double tareWeight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter depth: ");
            double depth = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter max load: ");
            double maxLoad = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter product type: ");
            string productType = Console.ReadLine();
            Console.WriteLine("Enter temperature: ");
            double temperature = Convert.ToDouble(Console.ReadLine());

            string serialNumber = GenerateSerialNumber("Refrigerated");
            RefrigeratedContainer container = new RefrigeratedContainer(cargoMass, height, tareWeight, depth, serialNumber, maxLoad, productType, temperature);
            AllContainers.Add(container);
            Console.WriteLine("Container created successfully.");
            return container;
        }
    }
}
