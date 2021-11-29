using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    /// <summary>
    /// create enum for Gender
    /// </summary>
    public enum Gen
    {
        Male = 1,
        Female,
        Transgender,
        Others
    }
    /// <summary>
    /// Create Benificary class for creat property and Field
    /// </summary>
    class Benificary
    {
        private static int TempRegisterNumber = 1001;

        public int RegisterNumber;
       
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public Gen Gender { get; set; }
        public  List<VaccinDetails> VaccinDetails { get; set; }

        /// <summary>
        /// Creat Benificary Constructor for add values
        /// </summary>
        /// <param name="name">Get Customer name</param>
        /// <param name="phone">Get user Phone number</param>
        /// <param name="city">Get user city name</param>
        /// <param name="age">Get user Age</param>
        /// <param name="gender">Get user gender</param>
        public Benificary(string name, long phone, string city, int age, Gen gender)
        {
            this.Name = name;
            this.PhoneNumber = phone;
            this.City = city;
            this.Age = age;
            this.Gender = gender;
            this.RegisterNumber = TempRegisterNumber++;
        }

        public void GetDetail(int reg)
        {
            if (this.RegisterNumber == reg)
            {
                if (VaccinDetails != null)
                {
                    foreach (VaccinDetails data in VaccinDetails)
                    {
                        Console.WriteLine("---------------------------");
                        Console.WriteLine($"Vacination Type : {data.vaccinType}");
                        Console.WriteLine($"Vacinated Date : {data.VaccinatedDate}");
                        Console.WriteLine("---------------------------");
                    }
                }
            }
        }

        public void DueDate(int reg)
        {
            if (this.RegisterNumber == reg)
            {
                if (VaccinDetails != null)
                {
                    foreach (VaccinDetails data in VaccinDetails)
                    {
                        if (VaccinDetails.Count == 1)
                        {
                            Console.WriteLine("\n------------------------------------");
                            Console.WriteLine($"Next Due date is :{data.VaccinatedDate.AddDays(30)}");
                            Console.WriteLine("------------------------------------");
                        }
                        else if (VaccinDetails.Count == 2)
                        {
                            Console.WriteLine($"\nYou have completed the vaccination course.\nThanks for your participation in the vaccination drive.");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nPlease go and take Vaccine!");
            }
        }

    }
}
