using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /* 
    This C# console application is designed to:
    - Use a series of Lists to store various Appliance objects, and objects that derive from the Appliance class; Dishwasher, Microwave, Refrigirator, and Vacuum
    - Use various `foreach` statements to iterate through list of Appliance objects or derived objects from Appliance and do various logic checking
        such as to see if the Appliance is of certain type.
    - Use of various switch statements are also used to check for the objects type
    - Call the static method DisplayAppliancesFromList(List<Appliance> appliances, int max) from ModernAppliances class to format an output from the given appliances list
        with max being the maximum from various methods various methods such as Find(), DisplayRefrigerators(), DisplayVacuums(), DisplayMicrowaves(), DisplayDishwashers(), RandomList() 
    */

    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: Justin James Marquez, Dave Luna, Garry Jr Dayag, Jairo De Guzman </remarks>
    /// <remarks>Date: 6/10/2023</remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.Write("\nEnter the item number of an appliance: ");

            // Create long variable to hold item number
            long itemNumber = 0;

            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.
            if (!long.TryParse(Console.ReadLine(), out itemNumber))
            {
                Console.WriteLine("Please enter a valid input.");
                return;
            }

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance? foundAppliance = null;

            // Loop through Appliances
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    // Break out of loop (since we found what need to)
                    break;
                }
            }

            // Test appliance was not found (foundAppliance is null)
            if (foundAppliance == null)
            {
                // Write "No appliances found with that item number."
                Console.WriteLine("No appliances found with that item number.");
                return;
            }

            // Otherwise (appliance was found)
            // Test found appliance is available
            // Checkout found appliance
            if (foundAppliance.IsAvailable)
            {
                foundAppliance.Checkout();
                Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
            }
            // Write "Appliance has been checked out."
            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.Write("\nEnter brand to search for: ");

            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.
            string? brand = Console.ReadLine();
            if (brand == null)
            {
                Console.WriteLine("Please enter a valid input");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> Appliancefound = new List<Appliance>();

            // Iterate through loaded appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance brand matches what user entered
                if (appliance.Brand.ToLower().Contains(brand.ToLower()))
                {
                    // Add current appliance in list to found list
                    Appliancefound.Add(appliance);
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(Appliancefound, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            // Write "Enter number of doors: "
            Console.Write("\nPossible options:\n" +
                              "0 - Any\n" +
                              "2 - Double doors\n" +
                              "3 - Three doors\n" +
                              "4 - Four doors\n" +
                              "Enter number of doors: ");


            // Create variable to hold entered number of doors
            // Get user input as string and assign to variable
            string? doorsInput = Console.ReadLine();
            int numDoors = 0;

            // Convert user input from string to int and store as number of doors variable.
            if (!int.TryParse(doorsInput, out numDoors))
            {
                Console.WriteLine("Please enter a valid input.");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> Appliancefound = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test that current appliance is a refrigerator
                if (appliance is Refrigerator)
                {
                    // Down cast Appliance to Refrigerator
                    Refrigerator refrigerator = (Refrigerator)appliance;

                    // Test user entered 0 or refrigerator doors equals what user entered.
                    if (numDoors == 0 || refrigerator.Doors == numDoors)
                        // Add current appliance in list to found list
                        Appliancefound.Add(appliance);
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(Appliancefound, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"
            // Write "Enter grade:"
            Console.Write("\nPossible options:\n" +
                              "0 - Any\n" +
                              "1 - Residential\n" +
                              "2 - Commercial\n" +
                              "Enter grade: ");

            // Get user input as string and assign to variable
            string? gradeInput = Console.ReadLine();


            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string? grade = null;

            // Test input is "0"
            if (gradeInput == "0")
            {
                // Assign "Any" to grade
                grade = "Any";
            }
            // Test input is "1"
            else if (gradeInput == "1")
            {
                // Assign "Residential" to grade
                grade = "Residential";
            }
            // Test input is "2"
            else if (gradeInput == "2")
            {
                // Assign "Commercial" to grade
                grade = "Commercial";
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                // Return to calling (previous) method
                Console.WriteLine("Invalid option.");
                return;
            }

            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"
            // Write "Enter voltage:"
            Console.Write("Possible options:\n" +
                              "0 - Any\n" +
                              "1 - 18 Volt\n" +
                              "2 - 24 Volt\n" +
                              "Enter voltage: ");

            // Get user input as string
            // Create variable to hold voltage
            string? voltageInput = Console.ReadLine();
            int batteryVoltage = 0;

            // Test input is "0"
            if (voltageInput == "0")
            {
                // Assign 0 to voltage
                batteryVoltage = 0;
            }
            // Test input is "1"
            else if (voltageInput == "1")
            {
                // Assign 18 to voltage
                batteryVoltage = 18;
            }
            // Test input is "2"
            else if (voltageInput == "2")
            {
                // Assign 24 to voltage
                batteryVoltage = 24;
            }
            // Otherwise
            else
            {
                // Write "Invalid option."
                // Return to calling (previous) method
                // return;
                Console.WriteLine("Invalid option.");
                return;
            }
            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Check if current appliance is vacuum
                if (appliance is Vacuum)
                {
                    // Down cast current Appliance to Vacuum object
                    Vacuum vacuum = (Vacuum)appliance;

                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage
                    // is equal to current vacuum voltage

                    if ((grade == "Any" || grade == vacuum.Grade) && (batteryVoltage == 0 || batteryVoltage == vacuum.BatteryVoltage))
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"
            // Write "Enter room type:"
            Console.Write("\nPossible options:\n" +
                          "0 - Any\n" +
                           "1 - Kitchen\n" +
                           "2 - Work site\n" +
                           "Enter room type: ");

            // Get user input as string and assign to variable
            string? roomInput = Console.ReadLine();

            // Create character variable that holds room type
            char roomType = '0';

            switch (roomInput)
            {
                // Test input is "0"
                case "0":
                    // Assign 'A' to room type variable
                    roomType = 'A';
                    break;
                // Test input is "1"
                case "1":
                    // Assign 'K' to room type variable
                    roomType = 'K';
                    break;
                // Test input is "2"
                case "2":
                    // Assign 'W' to room type variable
                    roomType = 'W';
                    break;

                // Otherwise (input is something else)
                default:
                    // Write "Invalid option."
                    Console.WriteLine("Invalid option.");
                    // Return to calling method
                    return;
            }
            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance is Microwave
                if (appliance is Microwave)
                {
                    // Down cast Appliance to Microwave
                    Microwave microwave = (Microwave)appliance;

                    // Test room type equals 'A' or microwave room type
                    if (microwave.RoomType == roomType || roomType == 'A')
                        // Add current appliance in list to found list
                        found.Add(microwave);
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"
            // Write "Enter sound rating:"
            Console.Write("\nPossible options:\n" +
                          "0 - Any\n" +
                          "1 - Quietest\n" +
                          "2 - Quieter\n" +
                          "3 - Quiet\n" +
                          "4 - Moderate\n" +
                          "Enter sound rating: ");

            // Get user input as string and assign to variable
            // Create variable that holds sound rating
            string? userInput = Console.ReadLine();
            string soundRating = "";

            switch (userInput)
            {
                // Test input is "0"
                case "0":
                    // Assign "Any" to sound rating variable
                    soundRating = "Any";
                    break;

                // Test input is "1"
                case "1":
                    // Assign "Qt" to sound rating variable
                    soundRating = "Qt";
                    break;

                // Test input is "2"
                case "2":
                    // Assign "Qr" to sound rating variable
                    soundRating = "Qr";
                    break;

                // Test input is "3"
                case "3":
                    // Assign "Qu" to sound rating variable
                    soundRating = "Qu";
                    break;

                // Test input is "4"
                case "4":
                    // Assign "M" to sound rating variable
                    soundRating = "M";
                    break;

                // Otherwise (input is something else)
                default:
                    // Write "Invalid option."
                    Console.WriteLine("Invalid option.");

                    // Return to calling method
                    return;
            }

            // Create variable that holds list of found appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test if current appliance is dishwasher
                if (appliance is Dishwasher)
                {
                    // Down cast current Appliance to Dishwasher
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                    if (dishwasher.SoundRating == soundRating || soundRating == "Any")
                        // Add current appliance in list to found list
                        found.Add(dishwasher);
                }
            }

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"
            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"
            // Write "Enter type of appliance:"
            Console.Write("Appliance Types\n" +
                          "0 - Any\n" +
                          "1 - Refrigerators\n" +
                          "2 - Vacuums\n" +
                          "3 - Microwaves\n" +
                          "4 - Dishwashers\n" +
                          "Enter type of appliance: ");



            // Get user input as string and assign to appliance type variable
            string? applianceType = Console.ReadLine();

            // Write "Enter number of appliances: "
            Console.Write("Enter number of appliances: ");

            // Get user input as string and assign to variable
            // Convert user input from string to int
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Please enter a valid input");
                return;
            }
            // Create variable to hold list of found
            List<Appliance> found = new List<Appliance>();

            // Loop through appliances
            foreach (Appliance appliance in Appliances)
            {
                switch (applianceType)
                {
                    // Test inputted appliance type is "0"
                    // Add current appliance in list to found list
                    case "0":
                        found.Add(appliance);
                        break;

                    // Test inputted appliance type is "1"
                    // Test current appliance type is Refrigerator
                    // Add current appliance in list to found list
                    case "1":
                        if (appliance.Type == Appliance.ApplianceTypes.Refrigerator)
                            found.Add(appliance);
                        break;

                    // Test inputted appliance type is "2"
                    // Test current appliance type is Vacuum
                    // Add current appliance in list to found list
                    case "2":
                        if (appliance.Type == Appliance.ApplianceTypes.Vacuum)
                            found.Add(appliance);
                        break;

                    // Test inputted appliance type is "3"
                    // Test current appliance type is Microwave
                    // Add current appliance in list to found list
                    case "3":
                        if (appliance.Type == Appliance.ApplianceTypes.Microwave)
                            found.Add(appliance);
                        break;

                    // Test inputted appliance type is "4"
                    // Test current appliance type is Dishwasher
                    // Add current appliance in list to found list
                    case "4":
                        if (appliance.Type == Appliance.ApplianceTypes.Dishwasher)
                            found.Add(appliance);
                        break;
                }
            }

            // Randomize list of found appliances
            found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, num);
        }
    }
}
