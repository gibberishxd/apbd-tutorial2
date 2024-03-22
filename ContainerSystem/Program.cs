
using ContainerSystem;
using ContainerSystem.Containers;
using ContainerSystem.Exceptions;


class Program
{
    static void Main(string[] args)
    {
        ContainerManager manager = new ContainerManager();
        // default stuff
        Container container1 = new LiquidContainer(300, 300, 200, 300, "KON-L-1", 1300, true);
        Container container2 = new GasContainer(200, 200, 200, 300, "KON-G-1", 1000, 2);
        ContainerShip ship1 = new ContainerShip("Ship 0", 100, 10, 1000);
        
        manager.AllContainers.Add(container1);
        manager.AllContainers.Add(container2);
        manager.AllShips.Add(ship1);
        

        while (true)
        {
            try
            {
                Console.WriteLine("1. Add container");
                Console.WriteLine("2. View containers");
                Console.WriteLine("3. Load cargo onto container");
                Console.WriteLine("4. Load container onto ship");
                Console.WriteLine("5. Load list of containers onto ship");
                Console.WriteLine("6. Create ship");
                Console.WriteLine("7. Unload a container from ship");
                Console.WriteLine("8. Replace a container on the ship");
                Console.WriteLine("9. Print information about a given container");
                Console.WriteLine("10. Print information about a given ship");
                Console.WriteLine("11. Transfer containers between ships");
                Console.WriteLine("12. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Container container = manager.CreateContainer();
                        Console.WriteLine($"Container {container.SerialNumber} created.");
                        break;
                    case "2":
                        foreach (var cont in manager.AllContainers)
                        {
                            Console.WriteLine(cont.SerialNumber);
                        }
                        break;
                    case "3":
                        Console.Write("Enter the serial number of the container to load cargo onto: ");
                        string? containerSerialNumber = Console.ReadLine();
                        Container selectedContainer = manager.GetContainerBySerialNumber(containerSerialNumber);
                        if (selectedContainer != null)
                        {
                            manager.LoadCargoToContainer(selectedContainer);
                        }
                        else
                        {
                            Console.WriteLine("Container not found.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter the name of the ship: ");
                        foreach (var sh in manager.AllShips)
                        {
                            Console.WriteLine(sh.ShipName);
                        }
                        string? shipName = Console.ReadLine();
                        ContainerShip ship = manager.GetShipByName(shipName);
                        
                        if (ship != null)
                        {
                            Console.Write("Enter the serial number of the container to load onto the ship: ");
                            foreach (var cont in manager.AllContainers)
                            {
                                Console.WriteLine(cont.SerialNumber);
                            }
                            string? contSerialNumber = Console.ReadLine();
                            Container selectedCont = manager.GetContainerBySerialNumber(contSerialNumber);
                            if (selectedCont != null)
                            {
                                manager.LoadContainerToShip(selectedCont, ship);
                            }
                            else
                            {
                                Console.WriteLine("Container not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ship not found.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter the name of the ship: ");
                        foreach (var shipper in manager.AllShips)
                        {
                            Console.WriteLine(shipper.ShipName);
                        }
                        string? shName = Console.ReadLine();
                        ContainerShip shi = manager.GetShipByName(shName);
                        
                        if (shi != null)
                        {
                            Console.WriteLine("Enter the serial numbers of the containers to load onto the ship (comma-separated): ");
                            foreach (var cont in manager.AllContainers)
                            {
                                Console.WriteLine(cont.SerialNumber);
                            }
                            string[] serialNumbers = Console.ReadLine()!.Split(',');
                            List<Container> containersToLoad = new List<Container>();
                            foreach (var serialNumber in serialNumbers)
                            {
                                Container selectedCont = manager.GetContainerBySerialNumber(serialNumber);
                                if (selectedCont != null)
                                {
                                    containersToLoad.Add(selectedCont);
                                }
                                else
                                {
                                    Console.WriteLine($"Container {serialNumber} not found.");
                                }
                            }
                            manager.LoadContainersToShip(containersToLoad, shi);
                           
                        }
                        else
                        {
                            Console.WriteLine("Ship not found.");
                        }
                        break;
                    case "6":
                        ContainerShip newShip = manager.CreateShip();
                        Console.WriteLine($"Ship {newShip.ShipName} created.");
                        break;
                    case "7":
                        Console.Write("Enter the name of the ship: ");
                        foreach (var s in manager.AllShips)
                        {
                            Console.WriteLine(s.ShipName);
                        }
                        string? shipNameUnload = Console.ReadLine();
                        ContainerShip shipUnload = manager.GetShipByName(shipNameUnload);
                        if (shipUnload != null)
                        {
                            Console.Write("Enter the serial number of the container to unload from the ship: ");
                            Console.WriteLine("Containers on the ship:");
                            foreach (var con in shipUnload.Containers)
                            {
                                Console.WriteLine(con.SerialNumber);
                            }
                            string? containerSerialNumberUnload = Console.ReadLine();
                            Container containerToUnload = manager.GetContainerBySerialNumber(containerSerialNumberUnload);
                            if (containerToUnload != null)
                            {
                                manager.UnloadContainerFromShip(containerToUnload, shipUnload);
                            }
                            else
                            {
                                Console.WriteLine($"Container with serial number {containerSerialNumberUnload} not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Ship with name {shipNameUnload} not found.");
                        }
                        break;
                    case "8":
                        Console.Write("Enter the name of the ship: ");
                        foreach (var sh in manager.AllShips)
                        {
                            Console.WriteLine(sh.ShipName);
                        }
                        string? shipNameReplace = Console.ReadLine();
                        ContainerShip shipReplace = manager.GetShipByName(shipNameReplace);
                        if (shipReplace != null)
                        {
                            Console.Write("Enter the serial number of the container to replace: ");
                            Console.WriteLine("Containers on the ship:");
                            foreach (var con in shipReplace.Containers)
                            {
                                Console.WriteLine(con.SerialNumber);
                            }
                            string? containerSerialNumberReplace = Console.ReadLine();
                            Container containerToReplace = manager.GetContainerBySerialNumber(containerSerialNumberReplace);
                            if (containerToReplace != null && shipReplace.Containers.Contains(containerToReplace))
                            {
                                Console.Write("Enter the serial number of the container to replace with: ");
                                foreach (var cont in manager.AllContainers)
                                {
                                    Console.WriteLine(cont.SerialNumber);
                                }
                                string? containerSerialNumberNew = Console.ReadLine();
                                Container newContainer = manager.GetContainerBySerialNumber(containerSerialNumberNew);
                                if (newContainer != null)
                                {
                                    manager.ReplaceContainerOnShip(containerToReplace, newContainer, shipReplace);
                                }
                                else
                                {
                                    Console.WriteLine($"Container with serial number {containerSerialNumberNew} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Container with serial number {containerSerialNumberReplace} not found on ship {shipNameReplace}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Ship with name {shipNameReplace} not found.");
                        }
                        break;
                    case "9":
                        Console.Write("Enter the serial number of the container: ");
                        foreach (var conto in manager.AllContainers)
                        {
                            Console.WriteLine(conto.SerialNumber);
                        }
                        string? serNumber = Console.ReadLine();
                        Container containerInfo = manager.GetContainerBySerialNumber(serNumber);
                        if (containerInfo != null)
                        {
                            Console.WriteLine($"Container {containerInfo.SerialNumber} has a cargo mass of {containerInfo.CargoMass} kgs and a tare weight of {containerInfo.TareWeight} kgs.");
                        }
                        else
                        {
                            Console.WriteLine($"Container with serial number {serNumber} not found.");
                        }
                        break;
                    case "10":
                        Console.Write("Enter the name of the ship: ");
                        foreach (var sh in manager.AllShips)
                        {
                            Console.WriteLine(sh.ShipName);
                        }
                        string? shipNameInfo = Console.ReadLine();
                        ContainerShip shipInfo = manager.GetShipByName(shipNameInfo);
                        if (shipInfo != null)
                        {
                            Console.WriteLine($"Ship {shipInfo.ShipName} has {shipInfo.Containers.Count} containers on board.");
                            Console.WriteLine($"Ship {shipInfo.ShipName} has a maximum weight of {shipInfo.MaxWeight} kgs and a maximum number of containers of {shipInfo.MaxContainers}. \nA maximum speed of {shipInfo.MaxSpeed} knots.");
                            if (shipInfo.Containers.Count > 0)
                            {
                                Console.WriteLine("Containers on the ship:");
                                foreach (var cont in shipInfo.Containers)
                                {
                                    Console.WriteLine(cont.SerialNumber);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No containers on the ship.");
                            
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Ship with name {shipNameInfo} not found.");
                        }
                        break;
                    case "11":
                        Console.WriteLine("Enter the name of the ship to transfer containers from: ");
                        foreach (var sh in manager.AllShips)
                        {
                            Console.WriteLine(sh.ShipName);
                        }
                        string? shipNameFrom = Console.ReadLine();
                        Console.WriteLine("Enter the name of the ship to transfer containers to: ");
                        foreach (var sh in manager.AllShips)
                        {
                            if (sh.ShipName != shipNameFrom)
                            {
                                Console.WriteLine(sh.ShipName);
                            }
                        }
                        
                        string? shipNameTo = Console.ReadLine();
                        
                        ContainerShip shipFrom = manager.GetShipByName(shipNameFrom);
                        ContainerShip shipTo = manager.GetShipByName(shipNameTo);
                        
                        if (shipFrom != null && shipTo != null)
                        {
                            Console.WriteLine("Enter the serial numbers of the containers to transfer (comma-separated): ");
                            foreach (var cont in shipFrom.Containers)
                            {
                                Console.WriteLine(cont.SerialNumber);
                            }
                            string[] serialNumbersTransfer = Console.ReadLine()!.Split(',');
                            List<Container> containersToTransfer = new List<Container>();
                            foreach (var serialNumber in serialNumbersTransfer)
                            {
                                Container selectedCont = manager.GetContainerBySerialNumber(serialNumber);
                                if (selectedCont != null)
                                {
                                    containersToTransfer.Add(selectedCont);
                                }
                                else
                                {
                                    Console.WriteLine($"Container {serialNumber} not found.");
                                }
                            }
                            manager.TransferContainersBetweenShips(containersToTransfer, shipFrom, shipTo);
                        }
                        else
                        {
                            Console.WriteLine("One or both ships not found.");
                        }
                        
                        
                        
                        break;
                        
                    case "12":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (OverfillException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}