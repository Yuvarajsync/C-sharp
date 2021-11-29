using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    class Program
    {
        /// <summary>
        /// create object for Benificary class inside list
        /// </summary>
        private List<Benificary> benificaryList = new List<Benificary>();

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        
        static void Main(string[] args)
        {
            Program userObject = new Program();
            userObject.DefaultUserDetails();
            string userContinue;
            do
            {
                Console.WriteLine("----- Covid Vaccination System -------");
                Console.WriteLine("1. Benificary details");
                Console.WriteLine("2. Vaccination");
                Console.WriteLine("3. Exit");
                Console.Write("Choose :>> ");
                int userOption = int.Parse(Console.ReadLine());

                switch (userOption)
                {
                    case 1:
                        userObject.BenificaryDetails();
                        break;
                    case 2:
                        userObject.Vaccination();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong! Option ");
                        break;
                }
                Console.Write("Continue Main Menu :?(yes/no)");
                userContinue = Console.ReadLine().ToLower();
            }
            while (userContinue == "yes");


            Console.ReadKey();
        }
        /// <summary>
        /// Default data insert
        /// </summary>
        public void DefaultUserDetails()
        {
            var firstUser = new Benificary("yuvaraj", 343434, "TVM", 31, (Gen)1);
            var seconduser = new Benificary("TPK", 213213, "ARL", 21, (Gen)2);
            var thirduser = new Benificary("test", 328749328, "CHE", 23, (Gen)3);


            benificaryList.Add(firstUser);
            benificaryList.Add(seconduser);
            benificaryList.Add(thirduser);
        }
        /// <summary>
        /// Get Benificary Details and update
        /// </summary>
        public void BenificaryDetails()
        {
            string userOption;
            do
            {
                Console.Write("Benificary Name :>>");
                string name = Console.ReadLine();
                Console.Write("Benificary Phone Number :>>");
                long phoneNumber = Int64.Parse(Console.ReadLine());
                Console.Write("Benificary City :>>");
                string city = Console.ReadLine();
                Console.Write("Benificary Age :>>");
                int age = int.Parse(Console.ReadLine());
                Console.Write("\n1.Male\n2.Female\n3.Transgender\n4.Others");
                Console.Write("\nBenificary Gender :>>");
                Gen Gender = (Gen)int.Parse(Console.ReadLine());

                var Details = new Benificary(name, phoneNumber, city, age, Gender);
                benificaryList.Add(Details);

                Console.WriteLine("***Registration Success***");
                Console.WriteLine($"Your Register Number : {Details.RegisterNumber}");

                Console.Write("\nDo you want to continue?(yes/no)");
                userOption = Console.ReadLine().ToLower();
            }
            while (userOption == "yes");
        }

        /// <summary>
        /// user get vaccination.
        /// </summary>
        public void Vaccination()
        {
            string userOption;
            Console.WriteLine("----Vaccine Details------");
            Console.Write("Register Number :>> ");
            int registerNumber = int.Parse(Console.ReadLine());
            foreach (Benificary details in benificaryList)
            {
                if (details.RegisterNumber == registerNumber)
                {

                    Console.WriteLine($"Welcome Mr/Miss : {details.Name}");
                    Console.WriteLine("-------------------------------");
                    do
                    {
                        Console.WriteLine("1. Take vaccination");
                        Console.WriteLine("2. Vaccination History");
                        Console.WriteLine("3. Next Due Date");
                        Console.WriteLine("4. Exit");
                        Console.Write("Choose :>> ");
                        int userChoose = int.Parse(Console.ReadLine());
                        switch (userChoose)
                        {
                            case 1:
                                Console.WriteLine("Which Vaccine do you want ?");
                                Console.Write("1. CovinShild\n2. Covaxin\n3. Sputnic\nChoose :>> ");
                                VaccinType vaccinType = (VaccinType)int.Parse(Console.ReadLine());
                                if (details.RegisterNumber == registerNumber)
                                {
                                    VaccinDetails user = new VaccinDetails(vaccinType, DateTime.Now);

                                    if (details.VaccinDetails == null)
                                    {
                                        details.VaccinDetails = new List<VaccinDetails>();
                                    }
                                    details.VaccinDetails.Add(user);
                                }
                                Console.WriteLine("Vaccinated succesfully");
                                break;
                            case 2:
                                foreach (Benificary history in benificaryList)
                                {
                                    if (history.VaccinDetails != null)
                                    {
                                        history.GetDetail(registerNumber);
                                    }
                                }
                                break;
                            case 3:
                                foreach (Benificary due in benificaryList)
                                {
                                    if (due.VaccinDetails != null)
                                    {
                                        due.DueDate(registerNumber);
                                    }
                                }
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("No option available!");
                                break;
                        }
                        Console.Write("Do you want to continue?(yes/no):>> ");
                        userOption = Console.ReadLine().ToLower();
                    }
                    while (userOption == "yes");
                }
            }
        }
    }
}

