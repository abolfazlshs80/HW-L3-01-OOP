using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Strategy_Pattern
{
    public class SurgeonStrategy : ISpecializationStrategy
    {
        public string HandlePatient(string patientName)
        {
            Console.WriteLine($"Surgeon is performing surgery for the patient: {patientName}.");
            string desc = " desc : " + typeof(SurgeonStrategy).Name;
            return desc;
        }
    }
}
