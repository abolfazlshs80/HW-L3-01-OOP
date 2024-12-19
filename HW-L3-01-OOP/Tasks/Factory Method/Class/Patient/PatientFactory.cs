using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Factory_Method.Class.Patient
{
    public class PatientFactory: PatientEntityFactory
    {
    

        public override IPatientEntity CreatePatientEntity()
        {
            return new PatientManager();
        }
    }
}
