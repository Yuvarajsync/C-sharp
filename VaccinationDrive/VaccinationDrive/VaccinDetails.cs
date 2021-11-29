using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public enum VaccinType
    {
        CovinShild = 1,
        Covaxin,
        Sputnic
    }
    class VaccinDetails
    {
        public DateTime VaccinatedDate { get; set; }
        public VaccinType vaccinType { get; set; }

        public VaccinDetails(VaccinType vaccinType,DateTime vaccinatedDate)
        {
            this.VaccinatedDate = vaccinatedDate;
            this.vaccinType = vaccinType;
        }
    }
}
