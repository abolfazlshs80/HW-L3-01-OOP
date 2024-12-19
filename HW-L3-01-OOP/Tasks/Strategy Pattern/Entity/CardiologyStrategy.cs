using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Strategy_Pattern
{//قلب و عروق
    public class CardiologyStrategy : ISpecializationStrategy
    {
        public string HandlePatient(string patientName)
        {
            Console.WriteLine($"Cardiologist is treating the patient: {patientName} for heart-related issues.");
            string desc = " desc :" + typeof(CardiologyStrategy).Name;
            return desc;
        }
    }
}
