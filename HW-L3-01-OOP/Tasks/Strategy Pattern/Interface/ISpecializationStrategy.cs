using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Strategy_Pattern
{
    public interface ISpecializationStrategy
    {
        string HandlePatient(string patientName);
    }
}
