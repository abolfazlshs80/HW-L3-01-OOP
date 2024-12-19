using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Strategy_Pattern
{
    public class DoctorContext
    {
        private ISpecializationStrategy _specializationStrategy;
        public string Desc { get; set; }
  
        public void SetSpecializationStrategy(ISpecializationStrategy specializationStrategy)
        {
            _specializationStrategy = specializationStrategy;
        }

        public string HandlePatient(string patientName)
        {
            if (_specializationStrategy == null)
            {
                Console.WriteLine("Specialization strategy is not set.");
                return "not set";
            }
            Desc=_specializationStrategy.HandlePatient(patientName);
            return Desc;
        }
    }
}
