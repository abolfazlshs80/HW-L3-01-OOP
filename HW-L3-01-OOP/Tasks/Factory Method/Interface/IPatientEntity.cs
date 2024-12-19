using Question4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L3_01_OOP.Tasks.Factory_Method
{
    public interface IPatientEntity
    {
        void Create(Patient patient);
        List<Patient> List();
        Patient Get(string PatientId);
        void Delete();
    }
}
