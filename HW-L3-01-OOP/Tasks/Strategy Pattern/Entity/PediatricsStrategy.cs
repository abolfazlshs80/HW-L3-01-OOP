using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Strategy_Pattern
{
    //اطفال
    public class PediatricsStrategy : ISpecializationStrategy
    {
        public string HandlePatient(string patientName)
        {
            Console.WriteLine($"Pediatrician is treating the child: {patientName}.");
            string desc = " desc : " +typeof(PediatricsStrategy).Name;
            return desc;
        }
    }

}
